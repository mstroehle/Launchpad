//
//  Utilities.cs
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
using Launchpad.Launcher.Utility.Enums;

namespace Launchpad.Launcher.Utility
{
	internal static class Utilities
	{
		/// <summary>
		/// Clean the specified input.
		/// </summary>
		/// <param name="input">Input.</param>
		public static string Clean(string input)
		{
			string output = "";

			output = input.Replace("\n", String.Empty).Replace("\0", String.Empty).Replace("\r", String.Empty);

			return output;
		}

		public static ESystemTarget ParseSystemTarget(string input)
		{
			ESystemTarget Target = ESystemTarget.Invalid;
			try
			{
				Target = (ESystemTarget)Enum.Parse(typeof(ESystemTarget), input);
			}
			catch (ArgumentNullException anex)
			{ 
				Console.WriteLine("ArgumentNullException in ParseSystemTarget(): " + anex.Message);
			}
			catch (ArgumentException aex)
			{
				Console.WriteLine("ArgumentException in ParseSystemTarget(): " + aex.Message);
			}
			catch (OverflowException oex)
			{
				Console.WriteLine("OverflowException in ParseSystemTarget(): " + oex.Message);
			}

			return Target;
		}
	}
}
