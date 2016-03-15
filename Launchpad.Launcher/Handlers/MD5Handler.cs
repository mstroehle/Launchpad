﻿//
//  MD5Handler.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2016 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Security.Cryptography;

namespace Launchpad.Launcher.Handlers
{
	/// <summary>
	/// MD5 hashing handler. Used to ensure file integrity.
	/// </summary>
	internal static class MD5Handler
	{
		/// <summary>
		/// Gets the file hash from a file stream.
		/// </summary>
		/// <returns>The file hash.</returns>
		/// <param name="fileStream">File stream.</param>
		public static string GetFileHash(Stream fileStream)
		{
			if (fileStream != null)
			{
				try
				{
					using (MD5 md5 = MD5.Create())
					{
						//calculate the hash of the stream.
						string resultString = BitConverter.ToString(md5.ComputeHash(fileStream)).Replace("-", "");

						return resultString;
					}
				}
				catch (IOException ioex)
				{
					Console.WriteLine("IOException in GetFileHash(): " + ioex.Message);

					return String.Empty;
				}
				finally
				{
					//release the file (if we had one)
					fileStream.Close();
				}
			}
			else
			{ 
				return String.Empty;
			}
		}
	}
}