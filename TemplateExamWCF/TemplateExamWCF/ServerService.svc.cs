using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace TemplateExamWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServerService.svc or ServerService.svc.cs at the Solution Explorer and start debugging.

    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)] for sessions
    public class ServerService : IServerService
    {
        public ServerService()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
            HttpContext.Current.Session["lnn"] = "nln";
        }
    }
}
