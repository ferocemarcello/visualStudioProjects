using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWriteOnConfigFile
{
    class Program
    {
        public static void Main()
        {
            if (!FindConStri())
            {
                AddConnSect();
            }
            AddConnectionString("connadd1");
        }

        private static void AddConnectionString(string v)
        {
            System.IO.FileInfo f = new System.IO.FileInfo(@"..\..\..\WebApplication1\Web.config");
            List<string> s = System.IO.File.ReadLines(@"..\..\..\WebApplication1\Web.config").ToList();
            List<string> s2 = System.IO.File.ReadLines(@"..\..\..\WebApplication1\Web.config").ToList();
            int i = s.FindIndex(z => z.Contains("<connectionstring>"));
            if (i != 0)
            {
                s2.Insert(i, v);
            }
            System.IO.File.WriteAllLines(@"..\..\..\WebApplication1\Web.config", s2.ToArray());
        }

        private static void AddConnSect()
        {
            System.IO.FileInfo f = new System.IO.FileInfo(@"..\..\..\WebApplication1\Web.config");
            List<string> s =System.IO.File.ReadLines(@"..\..\..\WebApplication1\Web.config").ToList();
            List<string> s2 = System.IO.File.ReadLines(@"..\..\..\WebApplication1\Web.config").ToList();
            int i = s.FindIndex(z => z.Contains("-->"));
            if (i>=0)
            {
                s2.Insert(i, "<connectionstring>");
            }
            StreamWriter sw = new StreamWriter(@"..\..\..\WebApplication1\Web.config");
            for(int d = 0; d < s2.Count; d++)
            {
                sw.WriteLine(s2.ElementAt(d));
            }
            System.IO.File.WriteAllLines(@"..\..\WebApplication1", s2.ToArray());
        }

        private static bool FindConStri()
        {
            System.IO.DirectoryInfo d=new System.IO.DirectoryInfo(@"..\WebApplication1\");
            foreach(var x in System.IO.File.ReadLines(@"..\..\..\WebApplication1\Web.config"))
            {
                if (x.Contains("<connectionstring>")) return true;
            }
            return false;
        }
    }
}
