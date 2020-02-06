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
