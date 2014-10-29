using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casando.Data.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : DbContext
    {
        T Context { get; }
        void Save();
    }
}
