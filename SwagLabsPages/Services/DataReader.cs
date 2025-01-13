using Newtonsoft.Json;

namespace SwagLabsPages.Services
{
    internal class DataReader
    {
        private const string path = "testData.json";
        private static string GetPath() => File.ReadAllText(path);
        private static readonly dynamic json = JsonConvert.DeserializeObject(GetPath());
        internal static string GetValidUser(UserCredentials user) => (string)json["valid"][user.ToString()];
        internal static string GetFakeUser(UserCredentials user) => (string)json["fake"][user.ToString()];
    }
}   
