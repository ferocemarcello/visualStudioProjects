using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static CalcService.CalcService;

namespace CalcService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICalcService" in both code and config file together.
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        DivisionResult getDivisionResult(int a, int b);
    }

    
}