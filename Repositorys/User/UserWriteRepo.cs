using Abstractions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
    public class UserWriteRepo : WriteRepo<User>, IUserWriteRepo
    {
        public UserWriteRepo(DbContext context) : base(context)
        {
        }
    }
}
