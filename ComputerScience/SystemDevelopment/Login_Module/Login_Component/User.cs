namespace Login_Component
{
    public class User
    {
        private string email;
        private string password;
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
       
        public string GetEmail()
        {
            return this.email;
        }
        public string GetPassword()
        {
            return this.password;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }
    }
}