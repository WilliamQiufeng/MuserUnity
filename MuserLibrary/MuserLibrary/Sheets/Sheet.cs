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
