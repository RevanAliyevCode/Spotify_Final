using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Repositorys;
using Controllers;
using Services;

namespace MusicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext dbContext = new DbContext();

            UserController userController = new(dbContext);
            GenreController genreController = new(dbContext);
            ArtistController artistController = new(dbContext);
            SongController songController = new(dbContext);
            PlaylistController playlistController = new(dbContext);

            Console.WriteLine("Welcome to the Music App!");
            while (true)
            {
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                if (option == "1")
                {
                    UserServcie.CreateUser(userController);
                }
                else if (option == "2")
                {
                    var user = UserServcie.LoginUser(userController);
                    if (user != null)
                    {
                        ViewServices.ShowUserMenu(user, dbContext, userController, songController, playlistController);
                    }
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Try again.");
                }
            }
        }
    }
}
