//   MuserSheetGenerator
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
using System.Resources;
using Muser.Util;

namespace Muser.Sheets.Generator {
    /// <summary>
    /// Defines the relationship between note side and note number
    /// </summary>
    public static class NoteNumber {
        /// <summary>
        /// A dictionary which shows what note numbers belong to a side
        /// </summary>
        public static readonly Dictionary<Notes.NoteSide, int[]> SideNumberPairs = new Dictionary<Notes.NoteSide, int[]>();
        /// <summary>
        /// A dictionary which shows what the corresponding side a note number should have
        /// </summary>
        public static readonly Dictionary<int, Notes.NoteSide> NumberSidePairs = new Dictionary<int, Notes.NoteSide>();
        static NoteNumber() {
            var enumValues = Enum.GetValues(typeof(Notes.NoteSide));
            for (int i = 0; i < 4; i++) {
                var val = (Notes.NoteSide)enumValues.GetValue(i);
                SideNumberPairs.Add(val, new int[] { 60 + i, 72 + i});
                NumberSidePairs.Add(60 + i, val);
                NumberSidePairs.Add(72 + i, val);
            }
            Console.WriteLine($"SideNumberPairs: {SideNumberPairs.ToDebugString()}");
            Console.WriteLine($"NumberSidePairs: {NumberSidePairs.ToDebugString()}");
        }
        /// <summary>
        /// Returns which corresponding track the given number should make the note be at.
        /// </summary>
        /// <param name="number">the number of the note</param>
        /// <returns></returns>
        public static int GetTrack(int number) {
            return number >= 72 ? 1 : 0;
        }
    }
}
