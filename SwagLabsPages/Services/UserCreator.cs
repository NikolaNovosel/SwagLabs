using SwagLabsPages.Models;

namespace SwagLabsPages.Services
{
    public static class UserCreator
    {
        public static User WithValidCredentials() => new(DataReader.GetValidUser(DataReader.User.userName), DataReader.GetValidUser(DataReader.User.password));
        public static User WithFakeCredentials() => new(DataReader.GetFakeUser(DataReader.User.userName), DataReader.GetFakeUser(DataReader.User.password));
    }
}
