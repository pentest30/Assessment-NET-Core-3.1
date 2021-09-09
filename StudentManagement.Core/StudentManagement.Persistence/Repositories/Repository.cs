using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext DbContext;

        protected DbSet<T> DbSet => DbContext.Set<T>();

        public IUnitOfWork UnitOfWork => DbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Add(T entity)
        {
          
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Update(entity);
        }
       
        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> Table => DbContext.Set<T>();
        
    }
}
