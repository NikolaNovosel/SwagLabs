using Newtonsoft.Json;
using System.Text;

namespace SwagLabsPages.Services
{
    internal class DataReader
    {
        private static string GetPath()
        {
            string path = "testData.json";
            using FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
            byte[] bt = new byte[1024];
            UTF8Encoding end = new(true);
            int byteRead = fileStream.Read(bt, 0, bt.Length);
            if (byteRead > 0) return end.GetString(bt, 0, byteRead);
            return null;
        }
        private static readonly dynamic json = JsonConvert.DeserializeObject(GetPath());
        internal static string GetValidUser(User user) => (string)json["valid"][user.ToString()];
        internal static string GetFakeUser(User user) => (string)json["fake"][user.ToString()];
        internal enum User
        {
            userName,
            password
        }
    }
}   
