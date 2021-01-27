using System;
using Login_Component.Exceptions;

namespace Login_Component
{
    public class Helper
    {
        private static int minEmailLenght = 5;
        private static int minPasswordLenght = 6;

        public static void CheckEmailSyntax(string email)
        {
            if (email.Length < minEmailLenght)
            {
                throw new ShortEmailException(email.Length);
            }

            if (!email.Contains("@"))
            {
                throw new EmailSyntaxWrongException();
            }
            //TODO
            /*
             * Check @
             * Check .
             * Check no spaces
             * */

        }

        internal static void ChangeEmail(string email, string newMail, ILoginDataMapper ldm)
        {
            ldm.UpdateMail(email, newMail);
        }

        public static void Delete(string email, string password, ILoginDataMapper ldm)
        {
            ldm.Delete(email, password);
        }

        public static void CheckPasswordEqual(string password, string confirmPassword)
        {
            if(!password.Equals(confirmPassword))
            {
                throw new DifferentPasswordException();
            }
            
        }

        internal static void ChangePassword(string email, string password, string newPassword, ILoginDataMapper ldm)
        {
            ldm.UpdatePassword(email, GetEncryptedPassword(password), GetEncryptedPassword(newPassword));
        }

        public static void CheckPasswordSyntax(string password)
        {
            if (password.Length < minPasswordLenght)
            {
                throw new ShortPasswordException(password.Length);
            }
            //TODO
            /*
             * One Capital Letter
             * One special char
             * One number
             * */
        }

        public static void Store(string email, string password, ILoginDataMapper ldm)
        {
            ldm.Create(email, password);                
        }
        public static string GetEncryptedPassword(string password)
        {
            /*char[] letters = new char[password.Length];
            for (int i=0;i<password.Length;i++)
            {
                if (password[i] < 245)
                {
                    letters[i] = (char)((int)password[i]+10);
                }
                else
                {
                    letters[i] = (char)((int)password[i] -10);
                }
                
            }
            return letters.ToString();*/
            return password.GetHashCode().ToString();
        }
        public static void CheckCredentials(string email, string encryptedPassword, ILoginDataMapper ldm)
        {
            User u = ldm.Read(email, encryptedPassword);
            if (u==null)
            {
                throw new InvalidMailException();
            }
            else
            {
                if (u.GetPassword() == null)
                {
                    throw new InvalidPasswordException();
                }
            }
            
        }
    }
}