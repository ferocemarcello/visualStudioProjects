using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalcService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalcService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalcService.svc or CalcService.svc.cs at the Solution Explorer and start debugging.
    public class CalcService : ICalcService
    {
        public void DoWork()
        {
        }

        public DivisionResult getDivisionResult(int a, int b)
        {
            DivisionResult d = new DivisionResult();
            d.quotient = a / b;
            d.rest = a % b;
            return d;
        }
        public class DivisionResult
        {
            public int quotient;
            public int rest;
        }
    }
}
