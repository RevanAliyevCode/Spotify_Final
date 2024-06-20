using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UserController
    {
        readonly UserReadRepo _readRepo;
        readonly UserWriteRepo _writeRepo;

        public UserController(DbContext context)
        {
            _readRepo = new(context);
            _writeRepo = new(context);
        }

        public void GetAllUsers()
        {
            foreach (User user in _readRepo.GetAll())
            {
                Console.WriteLine($"{user.UserName} - {user.Type}");
            }
        }

        public User? GetUserById(int id)
        {
            User? user = _readRepo.GetById(id);
            if (user is not null)
            {
                user.GetDetail();
                return user;
            }
            Console.WriteLine("There is no song with that id");
            return null;
        }


        public void CreateUser(string username, string password, string type)
        {
            if (_readRepo.GetAll().Any(u => u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
                return;
            }

            User user = new User
            {
                UserName = username,
                Password = password,
                Type = type
            };

            _writeRepo.Create(user);
            Console.WriteLine("Account created successfully.");
        }

        public User? Login(string username, string password)
        {
            return _readRepo.GetAll().FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public void DeleteUser(int id)
        {
            _writeRepo.Delete(id);
        }

        public void ChangeUserType(User user)
        {
            if (user.Type == "Normal")
            {
                user.Type = "Premium";
                Console.WriteLine("User type changed to Premium.");
            }
            else
            {
                Console.WriteLine("User is already Premium.");
            }
        }

    }
}

