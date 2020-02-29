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
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace Muser.Sheets.Generator {
    class Program {
        static void Main(string[] args) {
            string pathToFind = Path.GetFullPath(Path.Combine("..", "..", "..", "..", "..", "Muser", "Assets", "DefaultSheets"));
            Console.WriteLine($"Find sheet groups in path: {pathToFind}");
            string[] sheetList = Directory.GetDirectories(pathToFind);
            foreach(string sheetGroupPath in sheetList) {
                SheetGroup group = new SheetGroup(sheetGroupPath);
                group.Process();
                /*
                MetaReader reader = new MetaReader(path);
                reader.Read();
                reader.Parse();
                Console.WriteLine(path);
                Console.WriteLine(JsonConvert.SerializeObject(reader.Meta));
                MidiConvert.Convert(reader.Meta.MidiFile, new int[] { 2 }, Path.Combine("..", "..", "..", "..", "..", "Muser", "Assets", "DefaultSheets"));
                */
            }
        }
    }
}
