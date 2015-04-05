#region WatiN Copyright (C) 2006-2011 Jeroen van Menen

//Copyright 2006-2011 Jeroen van Menen
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

#endregion Copyright

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using mshtml;
using WatiN.Core.Native;
using WatiN.Core.Native.InternetExplorer;
using WatiN.Core.Native.Mozilla;
using WatiN.Core.Native.Windows;

namespace WatiN.Core.UtilityClasses
{
    /// <summary>
    /// This class contains functionality to capture an image from a web page and save it to a file.
    /// The code was written by Doug Weems at http://www.codeproject.com/KB/graphics/IECapture.aspx
    /// </summary>
    public class CaptureWebPage
    {
        private readonly DomContainer _domContainer;

        public CaptureWebPage(DomContainer domContainer)
        {
            _domContainer = domContainer;
        }

        /// <summary>
        /// Captures an image of the current page on the current browser via _domContainer to disk
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="writeUrl">Place the url text as an overlay on the screenshot.</param>
        /// <param name="showGuides">Draws guides on the image to show which part of the page is visible for different resolutions. Off by default</param>
        /// <param name="scalePercentage">Percentage for scaling, default is 100.</param>
        /// <param name="quality">
        /// 0-100 - The Quality category specifies the level of compression for an image. When used to construct an 
        /// EncoderParameter, the range of useful values for the quality category is from 0 to 100. The lower the number specified, 
        /// the higher the compression and therefore the lower the quality of the image. Zero would give you the lowest quality image and 
        /// 100 the highest.
        /// </param>
        public void CaptureWebPageToFile(string filename, bool writeUrl, bool showGuides, int scalePercentage, int quality)
        {
            if (string.IsNullOrEmpty(filename)) throw new ArgumentNullException(filename);

            var stream = CreateFileStream(filename);
            var imagetype = GetImagetype(filename);

            CaptureWebPageToFile(stream, imagetype, writeUrl, showGuides, scalePercentage, quality);
			
            stream.Flush();
            stream.Close();
        }

        internal virtual Stream CreateFileStream(string filename)
        {
        	return new FileStream(filename, FileMode.Create);
        }
        
        public enum ImageCodecs { Jpeg, Tiff, Gif, Png, Bmp }

        private static ImageCodecs GetImagetype(string filename)
        {
            var extension = Path.GetExtension(filename);
            var codec = ImageCodecs.Jpeg;
            switch (extension.Substring(1).ToLowerInvariant())
            {
                case "tif":
                case "tiff":
                    codec = ImageCodecs.Tiff;
                    break;
                case "gif":
                    codec = ImageCodecs.Gif;
                    break;
                case "png":
                    codec = ImageCodecs.Png;
                    break;
                case "bmp":
                    codec = ImageCodecs.Bmp;
                    break;
            }
            return codec;
        }

        public virtual void CaptureWebPageToFile(Stream stream, ImageCodecs imagetype, bool writeUrl, bool showGuides, int scalePercentage, int quality)
        {
            var finalImage = CaptureWebPageImage(writeUrl, showGuides, scalePercentage);
            var eps = GetEncoderParams(quality);
            var ici = GetCodec(imagetype);

            SaveImage(finalImage, stream, ici, eps);
        }

        protected virtual void SaveImage(System.Drawing.Image finalImage, Stream stream, ImageCodecInfo ici, EncoderParameters eps)
        {
            finalImage.Save(stream, ici, eps);
        }

        public System.Drawing.Image CaptureWebPageImage(bool writeUrl, bool showGuides, int scalePercentage)
        {
            return CaptureWebPageImage2(_domContainer.hWnd, _domContainer, writeUrl, showGuides, scalePercentage);
        }

        private static System.Drawing.Image CaptureWebPageImage2(IntPtr browserHWND, Document myDoc, bool writeUrl, bool showGuides, int scalePercentage)
        {
            var isIE = myDoc.NativeDocument as IEDocument != null;

            //URL Location
            var URLExtraHeight = 0;
            var URLExtraLeft = 0;

            //Adjustment variable for capture size.
            if (writeUrl)
            {
                URLExtraHeight = 25;
            }

            //TrimHeight and TrimLeft trims off some captured IE graphics.
            var trimHeight = isIE ? 3: 0;
            var trimLeft = isIE ? 3: 0;

            //Use UrlExtra height to carry trimHeight.
            URLExtraHeight = URLExtraHeight - trimHeight;
            URLExtraLeft = URLExtraLeft - trimLeft;

            setDocumentAttribute(myDoc, "scroll", "yes");

            //Get Browser Window Height
            var heightsize = (int) getDocumentAttribute(myDoc, "scrollHeight");
            var widthsize = (int) getDocumentAttribute(myDoc, "scrollWidth");

            //Get Screen Height
            var screenHeight = (int) getDocumentAttribute(myDoc, "clientHeight");
            var screenWidth = (int) getDocumentAttribute(myDoc, "clientWidth");

            //Get bitmap to hold screen fragment.
            var bm = new Bitmap(screenWidth, screenHeight, PixelFormat.Format48bppRgb);

            //Create a target bitmap to draw into.
            var bm2 = new Bitmap(widthsize + URLExtraLeft - trimLeft, heightsize + URLExtraHeight - trimHeight, PixelFormat.Format16bppRgb555);
            var g2 = Graphics.FromImage(bm2);

            //Get inner browser window.
            var hwnd = browserHWND;
            if (isIE)
            {
                hwnd = GetHwndContainingAShellDocObjectView(browserHWND);
                hwnd = GetHwndForInternetExplorerServer(hwnd);
            }
            else
            {
                hwnd = NativeMethods.FindWindowEx(hwnd, IntPtr.Zero, "MozillaWindowClass", IntPtr.Zero);
                hwnd = NativeMethods.FindWindowEx(hwnd, IntPtr.Zero, "MozillaContentWindowClass", IntPtr.Zero);
            }

            var myPage = 0;

            //Get Screen Height (for bottom up screen drawing)
            while ((myPage*screenHeight) < heightsize)
            {
                setDocumentAttribute(myDoc, "scrollTop", (screenHeight)*myPage);
//                setDocumentAttribute(myDoc, "scrollTop", (screenHeight - 5)*myPage);
                myPage++;
            }
            //Rollback the page count by one
            myPage--;

            var myPageWidth = 0;

            while ((myPageWidth*screenWidth) < widthsize)
            {
                if (isIE)
                    setDocumentAttribute(myDoc, "scrollLeft", (screenWidth - 5)*myPageWidth);
                else
                    setDocumentAttribute(myDoc, "scrollLeft", (screenWidth)*myPageWidth);
                
                var brwLeft = (int) getDocumentAttribute(myDoc, "scrollLeft");

                for (var i = myPage; i >= 0; --i)
                {
                    //Shoot visible window
                    var g = Graphics.FromImage(bm);
                    var hdc = g.GetHdc();

                    if (isIE)
                        setDocumentAttribute(myDoc, "scrollTop", (screenHeight -2)*i);
                    else
                        setDocumentAttribute(myDoc, "scrollTop", (screenHeight) * i);
                    var brwTop = (int) getDocumentAttribute(myDoc, "scrollTop");

                    NativeMethods.PrintWindow(hwnd, hdc, 0);

                    // Original code
                    g.ReleaseHdc(hdc);
                    g.Flush();
                    g.Dispose();

                    var hBitmap = bm.GetHbitmap();
                    System.Drawing.Image screenfrag = System.Drawing.Image.FromHbitmap(hBitmap);

                    NativeMethods.DeleteObject(hBitmap);

                    if (isIE)
                    {
                        var realArea = new Rectangle(3, 0, screenfrag.Width - 3, screenfrag.Height);
                        g2.DrawImage(screenfrag, brwLeft + URLExtraLeft, brwTop + URLExtraHeight, realArea, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        g2.DrawImage(screenfrag, brwLeft + URLExtraLeft, brwTop + URLExtraHeight);
                    }
                }
                ++myPageWidth;
            }

            //Draw Standard Resolution Guides
            if (showGuides)
            {
                DrawResolutionGuidesOnImage(g2, URLExtraHeight, URLExtraLeft);
            }

            //Write URL
            if (writeUrl)
            {
                WriteUrlOnImage(g2, myDoc.Url, URLExtraHeight, widthsize);
            }

            //scale image
            var myResolution = Convert.ToDouble(scalePercentage)*0.01;
            var finalWidth = (int) ((widthsize + URLExtraLeft)*myResolution);
            var finalHeight = (int) ((heightsize + URLExtraHeight)*myResolution);

            var finalImage = new Bitmap(finalWidth, finalHeight, PixelFormat.Format16bppRgb555);
            var gFinal = Graphics.FromImage(finalImage);
            gFinal.DrawImage(bm2, 0, 0, finalWidth, finalHeight);

            //Clean Up.
            g2.Dispose();
            gFinal.Dispose();
            bm.Dispose();
            bm2.Dispose();

            return finalImage;
        }

        private static IntPtr GetHwndContainingAShellDocObjectView(IntPtr browserHWND)
        {
            // If window is a HtmlDialog then return.
            var hwnd = browserHWND;
            if (NativeMethods.CompareClassNames(hwnd, "Internet Explorer_TridentDlgFrame"))
            {
                return hwnd;
            }

            // In IE6 and previous, the handle points to a WorkerW window that is a 
            // sibling of the "Document" window (Shell DocObject View) and we can go find
            // it. 
            // In IE7, the handle now points at an intermediate layer at a sibling of the
            // TabWindowClass window which is the parent of the "Document" window. Loop
            // through these siblings to find that TabWindowClass and then drop down to
            // its children.
            hwnd = NativeMethods.GetWindow(hwnd, NativeMethods.GW_CHILD);

            if (!NativeMethods.CompareClassNames(hwnd,"WorkerW")) // IE 7 or 8
            {
                while (hwnd != IntPtr.Zero)
                {
                    if (NativeMethods.CompareClassNames(hwnd, "TabWindowClass"))
                    {
                        break;
                    }
					// In IE8, TabWindowClass now belongs as a child class of "Frame Tab"
					// so step down into Frame Tab and continue start searching for 
					// TabWindowClass there.
                    if (NativeMethods.CompareClassNames(hwnd, "Frame Tab")) // IE 8
					{
						//step one deeper for IE 8
						hwnd = NativeMethods.GetWindow(hwnd, NativeMethods.GW_CHILD);
					}
					else
					{
						hwnd = NativeMethods.GetWindow(hwnd, NativeMethods.GW_HWNDNEXT);
					}
                }
                hwnd = NativeMethods.GetWindow(hwnd, NativeMethods.GW_CHILD);
            }
            return hwnd;
        }

        private static IntPtr GetHwndForInternetExplorerServer(IntPtr hwnd)
        {
            //Get Browser "Document" Handle
            while (hwnd != IntPtr.Zero)
            {
                if (NativeMethods.CompareClassNames(hwnd, "Shell DocObject View") ||
                    NativeMethods.CompareClassNames(hwnd, "Internet Explorer_TridentDlgFrame"))
                {
                    hwnd = NativeMethods.FindWindowEx(hwnd, IntPtr.Zero, "Internet Explorer_Server", IntPtr.Zero);
                    break;
                }
                hwnd = NativeMethods.GetWindow(hwnd, NativeMethods.GW_HWNDNEXT);
            }
            return hwnd;
        }

        private static void DrawResolutionGuidesOnImage(Graphics g2, int URLExtraHeight, int URLExtraLeft)
        {
            // Create pen.
            var myWidth = 1;
            var myPen = new Pen(Color.Navy, myWidth);

            // Create coordinates of points that define line.
            var x1 = -(float) myWidth - 1 + URLExtraLeft;
            var y1 = -(float) myWidth - 1 + URLExtraHeight;

            var x600 = 600.0F + myWidth + 1;
            var y480 = 480.0F + myWidth + 1;

            var x2 = 800.0F + myWidth + 1;
            var y2 = 600.0F + myWidth + 1;

            var x3 = 1024.0F + myWidth + 1;
            var y3 = 768.0F + myWidth + 1;

            var x1280 = 1280.0F + myWidth + 1;
            var y1024 = 1024.0F + myWidth + 1;

            // Draw line to screen.
            g2.DrawRectangle(myPen, x1, y1, x600 + myWidth, y480 + myWidth);
            g2.DrawRectangle(myPen, x1, y1, x2 + myWidth, y2 + myWidth);
            g2.DrawRectangle(myPen, x1, y1, x3 + myWidth, y3 + myWidth);
            g2.DrawRectangle(myPen, x1, y1, x1280 + myWidth, y1024 + myWidth);

            // Create font and brush.
            var drawFont = new Font("Arial", 12);
            var drawBrush = new SolidBrush(Color.Navy);

            // Set format of string.
            var drawFormat = new StringFormat {FormatFlags = StringFormatFlags.FitBlackBox};

            // Draw string to screen.
            g2.DrawString("600 x 480", drawFont, drawBrush, 5, y480 - 20 + URLExtraHeight, drawFormat);
            g2.DrawString("800 x 600", drawFont, drawBrush, 5, y2 - 20 + URLExtraHeight, drawFormat);
            g2.DrawString("1024 x 768", drawFont, drawBrush, 5, y3 - 20 + URLExtraHeight, drawFormat);
            g2.DrawString("1280 x 1024", drawFont, drawBrush, 5, y1024 - 20 + URLExtraHeight, drawFormat);
        }

        private static void WriteUrlOnImage(Graphics g2, string myLocalLink, int URLExtraHeight, int widthsize)
        {
            // Backfill URL paint location
            var whiteBrush = new SolidBrush(Color.White);
            var fillRect = new Rectangle(0, 0, widthsize, URLExtraHeight + 2);
            var fillRegion = new Region(fillRect);
            g2.FillRegion(whiteBrush, fillRegion);

            var drawBrushURL = new SolidBrush(Color.Black);
            var drawFont = new Font("Arial", 12);
            var drawFormat = new StringFormat {FormatFlags = StringFormatFlags.FitBlackBox};

            g2.DrawString(myLocalLink, drawFont, drawBrushURL, 0, 0, drawFormat);
        }

        private static EncoderParameters GetEncoderParams(int quality)
        {
            var eps = new EncoderParameters(1);
            var myQuality = Convert.ToInt64(quality);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, myQuality);
            return eps;
        }


        private static ImageCodecInfo GetCodec(ImageCodecs imagetype)
        {
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");

            switch (imagetype)
            {
                case ImageCodecs.Jpeg:
                    ici = GetEncoderInfo("image/jpeg");
                    break;
                case ImageCodecs.Tiff:
                    ici = GetEncoderInfo("image/tiff");
                    break;
                case ImageCodecs.Gif:
                    ici = GetEncoderInfo("image/gif");
                    break;
                case ImageCodecs.Png:
                    ici = GetEncoderInfo("image/png");
                    break;
                case ImageCodecs.Bmp:
                    ici = GetEncoderInfo("image/bmp");
                    break;
            }

            return ici;
        }

        private static object getDocumentAttribute(Document document, string theAttributeName)
        {
            if (document.NativeDocument as IEDocument != null)
            {
                var doc = getDocumentElement(((IEDocument)document.NativeDocument).HtmlDocument);
                return doc.getAttribute(theAttributeName, 0);
            }
            
            var ffDocument = (FFDocument) document.NativeDocument;
            var code = ffDocument.JavaScriptVariableName + ".body." + theAttributeName;

            var results = document.Eval(code);
            return int.Parse(results);
        }

        private static object getDocumentAttribute(IHTMLDocument2 theHTMLDocument, string theAttributeName)
        {
            var doc = getDocumentElement(theHTMLDocument);
            return doc.getAttribute(theAttributeName, 0);
        }

        private static void setDocumentAttribute(Document document, string theAttributeName,
                                                 object theAttributeValue)
        {
            if (document.NativeDocument as IEDocument != null)
            {
                var doc = getDocumentElement(((IEDocument) document.NativeDocument).HtmlDocument);
                doc.setAttribute(theAttributeName, theAttributeValue, 0);
            }
            else
            {
                var ffDocument = (FFDocument)document.NativeDocument;
                var code = ffDocument.JavaScriptVariableName + ".body." + theAttributeName + "='" + theAttributeValue +"'";

                document.RunScript(code);
            }
        }

        private static void setDocumentAttribute(IHTMLDocument2 theHTMLDocument, string theAttributeName,
                                                 object theAttributeValue)
        {
            var doc = getDocumentElement(theHTMLDocument);
            doc.setAttribute(theAttributeName, theAttributeValue, 0);
        }

        private static IHTMLElement getDocumentElement(IHTMLDocument2 theHTMLDocument)
        {
            var doc5 = (IHTMLDocument5) theHTMLDocument;
            var doc3 = (IHTMLDocument3) theHTMLDocument;
			
            //compatibility mode affects how height is computed
            if ((doc3.documentElement != null) && (!doc5.compatMode.Equals("BackCompat")))
                return doc3.documentElement;

            return theHTMLDocument.body;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();
            for (var j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType) return encoders[j];
            }
            return null;
        }
    }
}
