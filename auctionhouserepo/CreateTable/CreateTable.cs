using AuctionHouseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouseProject
{
    class CreateTable
    {
        public static void Main()
        {
            MsSqlDataMapper ldm = new MsSqlDataMapper("Data Source = ealdb1.eal.local;Initial Catalog=EAL5_DB;Persist Security Info=true;User ID=EAL5_USR;Password=Huff05e05");
            
            //ldm.DeleteTable("AuctionHouseProjectLetterB");
            //ldm.CreateTable("AuctionHouseProjectLetterB");
            ldm.ClearTable();
        }
    }
}
