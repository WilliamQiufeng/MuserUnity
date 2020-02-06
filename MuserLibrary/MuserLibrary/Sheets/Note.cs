//   MuserLibrary
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
using System.Runtime.Serialization;

namespace Muser.Sheets.Note {
    /// <summary>
    /// Base note type
    /// </summary>
    public abstract class Note {
        /// <summary>
        /// The time when the note gets enabled, relative to the current progress of the music
        /// </summary>
        public double Time { get; set; }
        /// <summary>
        /// Protected constructor of base class Note
        /// </summary>
        /// <param name="time"></param>
        protected Note(double time) {
            Time = time;
        }
    }
    /// <summary>
    /// Normal note type
    /// </summary>
    public class NormalNote : Note {
        /// <summary>
        /// The time it takes from enter to center
        /// </summary>
        public double PreactionTime { get; set; }
        /// <summary>
        /// The length of the note
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// Constructs NormalNote
        /// </summary>
        /// <param name="time"></param>
        /// <param name="preactionTime"></param>
        /// <param name="length"></param>
        public NormalNote(double time, double preactionTime, double length) : base(time) {
            PreactionTime = preactionTime;
            Length = length;
        }
    }
    /// <summary>
    /// Effect note
    /// </summary>
    public class EffectNote : Note {
        /// <summary>
        /// The effect to use
        /// </summary>
        public Effect.Effect Effect { get; set; }
        /// <summary>
        /// The length of the note
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// Constructs EffectNote
        /// </summary>
        /// <param name="time"></param>
        /// <param name="effect"></param>
        /// <param name="length"></param>
        public EffectNote(double time, Effect.Effect effect, double length) : base(time) {
            Effect = effect;
            Length = length;
        }
    }
}
