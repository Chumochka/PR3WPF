using ConsoleWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWPF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Создание новой учетной записи для пользователя\n\nВведите имя пользователя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию пользователя: ");
            string surname = Console.ReadLine();
            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();
            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();
            HashPasswords.Hash hash = new HashPasswords.Hash();
            password = hash.hashing(password);
            Console.WriteLine("Хешированный пароль пользователя: " + password);
            Helper helper = new Helper();
            loginEntities db = Helper.GetContext();
            Users users = new Users();
            users.Login = login;
            users.Password = password;
            users.Name = name;
            users.Surname = surname;
            if (helper.CreateUsers(users))
            {
                Console.WriteLine("Учетная запись добавлена");
            }
            else
            {
                Console.WriteLine("Такой пользователь уже существует");
            }
            Console.ReadLine();
        }
    }
}
