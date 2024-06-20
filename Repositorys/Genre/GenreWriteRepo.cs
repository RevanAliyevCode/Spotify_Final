using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class GenreWriteRepo : WriteRepo<Genre>, IGenreWriteRepo
    {
        public GenreWriteRepo(DbContext context) : base(context)
        {
        }
    }
}
