using Newtonsoft.Json;
using System.Text;

namespace SwagLabsPages.Services
{
    internal class TestDataReader
    {
        private static string? GetPath()
        {
            string path = "testData.json";

            using FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read);
            
            byte[] bt = new byte[1024];

            UTF8Encoding end = new(true);

            int byteRead = fileStream.Read(bt, 0, bt.Length);

            if (byteRead > 0) return end.GetString(bt, 0, byteRead);

            return null;
        }
        private static readonly dynamic? json = JsonConvert.DeserializeObject(GetPath()!);
        internal static string GetData(UserType userType, string userData)
        {
            string userTypeKey = userType.ToString();

            return (string)json![userTypeKey][userData];
        }
        internal enum UserType
        {
            valid,
            fake
        }
    }
}   
