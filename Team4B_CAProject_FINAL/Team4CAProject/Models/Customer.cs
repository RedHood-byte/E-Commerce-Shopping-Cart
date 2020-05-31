using System;
using Team4CAProject.Services;

namespace Team4CAProject.Models
{
    public class Customer
    {
        public int Id { set; get; }

        public string UserName { set; get; }

        public string Password { set; get; }

        public Customer() { }
        public Customer(String uname, string pwd)
        {
            UserName = uname;
            Password = LoginService.GetHash(pwd);
        }
    }
}
