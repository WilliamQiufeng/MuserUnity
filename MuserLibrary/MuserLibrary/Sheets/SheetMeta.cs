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
