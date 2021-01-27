using AuctionHouseProject;
using System;
using System.Collections.Generic;

namespace AuctionHouseProject
{
    public class Helper
    {
        private static int minEmailLenght = 5;
        private static int minPasswordLenght = 6;
        private static string specials = "!£$%&/()=?^*-+°çé<>_.:,;";
        private static bool ContainsNumber(string password)
        {
            for(int i = 0; i < 10; i++)
            {
                if(password.Contains(i.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        private static bool ContainsSpecials(string password)
        {
            foreach(char c in specials.ToCharArray())
            {
                if (password.Contains(c.ToString()))
                {
                    return true;
                }
            }
            return false;
        }
        public static void CheckEmailSyntax(string email)
        {
            if (email.Length < minEmailLenght)
            {
                throw new ShortEmailException(email.Length);
            }

            if (!email.Contains("@"))
            {
                throw new EmailNotContainingAtException();
            }
            //TODO
            /*
             * Check @
             * Check .
             * Check no spaces
             * */

        }

        public static void ChangeEmail(string email, string newMail, MsSqlDataMapper ldm)
        {
            ldm.UpdateMail(email, newMail);
        }

        public static void Delete(string email, MsSqlDataMapper ldm)
        {
            ldm.Delete(email);
        }

        public static void CheckPasswordEqual(string password, string confirmPassword)
        {
            if(!password.Equals(confirmPassword))
            {
                throw new DifferentPasswordException();
            }
            
        }

        public static void ChangePassword(string email, string password, string newPassword, MsSqlDataMapper ldm)
        {
            ldm.UpdatePassword(email,GetEncryptedPassword(newPassword));
            
        }

        public static void CheckPasswordSyntax(string password)
        {
            if (password.Length < minPasswordLenght)
            {
                throw new ShortPasswordException(password.Length);
            }
            if (password.Equals(password.ToLower()))
            {
                throw new NotContainingCapitalLetterException();
            }
            
            if (!ContainsSpecials(password))
            {
                throw new NotContainingSpecialCharException();
            }
            if (!ContainsNumber(password))
            {
                throw new NotContainingNumberException();
            }
        }

        

        public static void Store(string email, string password,int balance, MsSqlDataMapper ldm)
        {
            ldm.Create(new AuctionHouseProject.User(email,password,balance));                
        }
        public static string GetEncryptedPassword(string password)
        {

            return password.GetHashCode().ToString();
        }
        public static void CheckCredentials(string email, string encryptedPassword, MsSqlDataMapper ldm)
        {
            User u = ldm.Read(email);
            if (u==null)
            {
                throw new InvalidMailException();
            }
            else
            {
                if (u.getPassword()!=encryptedPassword)
                {
                    throw new DifferentPasswordException();
                }
            }
            
        }
    }
}