using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class ArtistReadRepo : ReadRepo<Artist>, IArtistReadRepo
    {
        public ArtistReadRepo(DbContext context) : base(context)
        {
        }
    }
}
