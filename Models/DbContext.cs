using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DbContext
    {
        public List<User> Users { get; set; } = [];
        public List<Playlist> Playlists { get; set; } = [];
        public List<Genre> Genres { get; set; } = [];
        public List<Song> Songs { get; set; } = [];
        public List<Artist> Artists { get; set; } = [];

        public DbContext()
        {
            StaticValues();
        }

        private void StaticValues()
        {
            Genres.Add(new Genre { Name = "Rock" });
            Genres.Add(new Genre { Name = "Pop" });
            Genres.Add(new Genre { Name = "Jazz" });
            Genres.Add(new Genre { Name = "Classical" });
            Genres.Add(new Genre { Name = "Hip Hop" });

            for (int i = 1; i <= 10; i++)
            {
                Artists.Add(new Artist { Name = $"Artist {i}" });
            }

            for (int i = 1; i <= 20; i++)
            {
                var artist = Artists[(i - 1) % 10];
                var genre = Genres[(i - 1) % 5];
                var song = new Song
                {
                    Title = $"Song {i}",
                    Duration = TimeSpan.FromMinutes(3 + i % 5),
                    Lyrcs = $"Lyrics for song {i}",
                    Likes = i * 10,
                    ArtistId = artist.Id,
                    Artist = artist,
                    GenreId = genre.Id,
                    Genre = genre
                };

                artist.Songs.Add(song);
                genre.Songs.Add(song);
                Songs.Add(song);
            }

            Users.Add(new() { UserName = "Spotify Admin", Password = "password", Type = "All migthy" });

            for (int i = 1; i <= 4; i++)
            {
                Playlist playlist = new()
                {
                    Title = $"Random playlist {i}",
                    Songs = Enumerable.Range(0, 5).Select(_ => Songs[new Random().Next(1, 20)]).ToList(),
                    UserID = 36
                };

                Playlists.Add(playlist);
                Users[0].Playlists.Add(playlist);
            }

        }
    }
}
