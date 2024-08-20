using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsPages.Models
{
    public class User
    {
        private readonly string _userName;
        private readonly string _password;

        public User(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public string GetUserName => _userName;
        public string GetPassword => _password;
    }
}
