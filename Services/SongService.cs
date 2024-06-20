using Models;
using Controllers;

namespace Services {
    public class SongServices {
        public static void AddSongToUserPlaylist(User user, Song song, PlaylistController playlistController)
        {
            var userPlaylists = playlistController.GetByUser(user.Id);
            Console.WriteLine("Select a playlist to add the song to or enter a new playlist name:");
            for (int i = 0; i < userPlaylists.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {userPlaylists[i].Title}");
            }
            Console.Write("Enter playlist name or number: ");
            var input = Console.ReadLine();
            Playlist selectedPlaylist;

            if (int.TryParse(input, out int playlistIndex) && playlistIndex > 0 && playlistIndex <= userPlaylists.Count)
            {
                selectedPlaylist = userPlaylists[playlistIndex - 1];
            }
            else
            {
                selectedPlaylist = playlistController.GetByName(input) ?? new Playlist { Title = input, UserID = user.Id };
                playlistController.Create(selectedPlaylist);
            }

            playlistController.AddSongToPlaylist(selectedPlaylist.Id, song.Id);
            Console.WriteLine("Song added to playlist.");
        }

        public static void LikeSong(User user, Song song, SongController songController)
        {
            if (!user.LikedSongs.Contains(song.Id))
            {
                song.Likes++;
                user.LikedSongs.Add(song.Id);
                songController.UpdateSong(song.Id, song);
                Console.WriteLine("Song liked.");
            }
            else
            {
                Console.WriteLine("You have already liked this song.");
            }
        }
    }
}