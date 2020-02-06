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
