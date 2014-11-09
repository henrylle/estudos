using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casando.Core.Interfaces;
using Casando.Core.Modelos;
using Casando.Data.Interfaces;

namespace Casando.Data
{
    public class Repositorio<T> : IRepositorio<T> where T : EntidadeBase
    {
        protected IUnitOfWork<CasandoContext> unitOfWork;
        protected bool disposing;

        public Repositorio(IUnitOfWork<CasandoContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            if (!disposing) 
                disposing = true;
        }

        public T Inclui(T obj)
        {
            var objCriado = unitOfWork.Context.Set<T>().Add(obj);
            unitOfWork.Save();

            return objCriado;
        }

        public void Altera(T obj)
        {
            unitOfWork.Context.Set<T>().Attach(obj);
            unitOfWork.Context.Entry(obj).State = EntityState.Modified;
            SaveChanges();
        }

        public void Exclui(T obj)
        {
            unitOfWork.Context.Set<T>().Remove(obj);
        }

        public void Exclui(int id)
        {
            var context = unitOfWork.Context;
            var entidade = context.Set<T>().Find(id);
            context.Set<T>().Remove(entidade);
        }

        public void SaveChanges()
        {
            unitOfWork.Context.SaveChanges();
        }

        public IEnumerable<T> Todos()
        {
            return unitOfWork.Context.Set<T>();
        }

        public T Buscar(int id)
        {
            var entidade = unitOfWork.Context.Set<T>().Find(id);

            if(entidade == null)
                throw new Exception("O registro não existe.");

            return entidade;
        }
    }
}
