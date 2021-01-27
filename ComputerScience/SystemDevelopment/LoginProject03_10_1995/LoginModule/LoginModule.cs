using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginModule
{
    public delegate void VerifyEmail(string email);
    public delegate void VerifyPassword(string email);
    public class LoginModule
    {
        VerifyEmail _verifyEmail;
        VerifyPassword _verifyPassword;
        public LoginModule(VerifyEmail verifyEmail, VerifyPassword verifyPassword)
        {
            _verifyEmail = verifyEmail;
            _verifyPassword = verifyPassword;
        }

        public void CreateUser(string email, string password1, string password2)
        {
            _verifyEmail(email);
            _verifyPassword(password1);
            _verifyPassword(password2);
            if (!password1.Equals(password2))
            {
                throw new Exception();
            }
        }
    }
}
