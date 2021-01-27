namespace AuctionHouseProject
{
    public interface ILoginDataMapper
    {
        void Create(User u);
        User Read(string email);

        

        void Delete(string email);
        
    }
}