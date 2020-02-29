namespace Sitecore.Foundation.Accounts.Repositories
{
    using Sitecore.Security.Accounts;

    public interface IAccountRepository
    {

        void RegisterUser(string email, string password, string profileId);
        bool Exists(string userName);
        void Logout();
        User Login(string userName, string password);
    }
}