/**
 * 
 * Modifications by Simon Hewitt
 *  - change constructors/methods to return byte[]
 *  - append original source size at the end of the destination buffer
 *  - add support for MemoryStream internal buffer usage
 * 
 * 
 * ManagedLZO.MiniLZO
 * 
 * Minimalistic reimplementation of minilzo in C#
 * 
 * @author Shane Eric Bryldt, Copyright (C) 2006, All Rights Reserved
 * @note Uses unsafe/fixed pointer contexts internally
 * @liscence Bound by same liscence as minilzo as below, see file COPYING
 */

/* Based on minilzo.c -- mini subset of the LZO real-time data compression library

   This file is part of the LZO real-time data compression library.

   Copyright (C) 2005 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 2004 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 2003 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 2002 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 2001 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 2000 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 1999 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 1998 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 1997 Markus Franz Xaver Johannes Oberhumer
   Copyright (C) 1996 Markus Franz Xaver Johannes Oberhumer
   All Rights Reserved.

   The LZO library is free software; you can redistribute it and/or
   modify it under the terms of the GNU General Public License,
   version 2, as published by the Free Software Foundation.

   The LZO library is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with the LZO library; see the file COPYING.
   If not, write to the Free Software Foundation, Inc.,
   51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.

   Markus F.X.J. Oberhumer
   <markus@oberhumer.com>
   http://www.oberhumer.com/opensource/lzo/
 */

/*
 * NOTE:
 *   the full LZO package can be found at
 *   http://www.oberhumer.com/opensource/lzo/
 */

#define USE_SAFE
#define BOUNDARY_CHECKS

//#if NO_SILVERLIGHT

using System;
using System.Diagnostics;
using System.IO;

namespace abbSolutions.Communication
{
    public static class MiniLZO
    {
        private const byte BITS = 14;
        private const uint D_MASK = (1 << BITS) - 1;
        private const uint M2_MAX_LEN = 8;
        private const uint M2_MAX_OFFSET = 0x0800;
        private const byte M3_MARKER = 32;
        private const uint M3_MAX_OFFSET = 0x4000;
        private const byte M4_MARKER = 16;
        private const uint M4_MAX_LEN = 9;
        private const uint M4_MAX_OFFSET = 0xbfff;

        private static readonly uint DICT_SIZE = 65536 + 3;

        static MiniLZO()
        {
            if (IntPtr.Size == 8)
            {
                DICT_SIZE = (65536 + 3) * 2;
            }
            else
            {
                DICT_SIZE = 65536 + 3;
            }
        }

        public static byte[] Compress(this byte[] src)
        {
            return Compress(src, 0, src.Length);
        }

        public static byte[] Compress(this byte[] src, int srcCount)
        {
            return Compress(src, 0, srcCount);
        }

        public static byte[] Compress(this byte[] src, int srcStart, int srcLength)
        {
            uint dstlen = (uint)(srcLength + (srcLength / 16) + 64 + 3 + 4);
            byte[] dst = new byte[dstlen];

            uint compressedSize = Compress(src, (uint)srcStart, (uint)srcLength, dst, 0, dstlen, null);

            if (dst.Length != compressedSize)
            {
                byte[] final = new byte[compressedSize];
                Buffer.BlockCopy(dst, 0, final, 0, (int)compressedSize);
                dst = final;
            }

            return dst;
        }

        public static byte[] Compress(this MemoryStream source)
        {
            byte[] destinationBuffer;
            uint sourceOffset;
            uint sourceLength;
            uint destinationLength;

            byte[] sourceBuffer = source.GetBuffer();
            uint sourceCapacity = (uint)source.Capacity;
            sourceLength = (uint)source.Length;
            destinationLength = sourceLength + (sourceLength / 16) + 64 + 3 + 4;

            uint unusedSpace = sourceCapacity - sourceLength;
            uint inplaceOverhead = Math.Min(sourceLength, M4_MAX_OFFSET) + sourceLength / 64 + 16 + 3 + 4;

            if (unusedSpace < inplaceOverhead)
            {
                sourceOffset = 0;
                destinationBuffer = new byte[destinationLength];
            }
            else
            {
                sourceOffset = inplaceOverhead;
                source.SetLength(sourceLength + inplaceOverhead);
                destinationBuffer = sourceBuffer;
                Buffer.BlockCopy(destinationBuffer, 0, destinationBuffer, (int)inplaceOverhead, (int)sourceLength);
                unusedSpace -= inplaceOverhead;
            }

            uint compressedSize = Compress(sourceBuffer, sourceOffset, sourceLength, destinationBuffer, 0, destinationLength, null);

            if (destinationBuffer == sourceBuffer)
            {
                source.SetLength(compressedSize);
                source.Capacity = (int)compressedSize;
                return source.GetBuffer();
            }
            else
            {
                byte[] final = new byte[compressedSize];
                Buffer.BlockCopy(destinationBuffer, 0, final, 0, (int)compressedSize);
                return final;
            }
        }

#if USE_SAFE
        public static byte[] Decompress(this byte[] src)
        {
            byte[] dst = new byte[(src[src.Length - 4] | (src[src.Length - 3] << 8) | (src[src.Length - 2] << 16 | src[src.Length - 1] << 24))];

            uint t = 0;
            //fixed (byte* input = src, output = dst)
            //{
            uint lpos = 0;
            uint lip_end = (uint)src.Length - 4;
            uint lop_end = (uint)dst.Length;
            //byte* pos = null;
            //byte* ip_end = input + src.Length - 4;
            //byte* op_end = output + dst.Length;

            uint lip = 0;
            uint lop = 0;
            //byte* ip = input;
            //byte* op = output;
            bool match = false;
            bool match_next = false;
            bool match_done = false;
            bool copy_match = false;
            bool first_literal_run = false;
            bool eof_found = false;

            if (src[lip] > 17)//if (*ip > 17)
            {
                t = (uint)(src[lip] - 17); lip++;//t = (uint)(*ip++ - 17);
                if (t < 4)
                    match_next = true;
                else
                {
#if BOUNDARY_CHECKS
                    Debug.Assert(t > 0);
                    if ((lop_end - lop) < t)//if ((op_end - op) < t)
                        throw new OverflowException("Output Overrun");
                    if ((lip_end - lip) < t + 1)//if ((ip_end - ip) < t + 1)
                        throw new OverflowException("Input Overrun");
#endif
                    do
                    {
                        dst[lop] = src[lip]; lop++; lip++;// WriteAndIncrement(dst, ReadAndIncrement(src, ref lip), ref lop);//*op++ = *ip++;
                    } while (--t > 0);
                    first_literal_run = true;
                }
            }
            while (!eof_found && lip < lip_end)//while (!eof_found && ip < ip_end)
            {
                if (!match_next && !first_literal_run)
                {
                    t = src[lip]; lip++;// ReadAndIncrement(src, ref lip); //*ip++;
                    if (t >= 16)
                        match = true;
                    else
                    {
                        if (t == 0)
                        {
#if BOUNDARY_CHECKS
                            if ((lip_end - lip) < 1)//if ((ip_end - ip) < 1)
                                throw new OverflowException("Input Overrun");
#endif
                            while (src[lip] == 0)//while (*ip == 0)
                            {
                                t += 255;
                                lip++;//++ip;
#if BOUNDARY_CHECKS
                                if ((lip_end - lip) < 1)//if ((ip_end - ip) < 1)
                                    throw new OverflowException("Input Overrun");
#endif
                            }
                            t += (uint)(15 + src[lip]);//t += (uint)(15 + *ip++);
                            lip++;
                        }
#if BOUNDARY_CHECKS
                        Debug.Assert(t > 0);
                        if ((lop_end - lop) < t + 3)//if ((op_end - op) < t + 3)
                            throw new OverflowException("Output Overrun");
                        if ((lip_end - lip) < t + 4) //if ((ip_end - ip) < t + 4)
                            throw new OverflowException("Input Overrun");
#endif
                        for (int x = 0; x < 4; ++x, ++lop, ++lip)//for (int x = 0; x < 4; ++x, ++op, ++ip)
                            dst[lop] = src[lip];//*op = *ip;
                        if (--t > 0)
                        {
                            if (t >= 4)
                            {
                                do
                                {
                                    for (int x = 0; x < 4; ++x, ++lop, ++lip)//for (int x = 0; x < 4; ++x, ++op, ++ip)
                                        dst[lop] = src[lip];//*op = *ip;
                                    t -= 4;
                                } while (t >= 4);
                                if (t > 0)
                                {
                                    do
                                    {
                                        dst[lop] = src[lip]; lop++; lip++; //WriteAndIncrement(dst, ReadAndIncrement(src, ref lip), ref lop);//*op++ = *ip++;
                                    } while (--t > 0);
                                }
                            }
                            else
                            {
                                do
                                {
                                    dst[lop] = src[lip]; lop++; lip++; //WriteAndIncrement(dst, ReadAndIncrement(src, ref lip), ref lop);//*op++ = *ip++;
                                } while (--t > 0);
                            }
                        }
                    }
                }
                if (!match && !match_next)
                {
                    first_literal_run = false;

                    t = src[lip]; lip++; //ReadAndIncrement(src, ref lip);// *ip++;
                    if (t >= 16)
                        match = true;
                    else
                    {
                        lpos = lop - (1 + M2_MAX_OFFSET);//pos = op - (1 + M2_MAX_OFFSET);
                        lpos -= t >> 2; //pos -= t >> 2;
                        lpos -= ((uint)src[lip]) << 2; //pos -= *ip++ << 2;
                        lip++;
#if BOUNDARY_CHECKS
                        if (lpos < 0 || lpos >= lop)//if (pos < output || pos >= op)
                            throw new OverflowException("Lookbehind Overrun");
                        if ((lop_end - lop) < 3)//if ((op_end - op) < 3)
                            throw new OverflowException("Output Overrun");
#endif
                        // read from dst?
                        dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;                            
                        dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                        dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                        match_done = true;
                    }
                }
                match = false;
                do
                {
                    if (t >= 64)
                    {
                        lpos = lop - 1;//pos = op - 1;
                        lpos -= (t >> 2) & 7; //pos -= (t >> 2) & 7;
                        lpos -= ((uint)src[lip]) << 3; //pos -= *ip++ << 3;
                        lip++;
                        t = (t >> 5) - 1;
#if BOUNDARY_CHECKS
                        if (lpos < 0 || lpos >= lop)//if (pos < output || pos >= op)
                            throw new OverflowException("Lookbehind Overrun");
                        if ((lop_end - lop) < t + 2)//if ((op_end - op) < t + 2)
                            throw new OverflowException("Output Overrun");
#endif
                        copy_match = true;
                    }
                    else if (t >= 32)
                    {
                        t &= 31;
                        if (t == 0)
                        {
#if BOUNDARY_CHECKS
                            if ((lip_end - lip) < 1)//if ((ip_end - ip) < 1)
                                throw new OverflowException("Input Overrun");
#endif
                            while (src[lip] == 0) //while (*ip == 0)
                            {
                                t += 255;
                                lip++;//++ip;
#if BOUNDARY_CHECKS
                                if ((lip_end - lip) < 1)//if ((ip_end - ip) < 1)
                                    throw new OverflowException("Input Overrun");
#endif
                            }
                            t += (uint)(31 + src[lip]);//t += (uint)(31 + *ip++);
                            lip++;
                        }
                        lpos = lop - 1;//pos = op - 1;
                        lpos -= (uint)GetUShortFrom2Bytes(src, lip) >> 2; //pos -= (*(ushort*)ip) >> 2;
                        lip += 2;//ip += 2;
                    }
                    else if (t >= 16)
                    {
                        lpos = lop;//pos = op;
                        lpos -= (t & 8) << 11;//pos -= (t & 8) << 11;

                        t &= 7;
                        if (t == 0)
                        {
#if BOUNDARY_CHECKS
                            if ((lip_end - lip) < 1)//if ((ip_end - ip) < 1)
                                throw new OverflowException("Input Overrun");
#endif
                            while (src[lip] == 0)//while (*ip == 0)
                            {
                                t += 255;
                                lip++;//++ip;
#if BOUNDARY_CHECKS
                                if ((lip_end - lip) < 1)//if ((ip_end - ip) < 1)
                                    throw new OverflowException("Input Overrun");
#endif
                            }
                            t += (uint)(7 + src[lip]);//t += (uint)(7 + *ip++);
                            lip++;
                        }
                        lpos -= (uint)GetUShortFrom2Bytes(src, lip) >> 2; //pos -= (*(ushort*)ip) >> 2;
                        lip += 2;//ip += 2;
                        if (lpos == lop)//if (pos == op)
                            eof_found = true;
                        else
                            lpos -= 0x4000;//pos -= 0x4000;
                    }
                    else
                    {
                        lpos = lop - 1;//pos = op - 1;
                        lpos -= t >> 2;//pos -= t >> 2;
                        lpos -= ((uint)src[lip]) << 2;//pos -= *ip++ << 2;
                        lip++;
#if BOUNDARY_CHECKS
                        if (lpos < 0 || lpos >= lop)//if (pos < output || pos >= op)
                            throw new OverflowException("Lookbehind Overrun");
                        if ((lop_end - lop) < 2)//if ((op_end - op) < 2)
                            throw new OverflowException("Output Overrun");
#endif
                        dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                        dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                        match_done = true;
                    }
                    if (!eof_found && !match_done && !copy_match)
                    {
#if BOUNDARY_CHECKS
                        if (lpos < 0 || lpos >= lop)//if (pos < output || pos >= op)
                            throw new OverflowException("Lookbehind Overrun");
                        Debug.Assert(t > 0);
                        if ((lop_end - lop) < t + 2)//if ((op_end - op) < t + 2)
                            throw new OverflowException("Output Overrun");
#endif
                    }
                    if (!eof_found && t >= 2 * 4 - 2 && (lop - lpos) >= 4 && !match_done && !copy_match)//if (!eof_found && t >= 2 * 4 - 2 && (op - pos) >= 4 && !match_done && !copy_match)
                    {
                        for (int x = 0; x < 4; ++x, ++lop, ++lpos)//for (int x = 0; x < 4; ++x, ++op, ++pos)
                            dst[lop] = dst[lpos];//*op = *pos;                           

                        t -= 2;
                        do
                        {
                            for (int x = 0; x < 4; ++x, ++lop, ++lpos)//for (int x = 0; x < 4; ++x, ++op, ++pos)
                                dst[lop] = dst[lpos];//*op = *pos;                           
                            t -= 4;
                        } while (t >= 4);
                        if (t > 0)
                        {
                            do
                            {
                                dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                            } while (--t > 0);
                        }
                    }
                    else if (!eof_found && !match_done)
                    {
                        copy_match = false;

                        dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                        dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                        do
                        {
                            dst[lop] = dst[lpos]; lop++; lpos++;//WriteAndIncrement(dst, ReadAndIncrement(dst, ref lpos), ref lop); //*op++ = *pos++;
                        } while (--t > 0);
                    }

                    if (!eof_found && !match_next)
                    {
                        match_done = false;

                        t = (uint)(src[lip - 2] & 3);//t = (uint)(ip[-2] & 3);
                        if (t == 0)
                            break;
                    }
                    if (!eof_found)
                    {
                        match_next = false;
#if BOUNDARY_CHECKS
                        Debug.Assert(t > 0);
                        Debug.Assert(t < 4);
                        if ((lop_end - lop) < t)//if ((op_end - op) < t)
                            throw new OverflowException("Output Overrun");
                        if ((lip_end - lip) < t + 1) //if ((ip_end - ip) < t + 1)
                            throw new OverflowException("Input Overrun");
#endif
                        dst[lop] = src[lip]; lop++; lip++; //WriteAndIncrement(dst, ReadAndIncrement(src, ref lip), ref lop);//*op++ = *ip++;
                        if (t > 1)
                        {
                            dst[lop] = src[lip]; lop++; lip++; //WriteAndIncrement(dst, ReadAndIncrement(src, ref lip), ref lop);//*op++ = *ip++;
                            if (t > 2)
                            {
                                dst[lop] = src[lip]; lop++; lip++; //WriteAndIncrement(dst, ReadAndIncrement(src, ref lip), ref lop);//*op++ = *ip++;
                            }
                        }
                        t = src[lip]; lip++;// ReadAndIncrement(src, ref lip);//t = *ip++;
                    }
                } while (!eof_found && lip < lip_end);//while (!eof_found && ip < ip_end);
            }
            if (!eof_found)
                throw new OverflowException("EOF Marker Not Found");
            else
            {
#if BOUNDARY_CHECKS
                Debug.Assert(t == 1);
                if (lip > lip_end)//if (ip > ip_end)
                    throw new OverflowException("Input Overrun");
                else if (lip < lip_end)//if (ip < ip_end)
                    throw new OverflowException("Input Not Consumed");
#endif
            }
            //}

            return dst;
        }

        private static uint Compress(byte[] src, uint srcstart, uint srcLength, byte[] dst, uint dststart, uint dstlen, uint[] dictNew)
        {
            // using all of dict_size?
            if (dictNew == null)
                dictNew = new uint[DICT_SIZE];

            uint tmp;
            if (srcLength <= M2_MAX_LEN + 5)
            {
                tmp = (uint)srcLength;
                dstlen = 0;
            }
            else
            {
                //fixed (byte* work = &workmem[workmemstart], input = &src[srcstart], output = &dst[dststart])
                //{
                uint lin_end = srcstart + srcLength;
                uint lip_end = srcstart + srcLength - M2_MAX_LEN - 5;
                //byte** dict = (byte**)work;
                //byte* in_end = input + srcLength;
                //byte* ip_end = input + srcLength - M2_MAX_LEN - 5;

                uint lii = srcstart;
                uint lip = srcstart + 4;
                uint lop = dststart;
                //byte* ii = input;
                //byte* ip = input + 4;
                //byte* op = output;

                bool literal = false;
                bool match = false;
                uint offset;
                uint length;
                uint index;
                //byte* pos;
                uint lpos;

                for (; ; )
                {
                    offset = 0;
                    index = D_INDEX1(src, lip);// index = D_INDEX1(ip);
                    lpos = lip - (lip - dictNew[index]);//pos = ip - (ip - dict[index]);

                    if (lpos < srcstart || (offset = (uint)(lip - lpos)) <= 0 || offset > M4_MAX_OFFSET) //if (pos < input || (offset = (uint)(ip - pos)) <= 0 || offset > M4_MAX_OFFSET)
                        literal = true;
                    else if (offset <= M2_MAX_OFFSET || src[lpos + 3] == src[lip + 3]) { } //if (offset <= M2_MAX_OFFSET || pos[3] == ip[3]) { }
                    else
                    {
                        index = D_INDEX2(index);
                        lpos = lip - (lip - dictNew[index]);//pos = ip - (ip - dict[index]);
                        if (lpos < srcstart || (offset = (uint)(lip - lpos)) <= 0 || offset > M4_MAX_OFFSET) //if (pos < input || (offset = (uint)(ip - pos)) <= 0 || offset > M4_MAX_OFFSET)
                            literal = true;
                        else if (offset <= M2_MAX_OFFSET || src[lpos + 3] == src[lip + 3]) { } //if (offset <= M2_MAX_OFFSET || pos[3] == ip[3]) { }
                        else
                            literal = true;
                    }

                    if (!literal)
                    {
                        if (GetUShortFrom2Bytes(src, lpos) == GetUShortFrom2Bytes(src, lip) && src[lpos + 2] == src[lip + 2])// if (*((ushort*)pos) == *((ushort*)ip) && pos[2] == ip[2])
                            match = true;
                    }

                    literal = false;
                    if (!match)
                    {
                        dictNew[index] = lip; //dict[index] = ip;
                        lip++;// ++ip;
                        if (lip >= lip_end) //if (ip >= ip_end)
                            break;
                        continue;
                    }
                    match = false;
                    dictNew[index] = lip;//dict[index] = ip;
                    if (lip - lii > 0)//if (ip - ii > 0)
                    {
                        uint t = (uint)(lip - lii);//uint t = (uint)(ip - ii);
                        if (t <= 3)
                        {
                            //Debug.Assert(op - 2 > output);
                            dst[lop - 2] |= (byte)(t);//op[-2] |= (byte)(t);
                        }
                        else if (t <= 18)
                        {
                            dst[lop] = (byte)(t - 3); lop++;//WriteAndIncrement(dst, (byte)(t - 3), ref lop);//*op++ = (byte)(t - 3);
                        }
                        else
                        {
                            uint tt = t - 18;
                            dst[lop] = 0; lop++;// WriteAndIncrement(dst, 0, ref lop);// *op++ = 0;
                            while (tt > 255)
                            {
                                tt -= 255;
                                dst[lop] = 0; lop++;// WriteAndIncrement(dst, 0, ref lop);// *op++ = 0;
                            }
                            Debug.Assert(tt > 0);
                            dst[lop] = (byte)(tt); lop++;//WriteAndIncrement(dst, (byte)(tt), ref lop);// *op++ = (byte)(tt);
                        }
                        do
                        {
                            dst[lop] = src[lii]; lop++; lii++;
                            //WriteAndIncrement(dst, src[lii], ref lop);
                            //lii++; //*op++ = *ii++;                                
                        } while (--t > 0);
                    }
                    Debug.Assert(lii == lip);//Debug.Assert(ii == ip);
                    lip += 3;// ip += 3;
                    if (src[lpos + 3] != src[lip++] ||
                        src[lpos + 4] != src[lip++] ||
                        src[lpos + 5] != src[lip++] ||
                        src[lpos + 6] != src[lip++] ||
                        src[lpos + 7] != src[lip++] ||
                        src[lpos + 8] != src[lip++])
                    //if (pos[3] != *ip++ || pos[4] != *ip++ || pos[5] != *ip++
                    //   || pos[6] != *ip++ || pos[7] != *ip++ || pos[8] != *ip++)
                    {
                        lip--;//--ip;
                        length = (uint)(lip - lii);//length = (uint)(ip - ii);
                        Debug.Assert(length >= 3);
                        Debug.Assert(length <= M2_MAX_LEN);
                        if (offset <= M2_MAX_OFFSET)
                        {
                            --offset;
                            dst[lop] = (byte)(((length - 1) << 5) | ((offset & 7) << 2));// *op++ = (byte)(((length - 1) << 5) | ((offset & 7) << 2));
                            lop++;
                            dst[lop] = (byte)(offset >> 3);//*op++ = (byte)(offset >> 3);
                            lop++;
                        }
                        else if (offset <= M3_MAX_OFFSET)
                        {
                            --offset;
                            dst[lop] = (byte)(M3_MARKER | (length - 2));// *op++ = (byte)(M3_MARKER | (length - 2));
                            lop++;
                            dst[lop] = (byte)((offset & 63) << 2); //* op++ = (byte)((offset & 63) << 2);
                            lop++;
                            dst[lop] = (byte)(offset >> 6);//*op++ = (byte)(offset >> 6);
                            lop++;
                        }
                        else
                        {
                            offset -= 0x4000;
                            Debug.Assert(offset > 0);
                            Debug.Assert(offset <= 0x7FFF);
                            dst[lop] = (byte)(M4_MARKER | ((offset & 0x4000) >> 11) | (length - 2));//*op++ = (byte)(M4_MARKER | ((offset & 0x4000) >> 11) | (length - 2));
                            lop++;
                            dst[lop] = (byte)((offset & 63) << 2);//*op++ = (byte)((offset & 63) << 2);
                            lop++;
                            dst[lop] = (byte)(offset >> 6);// *op++ = (byte)(offset >> 6);
                            lop++;
                        }
                    }
                    else
                    {
                        uint lm = lpos + M2_MAX_LEN + 1;//byte* m = pos + M2_MAX_LEN + 1;
                        while (lip < lin_end && src[lm] == src[lip])//while (ip < in_end && *m == *ip)
                        {
                            lm++;// ++m;
                            lip++;//++ip;
                        }
                        length = (uint)(lip - lii);//length = (uint)(ip - ii);
                        Debug.Assert(length > M2_MAX_LEN);
                        if (offset <= M3_MAX_OFFSET)
                        {
                            --offset;
                            if (length <= 33)
                            {
                                dst[lop] = (byte)(M3_MARKER | (length - 2)); lop++; //*op++ = (byte)(M3_MARKER | (length - 2));
                            }
                            else
                            {
                                length -= 33;
                                dst[lop] = M3_MARKER | 0; lop++;// *op++ = M3_MARKER | 0;
                                while (length > 255)
                                {
                                    length -= 255;
                                    dst[lop] = 0; lop++;//*op++ = 0;
                                }
                                Debug.Assert(length > 0);
                                dst[lop] = (byte)(length); lop++;
                                //WriteAndIncrement(dst, (byte)(length), ref lop);//*op++ = (byte)(length);
                            }
                        }
                        else
                        {
                            offset -= 0x4000;
                            Debug.Assert(offset > 0);
                            Debug.Assert(offset <= 0x7FFF);
                            if (length <= M4_MAX_LEN)
                            {
                                dst[lop] = (byte)(M4_MARKER | ((offset & 0x4000) >> 11) | (length - 2)); lop++;//*op++ = (byte)(M4_MARKER | ((offset & 0x4000) >> 11) | (length - 2));
                            }
                            else
                            {
                                length -= M4_MAX_LEN;
                                dst[lop] = (byte)(M4_MARKER | ((offset & 0x4000) >> 11)); lop++;//*op++ = (byte)(M4_MARKER | ((offset & 0x4000) >> 11));
                                while (length > 255)
                                {
                                    length -= 255;
                                    dst[lop] = 0; lop++;// WriteAndIncrement(dst, 0, ref lop);//*op++ = 0;
                                }
                                Debug.Assert(length > 0);
                                dst[lop] = (byte)(length); lop++;// *op++ = (byte)(length);
                            }
                        }
                        dst[lop] = (byte)((offset & 63) << 2); lop++;//*op++ = (byte)((offset & 63) << 2);
                        dst[lop] = (byte)(offset >> 6); lop++;// *op++ = (byte)(offset >> 6);
                    }
                    lii = lip;//ii = ip;
                    if (lip >= lip_end)//if (ip >= ip_end)
                        break;
                }
                dstlen = (uint)(lop - dststart);//dstlen = (uint)(op - output);
                tmp = (uint)(lin_end - lii);//tmp = (uint)(in_end - ii);
            }
            //}
            if (tmp > 0)
            {
                uint ii = (uint)srcLength - tmp + srcstart;
                if (dstlen == 0 && tmp <= 238)
                {
                    dst[dstlen++] = (byte)(17 + tmp);
                }
                else if (tmp <= 3)
                {
                    dst[dstlen - 2] |= (byte)(tmp);
                }
                else if (tmp <= 18)
                {
                    dst[dstlen++] = (byte)(tmp - 3);
                }
                else
                {
                    uint tt = tmp - 18;
                    dst[dstlen++] = 0;
                    while (tt > 255)
                    {
                        tt -= 255;
                        dst[dstlen++] = 0;
                    }
                    Debug.Assert(tt > 0);
                    dst[dstlen++] = (byte)(tt);
                }
                do
                {
                    dst[dstlen++] = src[ii++];
                } while (--tmp > 0);
            }
            dst[dstlen++] = M4_MARKER | 1;
            dst[dstlen++] = 0;
            dst[dstlen++] = 0;

            // Append the source count
            dst[dstlen++] = (byte)srcLength;
            dst[dstlen++] = (byte)(srcLength >> 8);
            dst[dstlen++] = (byte)(srcLength >> 16);
            dst[dstlen++] = (byte)(srcLength >> 24);

            return dstlen;
        }


#else
        private static unsafe uint Compress(byte[] src, uint srcstart, uint srcLength, byte[] dst, uint dststart, uint dstlen, byte[] workmem, uint workmemstart)
        {
            uint tmp;
            if (srcLength <= M2_MAX_LEN + 5)
            {
                tmp = (uint)srcLength;
                dstlen = 0;
            }
            else
            {
                fixed (byte* work = &workmem[workmemstart], input = &src[srcstart], output = &dst[dststart])
                {
                    byte** dict = (byte**)work;
                    byte* in_end = input + srcLength;
                    byte* ip_end = input + srcLength - M2_MAX_LEN - 5;
                    byte* ii = input;
                    byte* ip = input + 4;
                    byte* op = output;
                    bool literal = false;
                    bool match = false;
                    uint offset;
                    uint length;
                    uint index;
                    byte* pos;

                    for (; ; )
                    {
                        offset = 0;
                        index = D_INDEX1(ip);
                        pos = ip - (ip - dict[index]);
                        if (pos < input || (offset = (uint)(ip - pos)) <= 0 || offset > M4_MAX_OFFSET)
                            literal = true;
                        else if (offset <= M2_MAX_OFFSET || pos[3] == ip[3]) { }
                        else
                        {
                            index = D_INDEX2(index);
                            pos = ip - (ip - dict[index]);
                            if (pos < input || (offset = (uint)(ip - pos)) <= 0 || offset > M4_MAX_OFFSET)
                                literal = true;
                            else if (offset <= M2_MAX_OFFSET || pos[3] == ip[3]) { }
                            else
                                literal = true;
                        }

                        if (!literal)
                        {
                            if (*((ushort*)pos) == *((ushort*)ip) && pos[2] == ip[2])
                                match = true;
                        }

                        literal = false;
                        if (!match)
                        {
                            dict[index] = ip;
                            ++ip;
                            if (ip >= ip_end)
                                break;
                            continue;
                        }
                        match = false;
                        dict[index] = ip;
                        if (ip - ii > 0)
                        {
                            uint t = (uint)(ip - ii);
                            if (t <= 3)
                            {
                                Debug.Assert(op - 2 > output);
                                op[-2] |= (byte)(t);
                            }
                            else if (t <= 18)
                                *op++ = (byte)(t - 3);
                            else
                            {
                                uint tt = t - 18;
                                *op++ = 0;
                                while (tt > 255)
                                {
                                    tt -= 255;
                                    *op++ = 0;
                                }
                                Debug.Assert(tt > 0);
                                *op++ = (byte)(tt);
                            }
                            do
                            {
                                *op++ = *ii++;
                            } while (--t > 0);
                        }
                        Debug.Assert(ii == ip);
                        ip += 3;
                        if (pos[3] != *ip++ || pos[4] != *ip++ || pos[5] != *ip++
                           || pos[6] != *ip++ || pos[7] != *ip++ || pos[8] != *ip++)
                        {
                            --ip;
                            length = (uint)(ip - ii);
                            Debug.Assert(length >= 3);
                            Debug.Assert(length <= M2_MAX_LEN);
                            if (offset <= M2_MAX_OFFSET)
                            {
                                --offset;
                                *op++ = (byte)(((length - 1) << 5) | ((offset & 7) << 2));
                                *op++ = (byte)(offset >> 3);
                            }
                            else if (offset <= M3_MAX_OFFSET)
                            {
                                --offset;
                                *op++ = (byte)(M3_MARKER | (length - 2));
                                *op++ = (byte)((offset & 63) << 2);
                                *op++ = (byte)(offset >> 6);
                            }
                            else
                            {
                                offset -= 0x4000;
                                Debug.Assert(offset > 0);
                                Debug.Assert(offset <= 0x7FFF);
                                *op++ = (byte)(M4_MARKER | ((offset & 0x4000) >> 11) | (length - 2));
                                *op++ = (byte)((offset & 63) << 2);
                                *op++ = (byte)(offset >> 6);
                            }
                        }
                        else
                        {
                            byte* m = pos + M2_MAX_LEN + 1;
                            while (ip < in_end && *m == *ip)
                            {
                                ++m;
                                ++ip;
                            }
                            length = (uint)(ip - ii);
                            Debug.Assert(length > M2_MAX_LEN);
                            if (offset <= M3_MAX_OFFSET)
                            {
                                --offset;
                                if (length <= 33)
                                    *op++ = (byte)(M3_MARKER | (length - 2));
                                else
                                {
                                    length -= 33;
                                    *op++ = M3_MARKER | 0;
                                    while (length > 255)
                                    {
                                        length -= 255;
                                        *op++ = 0;
                                    }
                                    Debug.Assert(length > 0);
                                    *op++ = (byte)(length);
                                }
                            }
                            else
                            {
                                offset -= 0x4000;
                                Debug.Assert(offset > 0);
                                Debug.Assert(offset <= 0x7FFF);
                                if (length <= M4_MAX_LEN)
                                    *op++ = (byte)(M4_MARKER | ((offset & 0x4000) >> 11) | (length - 2));
                                else
                                {
                                    length -= M4_MAX_LEN;
                                    *op++ = (byte)(M4_MARKER | ((offset & 0x4000) >> 11));
                                    while (length > 255)
                                    {
                                        length -= 255;
                                        *op++ = 0;
                                    }
                                    Debug.Assert(length > 0);
                                    *op++ = (byte)(length);
                                }
                            }
                            *op++ = (byte)((offset & 63) << 2);
                            *op++ = (byte)(offset >> 6);
                        }
                        ii = ip;
                        if (ip >= ip_end)
                            break;
                    }
                    dstlen = (uint)(op - output);
                    tmp = (uint)(in_end - ii);
                }
            }
            if (tmp > 0)
            {
                uint ii = (uint)srcLength - tmp + srcstart;
                if (dstlen == 0 && tmp <= 238)
                {
                    dst[dstlen++] = (byte)(17 + tmp);
                }
                else if (tmp <= 3)
                {
                    dst[dstlen - 2] |= (byte)(tmp);
                }
                else if (tmp <= 18)
                {
                    dst[dstlen++] = (byte)(tmp - 3);
                }
                else
                {
                    uint tt = tmp - 18;
                    dst[dstlen++] = 0;
                    while (tt > 255)
                    {
                        tt -= 255;
                        dst[dstlen++] = 0;
                    }
                    Debug.Assert(tt > 0);
                    dst[dstlen++] = (byte)(tt);
                }
                do
                {
                    dst[dstlen++] = src[ii++];
                } while (--tmp > 0);
            }
            dst[dstlen++] = M4_MARKER | 1;
            dst[dstlen++] = 0;
            dst[dstlen++] = 0;

            // Append the source count
            dst[dstlen++] = (byte)srcLength;
            dst[dstlen++] = (byte)(srcLength >> 8);
            dst[dstlen++] = (byte)(srcLength >> 16);
            dst[dstlen++] = (byte)(srcLength >> 24);

            return dstlen;
        }

        public static unsafe byte[] Decompress(this byte[] src)
        {
            byte[] dst = new byte[(src[src.Length - 4] | (src[src.Length - 3] << 8) | (src[src.Length - 2] << 16 | src[src.Length - 1] << 24))];

            uint t = 0;
            fixed (byte* input = src, output = dst)
            {
                byte* pos = null;
                byte* ip_end = input + src.Length - 4;
                byte* op_end = output + dst.Length;
                byte* ip = input;
                byte* op = output;
                bool match = false;
                bool match_next = false;
                bool match_done = false;
                bool copy_match = false;
                bool first_literal_run = false;
                bool eof_found = false;

                if (*ip > 17)
                {
                    t = (uint)(*ip++ - 17);
                    if (t < 4)
                        match_next = true;
                    else
                    {
                        Debug.Assert(t > 0);
                        if ((op_end - op) < t)
                            throw new OverflowException("Output Overrun");
                        if ((ip_end - ip) < t + 1)
                            throw new OverflowException("Input Overrun");
                        do
                        {
                            *op++ = *ip++;
                        } while (--t > 0);
                        first_literal_run = true;
                    }
                }
                while (!eof_found && ip < ip_end)
                {
                    if (!match_next && !first_literal_run)
                    {
                        t = *ip++;
                        if (t >= 16)
                            match = true;
                        else
                        {
                            if (t == 0)
                            {
                                if ((ip_end - ip) < 1)
                                    throw new OverflowException("Input Overrun");
                                while (*ip == 0)
                                {
                                    t += 255;
                                    ++ip;
                                    if ((ip_end - ip) < 1)
                                        throw new OverflowException("Input Overrun");
                                }
                                t += (uint)(15 + *ip++);
                            }
                            Debug.Assert(t > 0);
                            if ((op_end - op) < t + 3)
                                throw new OverflowException("Output Overrun");
                            if ((ip_end - ip) < t + 4)
                                throw new OverflowException("Input Overrun");
                            for (int x = 0; x < 4; ++x, ++op, ++ip)
                                *op = *ip;
                            if (--t > 0)
                            {
                                if (t >= 4)
                                {
                                    do
                                    {
                                        for (int x = 0; x < 4; ++x, ++op, ++ip)
                                            *op = *ip;
                                        t -= 4;
                                    } while (t >= 4);
                                    if (t > 0)
                                    {
                                        do
                                        {
                                            *op++ = *ip++;
                                        } while (--t > 0);
                                    }
                                }
                                else
                                {
                                    do
                                    {
                                        *op++ = *ip++;
                                    } while (--t > 0);
                                }
                            }
                        }
                    }
                    if (!match && !match_next)
                    {
                        first_literal_run = false;

                        t = *ip++;
                        if (t >= 16)
                            match = true;
                        else
                        {
                            pos = op - (1 + M2_MAX_OFFSET);
                            pos -= t >> 2;
                            pos -= *ip++ << 2;
                            if (pos < output || pos >= op)
                                throw new OverflowException("Lookbehind Overrun");
                            if ((op_end - op) < 3)
                                throw new OverflowException("Output Overrun");
                            *op++ = *pos++;
                            *op++ = *pos++;
                            *op++ = *pos++;
                            match_done = true;
                        }
                    }
                    match = false;
                    do
                    {
                        if (t >= 64)
                        {
                            pos = op - 1;
                            pos -= (t >> 2) & 7;
                            pos -= *ip++ << 3;
                            t = (t >> 5) - 1;
                            if (pos < output || pos >= op)
                                throw new OverflowException("Lookbehind Overrun");
                            if ((op_end - op) < t + 2)
                                throw new OverflowException("Output Overrun");
                            copy_match = true;
                        }
                        else if (t >= 32)
                        {
                            t &= 31;
                            if (t == 0)
                            {
                                if ((ip_end - ip) < 1)
                                    throw new OverflowException("Input Overrun");
                                while (*ip == 0)
                                {
                                    t += 255;
                                    ++ip;
                                    if ((ip_end - ip) < 1)
                                        throw new OverflowException("Input Overrun");
                                }
                                t += (uint)(31 + *ip++);
                            }
                            pos = op - 1;
                            pos -= (*(ushort*)ip) >> 2;
                            ip += 2;
                        }
                        else if (t >= 16)
                        {
                            pos = op;
                            pos -= (t & 8) << 11;

                            t &= 7;
                            if (t == 0)
                            {
                                if ((ip_end - ip) < 1)
                                    throw new OverflowException("Input Overrun");
                                while (*ip == 0)
                                {
                                    t += 255;
                                    ++ip;
                                    if ((ip_end - ip) < 1)
                                        throw new OverflowException("Input Overrun");
                                }
                                t += (uint)(7 + *ip++);
                            }
                            pos -= (*(ushort*)ip) >> 2;
                            ip += 2;
                            if (pos == op)
                                eof_found = true;
                            else
                                pos -= 0x4000;
                        }
                        else
                        {
                            pos = op - 1;
                            pos -= t >> 2;
                            pos -= *ip++ << 2;
                            if (pos < output || pos >= op)
                                throw new OverflowException("Lookbehind Overrun");
                            if ((op_end - op) < 2)
                                throw new OverflowException("Output Overrun");
                            *op++ = *pos++;
                            *op++ = *pos++;
                            match_done = true;
                        }
                        if (!eof_found && !match_done && !copy_match)
                        {
                            if (pos < output || pos >= op)
                                throw new OverflowException("Lookbehind Overrun");
                            Debug.Assert(t > 0);
                            if ((op_end - op) < t + 2)
                                throw new OverflowException("Output Overrun");
                        }
                        if (!eof_found && t >= 2 * 4 - 2 && (op - pos) >= 4 && !match_done && !copy_match)
                        {
                            for (int x = 0; x < 4; ++x, ++op, ++pos)
                                *op = *pos;
                            t -= 2;
                            do
                            {
                                for (int x = 0; x < 4; ++x, ++op, ++pos)
                                    *op = *pos;
                                t -= 4;
                            } while (t >= 4);
                            if (t > 0)
                            {
                                do
                                {
                                    *op++ = *pos++;
                                } while (--t > 0);
                            }
                        }
                        else if (!eof_found && !match_done)
                        {
                            copy_match = false;

                            *op++ = *pos++;
                            *op++ = *pos++;
                            do
                            {
                                *op++ = *pos++;
                            } while (--t > 0);
                        }

                        if (!eof_found && !match_next)
                        {
                            match_done = false;

                            t = (uint)(ip[-2] & 3);
                            if (t == 0)
                                break;
                        }
                        if (!eof_found)
                        {
                            match_next = false;
                            Debug.Assert(t > 0);
                            Debug.Assert(t < 4);
                            if ((op_end - op) < t)
                                throw new OverflowException("Output Overrun");
                            if ((ip_end - ip) < t + 1)
                                throw new OverflowException("Input Overrun");
                            *op++ = *ip++;
                            if (t > 1)
                            {
                                *op++ = *ip++;
                                if (t > 2)
                                    *op++ = *ip++;
                            }
                            t = *ip++;
                        }
                    } while (!eof_found && ip < ip_end);
                }
                if (!eof_found)
                    throw new OverflowException("EOF Marker Not Found");
                else
                {
                    Debug.Assert(t == 1);
                    if (ip > ip_end)
                        throw new OverflowException("Input Overrun");
                    else if (ip < ip_end)
                        throw new OverflowException("Input Not Consumed");
                }
            }

            return dst;
        }
#endif

        private static uint D_INDEX1(byte[] src, int input)
        {
            return D_MS(D_MUL(0x21, D_X3(src, input, 5, 5, 6)) >> 5, 0);
        }

        private static uint D_INDEX1(byte[] src, uint input)
        {
            byte b2 = src[input + 2];
            byte b1 = src[input + 1];
            byte b0 = src[input];

            return D_MASK & ((0x21 *
                (
                ((uint)(((b2 << 6) ^ b1) << 5) ^ b0)
                << 5) ^ b0
                ) >> 5);

            //return D_MS((0x21* D_X3(src, input, 5, 5, 6)) >> 5, 0);
            //return D_MS(D_MUL(0x21, D_X3(src, input, 5, 5, 6)) >> 5, 0);
        }

        private static uint D_INDEX2(uint idx)
        {
            return (idx & (D_MASK & 0x7FF)) ^ (((D_MASK >> 1) + 1) | 0x1F);
        }

        private static uint D_MS(uint v, byte s)
        {
            return (v & (D_MASK >> s)) << s;
        }

        private static uint D_MUL(uint a, uint b)
        {
            return a * b;
        }

        private static uint D_X2(byte[] src, int input, byte s1, byte s2)
        {
            return (uint)((((src[input + 2] << s2) ^ src[input + 1]) << s1) ^ src[input]);
        }

        private static uint D_X3(byte[] src, int input, byte s1, byte s2, byte s3)
        {
            return (D_X2(src, input + 1, s2, s3) << s1) ^ src[input];
        }

        private static uint D_X2(byte[] src, uint input, byte s1, byte s2)
        {
            return (uint)((((src[input + 2] << s2) ^ src[input + 1]) << s1) ^ src[input]);
        }

        private static uint D_X3(byte[] src, uint input, byte s1, byte s2, byte s3)
        {
            return (D_X2(src, input + 1, s2, s3) << s1) ^ src[input];
        }

        //private unsafe static uint D_INDEX1(byte* input)
        //{
        //    return D_MS(D_MUL(0x21, D_X3(input, 5, 5, 6)) >> 5, 0);
        //}

        //private unsafe static uint D_X2(byte* input, byte s1, byte s2)
        //{
        //    return (uint)((((input[2] << s2) ^ input[1]) << s1) ^ input[0]);
        //}

        //private unsafe static uint D_X3(byte* input, byte s1, byte s2, byte s3)
        //{
        //    return (D_X2(input + 1, s2, s3) << s1) ^ input[0];
        //}


        //private static void WriteIntTo4Bytes(byte[] workmem, uint index, int ip)
        //{
        //    int ipCopy;
        //    byte b1, b2, b3, b4;
        //    ipCopy = ip;
        //    b1 = (byte)(ipCopy >> 24);
        //    ipCopy -= (ipCopy >> 24);
        //    b2 = (byte)(ipCopy >> 16);
        //    ipCopy -= (ipCopy >> 16);
        //    b3 = (byte)(ipCopy >> 8);
        //    ipCopy -= (ipCopy >> 8);
        //    b4 = (byte)ipCopy;
        //    workmem[index] = b1; //ip;
        //    workmem[index + 1] = b2; //ip;
        //    workmem[index + 2] = b3; //ip;
        //    workmem[index + 3] = b4; //ip;
        //}

        //private static int GetIntFrom4Bytes(byte[] workmem, uint index)
        //{
        //    int workmemval = (workmem[index] << 24) +
        //        (workmem[index + 1] << 16) +
        //        (workmem[index + 2] << 8) +
        //        (workmem[index + 3]);
        //    return workmemval;
        //}

        private static ushort GetUShortFrom2Bytes(byte[] workmem, uint index)
        {
            return (ushort)((workmem[index]) + (workmem[index + 1] * 256));
        }

        //private static void WriteAndIncrement(byte[] array, byte b, ref uint index)
        //{
        //    array[index] = b;
        //    index++;
        //}
        //private static byte ReadAndIncrement(byte[] array, ref uint index)
        //{
        //    byte b = array[index];
        //    index++;
        //    return b;
        //}
    }
}

//#endif