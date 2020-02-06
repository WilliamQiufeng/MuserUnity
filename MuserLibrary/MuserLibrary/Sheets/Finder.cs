//   MuserLibrary
//   Copyright (C) 2020  Ye William
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <https://www.gnu.org/licenses/>.
//
using System;
using System.Collections.Generic;
using System.IO;

namespace Muser.Sheets {
    /// <summary>
    /// Finds sheets with given extension
    /// </summary>
    public class Finder {
        public static string[] find(string[] paths, string extension, SearchOption option = SearchOption.TopDirectoryOnly) {
            var res = new List<string>();
            foreach(string path in paths) {
                res.AddRange(Directory.GetFiles(path, extension, option));
            }
            return res.ToArray();
        }
    }
}
