using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casando.Core.Interfaces
{
    public interface IRepositorio<T> : IDisposable
    {
        T Inclui(T obj);
        void Altera(T obj);
        void Exclui(T obj);
        void Exclui(int id);
        void SaveChanges();
        IEnumerable<T> Todos();
    }
}
