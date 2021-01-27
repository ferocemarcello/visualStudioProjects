using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public static string TryReturnText()
        {
            string d = System.IO.Directory.GetParent(@"../").FullName;
            string path = @"..\..\test.txt";
            string s = System.IO.File.ReadAllText(path);
            return s;
        }
    }
}
