using ConsoleWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWPF
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
        public bool SearchUsers(string login)
        {
            var users = s_masterEntities.Masters.Where(x => x.Login == login).FirstOrDefault();
            var users1 = s_masterEntities.Warehouse_employees.Where(x => x.Login == login).FirstOrDefault();
            if ((users != null && users1==null) || (users == null && users1 != null)) { return true; }
            else { return false; }
        }
        public bool CreateUsers(Masters masters)
        {
            if (SearchUsers(masters.Login))
            {
                return false;
            }
            else
            {
                try
                {
                    s_masterEntities.Masters.Add(masters);
                    s_masterEntities.SaveChanges();
                    return true;
                }
                catch(DbEntityValidationException e)
                {
                    foreach(DbEntityValidationResult validationError in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Console.WriteLine(err.ErrorMessage);
                        }
                    }
                    return false;
                }
            }
        }
        public bool CreateUsers(Warehouse_employees warehouse)
        {
            if (SearchUsers(warehouse.Login))
            {
                return false;
            }
            else
            {
                try
                {
                    s_masterEntities.Warehouse_employees.Add(warehouse);
                    s_masterEntities.SaveChanges();
                    return true;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (DbEntityValidationResult validationError in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            Console.WriteLine(err.ErrorMessage);
                        }
                    }
                    return false;
                }
            }
        }
    }
}
