using System.Threading.Tasks;

namespace StudentManagement.Domaine.Repositories
{
    public interface IUnitOfWork
    {
       
        int SaveChanges();
        /// <summary>
        /// async save changes
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
       
       
    }
}
