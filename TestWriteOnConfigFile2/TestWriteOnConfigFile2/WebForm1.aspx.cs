using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWriteOnConfigFile2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
            var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            section.ConnectionStrings["MyConnectionString1"].ConnectionString = "Data Source=127.0.0.1";
            configuration.Save();
        }
    }
}