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
            HashPasswords.Hash hash = new HashPasswords.Hash();
            Helper helper = new Helper();
            MasterEntities db = Helper.GetContext();
            Console.Write("Создание новой учетной записи для пользователя\n\nВыберите роль (1 - мастер, 2 - работник склада): ");
            int role = 0;
            try
            {
                role = Convert.ToInt32(Console.ReadLine());
                while (role!=1 && role !=2){
                    Console.Write("Неверный вариант роли. Выберите роль (1 - мастер, 2 - работник склада): ");
                    role = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("Введите имя пользователя: ");
                string name = Console.ReadLine();
                Console.Write("Введите фамилию пользователя: ");
                string surname = Console.ReadLine();
                Console.Write("Введите отчество пользователя (при отсутствии нажмите Enter): ");
                string lastname = Console.ReadLine();
                Console.Write("Введите телефон пользователя: ");
                string phone = Console.ReadLine();
                Console.Write("Введите логин пользователя: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль пользователя: ");
                string password = Console.ReadLine();
                password = hash.hashing(password);
                Console.WriteLine("Хешированный пароль пользователя: " + password);
                if (role == 1)
                {
                    Console.Write("Введите специализацию пользователя: ");
                    string spec = Console.ReadLine();
                    Masters users = new Masters();
                    users.Login = login;
                    users.Password = password;
                    users.Name = name;
                    users.Surname = surname;
                    users.Lastname = lastname;
                    users.Phone = phone;
                    users.Specialization = spec;
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
                else
                {
                    Warehouse_employees users = new Warehouse_employees();
                    users.Login = login;
                    users.Password = password;
                    users.Name = name;
                    users.Surname = surname;
                    users.Lastname = lastname;
                    users.Phone = phone;
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
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода. Вам нужно ввести «1» или «2».");
                Console.ReadLine();
            }
        }
    }
}
