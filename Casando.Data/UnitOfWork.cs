using Casando.Data.Interfaces;

namespace Casando.Data
{
    public class UnitOfWork : IUnitOfWork<CasandoContext>
    {
        private readonly CasandoContext casandoContext;

        public UnitOfWork()
        {
            casandoContext = new CasandoContext();
        }

        public CasandoContext Context { get { return casandoContext; } }

        public void Save()
        {
            casandoContext.SaveChanges();
        }

        public void Dispose()
        {
            Save();
            casandoContext.Dispose();
        }
    }
}
