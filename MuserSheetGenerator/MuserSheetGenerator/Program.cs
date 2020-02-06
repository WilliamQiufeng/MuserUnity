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
using Newtonsoft.Json;

namespace Muser.Sheets.Generator {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            Sheet sheet = new Sheet(
                new Sheets.Meta.SheetMeta("Qiufeng54321", "Test", "lol", "muau", 1000),
                new Note.Note[]{
                    new Note.NormalNote(100, 10, 301)
                });
            Console.WriteLine(JsonConvert.SerializeObject(sheet));
            string[] metasheets = Sheets.Finder.find(new string[] { "C:\\Users\\willi\\source\\repos\\Muser\\Muser\\Assets\\DefaultSheets" }, "*.sheetmeta", System.IO.SearchOption.AllDirectories);
            foreach(string path in metasheets) {
                MetaReader reader = new MetaReader(path);
                reader.read();
                reader.parse();
                Console.WriteLine(path);
                Console.WriteLine(JsonConvert.SerializeObject(reader.Meta));
                MidiConvert.convert(reader.Meta.MidiFile, new int[] { 2 });
            }
        }
    }
}
