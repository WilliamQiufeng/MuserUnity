using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Commons.Music.Midi;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace Muser.Sheets.Generator {
    class MidiConvert {
        public static void convert(string path, int[] trackIndexes) {
            /*
            var access = MidiAccessManager.Default;
            var music = MidiMusic.Read(System.IO.File.OpenRead(path));
            foreach (var track in music.Tracks) {
                Console.WriteLine("------------------------------");
                foreach (var note in track.Messages) {
                    Console.WriteLine($"{note.Event.EventType}: {note.DeltaTime}ticks, {note.Event.Value}");
                }
            }
            */
            var midiFile = MidiFile.Read(path);
            var tempoMap = midiFile.GetTempoMap();
            var tracks = midiFile.Chunks.OfType<TrackChunk>().ToList();
            foreach (var trackIndex in trackIndexes) {
                var track = tracks[trackIndex];
                Console.WriteLine($"Track {track.ChunkId}---------------");
                var manager = track.GetNotes();
                //TimedEventsCollection events = manager.Events;

                foreach (var e in manager) {
                    long time = e.TimeAs<MetricTimeSpan>(tempoMap).TotalMicroseconds;
                    long length = e.LengthAs<MetricTimeSpan>(tempoMap).TotalMicroseconds;
                    int pitch = e.NoteNumber;
                    Console.WriteLine($"Note {pitch} at {time / 1000.0}ms lasts {length / 1000.0}ms");
                }
            }
        }
    }
}
