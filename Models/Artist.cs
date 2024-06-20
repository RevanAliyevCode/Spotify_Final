using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Artist : BaseModel
    {
        public string Name { get; set; }

        public List<Song> Songs { get; set; } = [];

        public override void GetDetail()
        {
            Console.WriteLine($"{Name}: ");
            foreach ( var song in Songs )
            {
                Console.Write("\t");
                Console.WriteLine($"Song Title: {song.Title}, Song Duration: {song.Duration}, Song genre: {song.Genre.Name} {song.Likes}");
            }
        }
    }
}
