using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Muser.Sheets.Generator {
    class MetaReader {
        private readonly FileStream stream;
        private string metaRead;
        /// <summary>
        /// The meta gathered
        /// </summary>
        public Meta Meta { get; set; } = null;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public MetaReader(string path) => 
            stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        /// <summary>
        /// Read from the stream and store it to metaRead
        /// </summary>
        /// <returns>if reading process is successfully finished</returns>
        public bool read() {
            if (stream == null || stream.CanRead == false) return false;
            byte[] read = new byte[stream.Length];
            stream.Read(read, 0, read.Length);
            metaRead = Encoding.Default.GetString(read);
            Console.WriteLine(metaRead);
            return true;
        }
        /// <summary>
        /// Process metaRead
        /// </summary>
        public void parse() {
            Meta = JsonConvert.DeserializeObject<Meta>(metaRead);
        }
    }
}
