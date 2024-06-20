using Models;
using Controllers;

namespace Services {
    public class ViewServices {
        public static void ShowUserMenu(User user, DbContext dbContext, UserController userController, SongController songController, PlaylistController playlistController)
        {
            Console.WriteLine($"Welcome {user.UserName}!");
            while (true)
            {
                Console.WriteLine("1. View Public Playlists");
                Console.WriteLine("2. View My Playlists");
                if (user.Type == "Normal")
                {
                    Console.WriteLine("4. Change User Type to Premium");
                }
                Console.WriteLine("3. Logout");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                if (option == "1")
                {
                    ViewPublicPlaylists(user, songController, playlistController);
                }
                else if (option == "2")
                {
                    ViewPlaylists(user, playlistController);
                }
                else if (option == "4" && user.Type == "Normal")
                {
                    userController.ChangeUserType(user);
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

        public static void ViewPublicPlaylists(User user, SongController songController, PlaylistController playlistController)
        {
            var publicPlaylists = playlistController.GetAll().Take(4).ToList();
            for (int i = 0; i < publicPlaylists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {publicPlaylists[i].Title}");
            }

            Console.Write("Select a playlist: ");
            if (int.TryParse(Console.ReadLine(), out int playlistIndex) && playlistIndex > 0 && playlistIndex <= publicPlaylists.Count)
            {
                var playlist = publicPlaylists[playlistIndex - 1];
                Console.WriteLine($"Playlist: {playlist.Title}");
                for (int i = 0; i < playlist.Songs.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {playlist.Songs[i].Title}");
                }

                Console.Write("Select a song: ");
                if (int.TryParse(Console.ReadLine(), out int songIndex) && songIndex > 0 && songIndex <= playlist.Songs.Count)
                {
                    var song = playlist.Songs[songIndex - 1];
                    song.GetDetail();

                    if (user.Type == "Premium")
                    {
                        Console.WriteLine("1. Add to Playlist");
                        Console.WriteLine("2. Like Song");
                        Console.WriteLine("3. Go back");
                        Console.Write("Select an option: ");
                        var option = Console.ReadLine();

                        if (option == "1")
                        {
                            SongServices.AddSongToUserPlaylist(user, song, playlistController);
                        }
                        else if (option == "2")
                        {
                            SongServices.LikeSong(user, song, songController);
                        }
                    }
                }
            }
        }

        public static void ViewPlaylists(User user, PlaylistController playlistController)
        {
            var playlists = playlistController.GetByUser(user.Id);
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"Playlist: {playlist.Title}");
                foreach (var song in playlist.Songs)
                {
                    Console.WriteLine($"\tTitle: {song.Title}, Duration: {song.Duration}, Genre: {song.Genre.Name}, Artist: {song.Artist.Name}");
                }
            }
        }
    }
}