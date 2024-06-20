using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IWriteRepo<T> where T : BaseModel
    {
        void Create(T model);
        void Delete(int id);
        void Update(int id, T model);
    }
}
