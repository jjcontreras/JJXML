using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Escritores
{
    public static class WriteTextToFile
    {
        public static bool Write(string path, List<string> text)
        {
            File.WriteAllLines(path, text);
            return true;
        }
    }
}
