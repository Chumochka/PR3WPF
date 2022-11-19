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
        private static MasterEntities s_masterEntities;
        public static MasterEntities GetContext()
        {
            if (s_masterEntities == null)
            {
                s_masterEntities = new MasterEntities();
            }
            return s_masterEntities;
        }
        public string SearchUsers(string login, string password)
        {
            var users = s_masterEntities.Masters.Where(x => x.Login == login).FirstOrDefault();
            var users1 = s_masterEntities.Warehouse_employees.Where(x => x.Login == login).FirstOrDefault();
            if (users == null && users1 == null)
            {
                return "Такого пользователя нет.";
            }
            else
            {
                if (users == null)
                {
                    if (users1.Password == password)
                    {
                        return "Вы авторизовались, как работник склада";
                    }
                    else
                    {
                        return "Неправильно введён пароль.";
                    }
                }
                else
                {
                    if (users.Password == password)
                    {
                        return "Вы авторизовались, как мастер";
                    }
                    else
                    {
                        return "Неправильно введён пароль.";
                    }
                }
            }
        }

    }
}
