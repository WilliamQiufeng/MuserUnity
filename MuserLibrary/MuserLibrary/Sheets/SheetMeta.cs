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
using System.Text;

namespace Muser.Sheets.Meta {
    /// <summary>
    /// Represents the meta of the sheet
    /// </summary>
    public class SheetMeta {
        /// <summary>
        /// Author of the sheet
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// The name of the sheet
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Where the music is
        /// </summary>
        public string MusicPath { get; set; }
        /// <summary>
        /// The author of the music
        /// </summary>
        public string MusicAuthor { get; set; }
        /// <summary>
        /// Decides when to start the music
        /// </summary>
        public double StartOffset { get; set; }
        /// <summary>
        /// The name of the hardness of this level
        /// </summary>
        public string HardnessName { get; set; }
        /// <summary>
        /// The level of this level
        /// </summary>
        public int HardnessLevel { get; set; }
        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <param name="musicPath"></param>
        /// <param name="musicAuthor"></param>
        /// <param name="startOffset"></param>
        /// <param name="hardnessName"></param>
        /// <param name="hardnessLevel"></param>
        public SheetMeta(string author, string name, string musicPath, string musicAuthor, double startOffset, string hardnessName = "normal", int hardnessLevel = 4) {
            Author = author;
            Name = name;
            MusicPath = musicPath;
            MusicAuthor = musicAuthor;
            StartOffset = startOffset;
            HardnessName = hardnessName;
            HardnessLevel = hardnessLevel;
        }
    }
}
