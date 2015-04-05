using System;
using System.IO;

namespace EPocalipse.IFilter
{
	/// <summary>
	/// 	Implements a TextReader that reads from an IFilter.
	/// </summary>
	public class FilterReader : TextReader
	{
		#region Readonly & Static Fields

		private readonly FilterWrapper m_Filter;

		#endregion

		#region Fields

		private char[] _charsLeftFromLastRead;
		private STAT_CHUNK _currentChunk;
		private bool _currentChunkValid;
		private bool _done;

		#endregion

		#region Constructors

		public FilterReader(string fileName)
		{
			m_Filter = FilterLoader.LoadAndInitIFilter(fileName);
			if (m_Filter == null)
			{
				throw new ArgumentException(string.Format("no filter defined for {0}", fileName));
			}
		}

		#endregion

		#region Instance Methods

		public override void Close()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public override int Read(char[] array, int offset, int count)
		{
			int endOfChunksCount = 0;
			int charsRead = 0;

			while (!_done && charsRead < count)
			{
				if (_charsLeftFromLastRead != null)
				{
					int charsToCopy = (_charsLeftFromLastRead.Length < count - charsRead)
						? _charsLeftFromLastRead.Length
						: count - charsRead;
					Array.Copy(_charsLeftFromLastRead, 0, array, offset + charsRead, charsToCopy);
					charsRead += charsToCopy;
					if (charsToCopy < _charsLeftFromLastRead.Length)
					{
						char[] tmp = new char[_charsLeftFromLastRead.Length - charsToCopy];
						Array.Copy(_charsLeftFromLastRead, charsToCopy, tmp, 0, tmp.Length);
						_charsLeftFromLastRead = tmp;
					}
					else
					{
						_charsLeftFromLastRead = null;
					}
					continue;
				}

				if (!_currentChunkValid)
				{
					IFilterReturnCode res = m_Filter.Filter.GetChunk(out _currentChunk);
					_currentChunkValid = (res == IFilterReturnCode.S_OK) && ((_currentChunk.flags & CHUNKSTATE.CHUNK_TEXT) != 0);

					if (res == IFilterReturnCode.FILTER_E_END_OF_CHUNKS)
					{
						endOfChunksCount++;
					}

					if (endOfChunksCount > 1)
					{
						_done = true; //That's it. no more chuncks available
					}
				}

				if (_currentChunkValid)
				{
					uint bufLength = (uint) (count - charsRead);
					if (bufLength < 8192)
					{
						bufLength = 8192; //Read ahead
					}

					char[] buffer = new char[bufLength];
					IFilterReturnCode res = m_Filter.Filter.GetText(ref bufLength, buffer);
					if (res == IFilterReturnCode.S_OK || res == IFilterReturnCode.FILTER_S_LAST_TEXT)
					{
						int cRead = (int) bufLength;
						if (cRead + charsRead > count)
						{
							int charsLeft = (cRead + charsRead - count);
							_charsLeftFromLastRead = new char[charsLeft];
							Array.Copy(buffer, cRead - charsLeft, _charsLeftFromLastRead, 0, charsLeft);
							cRead -= charsLeft;
						}
						else
						{
							_charsLeftFromLastRead = null;
						}

						Array.Copy(buffer, 0, array, offset + charsRead, cRead);
						charsRead += cRead;
					}

					if (res == IFilterReturnCode.FILTER_S_LAST_TEXT || res == IFilterReturnCode.FILTER_E_NO_MORE_TEXT)
					{
						_currentChunkValid = false;
					}
				}
			}
			return charsRead;
		}

		protected override void Dispose(bool disposing)
		{
			m_Filter.Dispose();
		}

		#endregion
	}
}