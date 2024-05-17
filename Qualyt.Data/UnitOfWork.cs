using Qualyt.Data.Repositories;
using Qualyt.Data.Repositories.Interfaces;

namespace Qualyt.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly MCADbContext _context;



        public UnitOfWork(MCADbContext context)
        {
            _context = context;
        }




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
