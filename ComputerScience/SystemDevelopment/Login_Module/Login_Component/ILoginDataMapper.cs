namespace Login_Component
{
    public interface ILoginDataMapper
    {
        void Create(string email, string encryptedPassword);
        User Read(string email, string encryptedPassword);

        void UpdatePassword(string email, string encryptedPassword, string encryptedNewPassword);

        void Delete(string email, string encryptedPassword);
        void UpdateMail(string email, string newMail);
    }
}