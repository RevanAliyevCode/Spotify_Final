using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface IReadRepo<T> where T : BaseModel
    {
        List<T> GetAll();
        T? GetById(int id);
    }
}
