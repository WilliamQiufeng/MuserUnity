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

namespace Muser.Sheets.Notes {
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
        /// How much time at total will the note exist from enter to fade
        /// </summary>
        public double AppearLength { get; set; }
        /// <summary>
        /// The length of the note
        /// </summary>
        public double Length { get; set; }
        /// <summary>
        /// The index of the center the note will go to
        /// </summary>
        public int CenterIndex { get; set; }
        /// <summary>
        /// The side of the note
        /// </summary>
        public NoteSide Side { get; set; }
        /// <summary>
        /// Constructs NormalNote
        /// </summary>
        /// <param name="time"></param>
        /// <param name="appearLength"></param>
        /// <param name="length"></param>
        /// <param name="centerIndex"></param>
        public NormalNote(double time, double appearLength, double length, int centerIndex, NoteSide side) : base(time) {
            AppearLength = appearLength;
            Length = length;
            CenterIndex = centerIndex;
            Side = side;
        }
    }
    /// <summary>
    /// Effect note
    /// </summary>
    public class EffectNote : Note {
        /// <summary>
        /// The effect to use
        /// </summary>
        public Effects.Effect Effect { get; set; }
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
        public EffectNote(double time, Effects.Effect effect, double length) : base(time) {
            Effect = effect;
            Length = length;
        }
    }
}
