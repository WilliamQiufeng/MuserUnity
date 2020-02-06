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
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Muser.Sheets.Generator {
    class MidiDiagonistics {
        static void Main(string[] args) {
            if (args.Length >= 1) {
                var midiFile = MidiFile.Read(args[0]);
                var tempoMap = midiFile.GetTempoMap();
                foreach (var track in midiFile.Chunks.OfType<TrackChunk>()) {
                    Console.WriteLine($"Track {track.ChunkId}---------------");
                    var manager = track.GetTimedEvents();
                    //TimedEventsCollection events = manager.Events;

                    foreach (var e in manager) {
                        Console.WriteLine($"{e.Event.GetType().Name}: {e.TimeAs<MetricTimeSpan>(tempoMap).TotalMicroseconds / 1000.0}ms, {e.ToString()}");
                    }
                }
            } else {
                Console.Error.WriteLine($"Arguments must be more than zero!({string.Join(',', args)})");
            }
        }
    }
}
