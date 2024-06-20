using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class GenreReadRepo : ReadRepo<Genre>, IGenreReadRepo
    {
        public GenreReadRepo(DbContext context) : base(context)
        {
        }
    }
}
