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
using Muser.Sheets.Meta;
using System;
using System.Collections.Generic;
using System.Text;

namespace Muser.Sheets {
    /// <summary>
    /// The sheet
    /// </summary>
    public class Sheet {
        /// <summary>
        /// Meta of the sheet
        /// </summary>
        public Meta.SheetMeta Meta { get; set; }
        /// <summary>
        /// Notes of the sheet
        /// </summary>
        public Note.Note[] Notes { get; set; }
        /// <summary>
        /// Constructs the sheet
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="notes"></param>
        public Sheet(SheetMeta meta, Note.Note[] notes) {
            Meta = meta;
            Notes = notes;
        }
    }
}
