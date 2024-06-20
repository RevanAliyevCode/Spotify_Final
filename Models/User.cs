using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

        public List<Playlist> Playlists { get; set; } = [];
        public List<int> LikedSongs { get; set; } = new List<int>(); 

        public override void GetDetail()
        {
            Console.WriteLine($"{UserName}:");
            foreach ( var playlist in Playlists )
            {
                Console.WriteLine(playlist.Title);
            }
        }
    }
}
