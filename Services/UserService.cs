using Controllers;
using Models;

namespace Services {
    public class UserServcie {
        public static void CreateUser(UserController userController)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            Console.Write("Enter user type (Normal/Premium): ");
            var type = Console.ReadLine();

            userController.CreateUser(username, password, type);
        }

        public static User LoginUser(UserController userController)
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            var user = userController.Login(username, password);
            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
            }
            else
            {
                Console.WriteLine("Login successful.");
            }

            return user;
        }
    }
}