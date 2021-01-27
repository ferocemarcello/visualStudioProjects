using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CircleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICircle" in both code and config file together.
    [ServiceContract]
    public interface ICircle
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        double CalcDiameter(double radius);
        [OperationContract]
        double CalcCircumference(double radius);

    }
}
