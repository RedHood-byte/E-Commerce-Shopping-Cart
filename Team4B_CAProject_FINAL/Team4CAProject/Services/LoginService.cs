using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Team4CAProject.DB;
using Team4CAProject.Models;

namespace Team4CAProject.Services
{
    public class LoginService
    {
        protected CADb dbcontext;

        public LoginService(CADb db)
        {
            this.dbcontext = db;
        }
        public static string GetHash(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
        public int Login(string username, string password, ISession session)
        {
            Customer customer;
            customer = dbcontext.Customers.Where(x => x.UserName == username).FirstOrDefault();
            if (customer == null)
            {
                return 1;
            }
            string pwd = customer.Password;
            password = GetHash(password);
            if (pwd != password)
            {
                return 2;
            }
            else
            {
                session.SetInt32("customerId", customer.Id);
                return 3;
            }
        }
        public int CheckLogin(string username,string password)
        {
            Customer customer;
            customer = dbcontext.Customers.Where(x => x.UserName == username).FirstOrDefault();
           if(customer != null)
                return 1;
            else
                return 0;
        }
    }
}
