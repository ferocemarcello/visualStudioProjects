using Login_Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_Component.Exceptions;

namespace TryDb
{
    class Program
    {
        static void Main(string[] args)
        {
            MsSqlLoginDataMapper ldm = new MsSqlLoginDataMapper("Data Source = ealdb1.eal.local;Initial Catalog=EAL5_DB;Persist Security Info=true;User ID=EAL5_USR;Password=Huff05e05");
            /*foreach(string s in ldm.SelectTables())
            {
                Console.WriteLine(s);
            }*/
            ldm.DeleteTODELETE("ferocemarcello@gmail.com", Helper.GetEncryptedPassword("123456"));
            //ldm.Delete("ferocemarcellow@gmail.com", Helper.GetEncryptedPassword("123456"));
            //ldm.Delete("shapournemati@gmail.com", Helper.GetEncryptedPassword("123456"));
            ldm.DeleteTODELETE("ferocemarcellrfw2o@gmail.com", "123456");
            
            
            /*try
            {
                ldm.Create("ferocemarcello@gmail.com", Helper.GetEncryptedPassword("123456"));
                ldm.Create("ferocemarcello@gmail.com", Helper.GetEncryptedPassword("123456"));
            }
            catch (AlreadyExistingUserException e) 
            {
                Console.WriteLine(e.Message);
            }*/
            foreach(User u in ldm.ReadAllUsers())
            {
                Console.Write(u.GetEmail());
                Console.WriteLine(u.GetPassword());
            }
            User uss=ldm.Read("ferocemarcello222@gmail.com", Helper.GetEncryptedPassword("1234567"));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            if (uss!= null)
            {
            //    Console.WriteLine(uss.GetEmail() + "  " + uss.GetPassword());
            }
            //ldm.CreateTable("UserFeroceNemati");
            //ldm.DeleteTable("User");
            //ldm.CreateTable("User");
            //ldm.Create(new User("ferocemarcello@virgilio.it", "123456"));
            Console.ReadLine();
        }
    }
}
