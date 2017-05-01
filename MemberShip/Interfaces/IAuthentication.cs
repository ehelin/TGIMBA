namespace AccountDataProvider.Interfaces
{
    public interface IAuthentication
    {
        bool SignIn(string userName, string Password);
        bool SignOut(string userName);
    }
}
