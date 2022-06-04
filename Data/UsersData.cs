using BalanceAPI.Context;
using BalanceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalanceAPI.Data
{
    public class UsersData
    {
        public UsersData()
        {
        }

        private bool UserExist(string email, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = (from x in context.Users where (email == x.Email) && (password == x.Password) select x).FirstOrDefault();

                if(query != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public User GetUser(string email, string password)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = (from x in context.Users where (email == x.Email) && (password == x.Password) select x).FirstOrDefault();

                if (query != null)
                {
                    return query;
                }
                else
                {
                    return null;
                }
            }
        }

        public  bool RegisterNewUser(string email, string password)
        {
            //Can add validation here

            if (!UserExist(email, password))
            {
                using (var context = new ApplicationDbContext())
                {
                    User NewUser = new User();
                    NewUser.Email = email;
                    NewUser.Password = password;

                    context.Add<User>(NewUser);
                    context.SaveChanges();             
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
