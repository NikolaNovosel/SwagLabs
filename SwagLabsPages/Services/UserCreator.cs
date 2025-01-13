using SwagLabsPages.Models;
using static SwagLabsPages.Services.DataReader;

namespace SwagLabsPages.Services
{
    public static class UserCreator
    {
        public static User WithValidCredentials() => new(GetValidUser(UserCredentials.userName), GetValidUser(UserCredentials.password));
        public static User WithFakeCredentials() => new(GetFakeUser(UserCredentials.userName), GetFakeUser(UserCredentials.password));
    }
}
