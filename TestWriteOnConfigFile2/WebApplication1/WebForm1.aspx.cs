using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var configuration = WebConfigurationManager.OpenWebConfiguration("~");
            var section = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            section.ConnectionStrings.Add(new ConnectionStringSettings("MyConnectionString2", "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=Northwind;"));
            configuration.Save();
        }
    }
}