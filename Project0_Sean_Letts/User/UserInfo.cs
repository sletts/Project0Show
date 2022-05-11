using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public override string ToString()
        {
            Console.WriteLine("==========");
            string admin = "";
            if (IsAdmin)
                admin = "Yes";
            else
                admin = "No";
            return $"Username: {UserName}\nPassword: {Password}\nIs an Admin User: {admin}";
        }
    }
}
