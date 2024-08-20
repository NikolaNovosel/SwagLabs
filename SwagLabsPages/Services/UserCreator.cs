using SwagLabsPages.Models;

namespace SwagLabsPages.Services
{
    public static class UserCreator
    {
        private static readonly string _userName = "userName";
        private static readonly string _password = "password";
        public static User WithValidCredentials() => new (TestDataReader.GetData(TestDataReader.UserType.valid, _userName), TestDataReader.GetData(TestDataReader.UserType.valid, _password));
        public static User WithFakeCredentials() => new (TestDataReader.GetData(TestDataReader.UserType.fake, _userName), TestDataReader.GetData(TestDataReader.UserType.fake, _password));
    }
}
