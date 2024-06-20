using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class ArtistWriteRepo : WriteRepo<Artist>, IArtistWriteRepo
    {
        public ArtistWriteRepo(DbContext context) : base(context)
        {
        }
    }
}
