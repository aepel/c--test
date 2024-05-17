using Qualyt.Data.Repositories.Interfaces;

namespace Qualyt.Data
{
    public interface IUnitOfWork
    {


        int SaveChanges();
    }
}
