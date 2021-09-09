using System.Linq;

namespace StudentManagement.Domaine.Repositories
{
    public interface IRepository<TEntity> 
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> Table { get; }

       
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        
    }
}