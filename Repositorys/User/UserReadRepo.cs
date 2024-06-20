using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class UserReadRepo : ReadRepo<User>, IUserReadRepo
    {
        public UserReadRepo(DbContext context) : base(context)
        {
        }
    }
}
