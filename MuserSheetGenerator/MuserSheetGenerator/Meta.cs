using System;
using System.Collections.Generic;
using System.Text;

namespace Muser.Sheets.Generator {
    class Meta {
        /// <summary>
        /// The output sheet meta will contain this info
        /// </summary>
        public Sheets.Meta.SheetMeta SheetMeta { get; set; }
        /// <summary>
        /// Path of the midi file
        /// </summary>
        public string MidiFile { get; set; }
        /// <summary>
        /// Path to the output sheet
        /// </summary>
        public string OutputSheet { get; set; }
    }
}
