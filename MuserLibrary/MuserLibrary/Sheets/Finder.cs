using System;
using System.Collections.Generic;
using System.IO;

namespace Muser.Sheets {
    /// <summary>
    /// Finds sheets with given extension
    /// </summary>
    public class Finder {
        public static string[] find(string[] paths, string extension, SearchOption option = SearchOption.TopDirectoryOnly) {
            var res = new List<string>();
            foreach(string path in paths) {
                res.AddRange(Directory.GetFiles(path, extension, option));
            }
            return res.ToArray();
        }
    }
}
