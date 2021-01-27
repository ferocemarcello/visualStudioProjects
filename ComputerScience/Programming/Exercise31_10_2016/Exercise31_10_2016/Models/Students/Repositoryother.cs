using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise31_10_2016.Models.Students
{
    public class Repositoryother
    {
        public string operationTopic { get; set; }
        public Repository repo { get; set; }
        public Repositoryother(Repository r, string operationTopic)
        {
            this.repo = r;
            this.operationTopic = operationTopic;
        }

        
    }
}