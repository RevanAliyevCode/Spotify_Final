using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Song : BaseModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string? Lyrcs { get; set; }
        public int Likes { get; set; } = 0;

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public override void GetDetail()
        {
            Console.WriteLine($"{Title}");
            Console.WriteLine($"{Artist.Name}");
            Console.WriteLine($"{Genre.Name}");
            Console.WriteLine($"{Duration}");
            Console.WriteLine($"{Lyrcs}");
            Console.WriteLine(Likes);
        }
    }
}
