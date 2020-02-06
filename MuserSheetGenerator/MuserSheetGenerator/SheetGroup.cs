using System;
using System.Collections.Generic;
using System.Text;

namespace Muser.Sheets.Generator {
    class SheetGroup {
        string path;
        public void process() {
            System.IO.Directory.GetFiles(path, "*.sheetmeta");
        }
    }
}
