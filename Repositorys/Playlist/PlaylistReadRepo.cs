using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class PlaylistReadRepo : ReadRepo<Playlist>, IPlaylistReadRepo
    {
        public PlaylistReadRepo(DbContext context) : base(context)
        {
        }
    }
}
