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
using System.IO;
using Newtonsoft.Json;

namespace Muser.Sheets.Generator {
    class SheetGroup {
        readonly string path;

        public SheetGroup(string path) {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public void Process() {
            var sheets = Directory.GetFiles(path, "*.sheetmeta");
            foreach(var sheet in sheets) {
                var reader = new MetaReader(sheet);
                reader.Read();
                reader.Parse();
                var sheetStr = JsonConvert.SerializeObject(reader.OutputSheet);
                var sheetBytes = Encoding.Default.GetBytes(sheetStr);
                var fileOut = new FileStream(reader.Meta.OutputSheet, FileMode.OpenOrCreate, FileAccess.Write);
                
                fileOut.Write(sheetBytes, 0, sheetBytes.Length);
                fileOut.Close();
                fileOut.Dispose();
            }
        }
    }
}
