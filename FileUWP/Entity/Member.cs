using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUWP.Entity
{
    class Member
    {
        private string _useName;
        private string _email;
        private string _phone;

        public string useName { get => _useName; set => _useName = value; }
        public string email { get => _email; set => _email = value; }
        public string phone { get => _phone; set => _phone = value; }
    }
}
