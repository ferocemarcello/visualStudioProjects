using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcClientProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcServiceReference.CalcServiceDivisionResult cd = new CalcServiceReference.CalcServiceDivisionResult();
            CalcServiceReference.ICalcService cs = new CalcServiceReference.CalcServiceClient();
            cd = cs.getDivisionResult(5, 2);
            Console.WriteLine(cd.quotient+", "+cd.rest);
            Console.ReadLine();
        }
    }
}
