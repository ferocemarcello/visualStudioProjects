using System;
using Login_Component;
using System.Collections.Generic;
using Login_Component.Exceptions;

namespace Login_Test
{
    public class FakeDataMapper : ILoginDataMapper
    {
        private LinkedList<User> users;

        public FakeDataMapper()
        {
            users = new LinkedList<User>();
        }

        
        public void Create(string email, string encryptedPassword)
        {
            foreach (User a in users)
            {
                if (a.GetEmail().Equals(email))
                {
                    throw new AlreadyExistingUserException();
                }
            }

            users.AddFirst(new User(email,encryptedPassword));
        }

        public User Read(string email, string encryptedPassword)
        {
            foreach (User u in users)
            {
                if (u.GetEmail().Equals(email))
                {
                    if (u.GetPassword().Equals(encryptedPassword))
                    {
                        return u;
                    }
                    else
                    {
                        return new User(email, null);
                    }
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public void UpdatePassword(string email, string encryptedPassword, string newEncryptedPassword)
        {
            bool b = false;

            foreach (User u in users)
            {
                if (u.GetEmail().Equals(email))
                {
                    if (u.GetPassword().Equals(encryptedPassword))
                    {
                        u.SetPassword(newEncryptedPassword);
                        b = true;

                    }
                    else
                    {
                        throw new InvalidPasswordException();
                    }
                }                             
            }
            if (!b)
            {
                throw new NonExistingUserException();
            }
        }

        public void Delete(string email, string encryptedPassword)
        {

            User a = Read(email, encryptedPassword);
            if (users.Contains(a))
            {
                users.Remove(a);
            }
            else
            {

                if (a == null || a.GetEmail() == null)
                    throw new NonExistingUserException();
                else
                    throw new InvalidPasswordException();
            }
        }

        public void UpdateMail(string email, string newMail)
        {
            bool cont = false;
            foreach (User u in users)
            {
                if (u.GetEmail().Equals(email))
                {
                    u.SetEmail(newMail);
                    cont = true;
                }
            }
            if (!cont)
            {
                throw new NonExistingUserException();
            }
        }
    }
}

    