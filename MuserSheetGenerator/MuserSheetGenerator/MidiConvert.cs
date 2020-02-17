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
using System.Linq;
using System.Text;
//using Commons.Music.Midi;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace Muser.Sheets.Generator {
    class MidiConvert {
        public static Notes.Note[] Convert(string path, int[] trackIndexes) {
            var midiFile = MidiFile.Read(path);
            var tempoMap = midiFile.GetTempoMap();
            var tracks = midiFile.Chunks.OfType<TrackChunk>().ToList();
            var notes = new List<Notes.Note>();
            foreach (var trackIndex in trackIndexes) {
                var track = tracks[trackIndex];
                Console.WriteLine($"Track {trackIndex}---------------");
                var manager = track.GetNotes();
                foreach (var e in manager) {
                    ProcessNote(e, ref notes, ref tempoMap);
                }
            }
            return notes.ToArray();
        }

        internal static void ProcessNote(Melanchall.DryWetMidi.Interaction.Note e, ref List<Notes.Note> notes, ref TempoMap tempoMap) {
            double time = e.TimeAs<MetricTimeSpan>(tempoMap).TotalMicroseconds / 1000d;
            double length = e.LengthAs<MetricTimeSpan>(tempoMap).TotalMicroseconds / 1000d;
            int pitch = e.NoteNumber;
            Console.WriteLine($"Note {pitch} at {time}ms lasts {length}ms");
            bool success = NoteNumber.NumberSidePairs.TryGetValue(pitch, out Notes.NoteSide noteSide);
            noteSide = success ? noteSide : Notes.NoteSide.UNKNOWN;
            int centerIndex = NoteNumber.GetTrack(pitch);
            Console.WriteLine($"Corresponding Side: {noteSide}, Center: {centerIndex}");
            Notes.Note note = new Notes.NormalNote(time, 2000, length, centerIndex);
            notes.Add(note);
        }
    }
}
