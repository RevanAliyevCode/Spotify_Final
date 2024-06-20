using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models
{
    public class Playlist : BaseModel
    {
        public string Title { get; set; }

        public int UserID { get; set; }
        public User? User { get; set; }

        public List<Song> Songs { get; set; } = [];

        public override void GetDetail()
        {
            Console.WriteLine($"{Title}: ");
            foreach (var song in Songs)
            {
                Console.Write("\t");
                Console.WriteLine($"Song Title: {song.Title}, Song Duration: {song.Duration}, Song genre: {song.Genre.Name}, Song Artist: {song.Artist.Name}");
            }
        }
    }
}
