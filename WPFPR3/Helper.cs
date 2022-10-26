using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFPR3.Model;

namespace WPFPR3
{
    class Helper
    {
        private static loginEntities s_loginEntities;
        public static loginEntities GetContext()
        {
            if (s_loginEntities == null)
            {
                s_loginEntities = new loginEntities();
            }
            return s_loginEntities;
        }
        public bool SearchUsers(string login, string password)
        {
            var users = s_loginEntities.Users.Where(x => x.Login == login && x.Password == password);
            if (users.Count() == 1) { return true; }
            else { return false; }
        }
        public bool CreateUsers(Users users)
        {
            if (SearchUsers(users.Login, users.Password))
            {
                return false;
            }
            else
            {
                s_loginEntities.Users.Add(users);
                s_loginEntities.SaveChanges();
                return true;
            }
        }
    }
}
