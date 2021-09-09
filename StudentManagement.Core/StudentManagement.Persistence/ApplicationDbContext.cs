using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domaine.Entities;
using StudentManagement.Domaine.Repositories;

namespace StudentManagement.Persistence
{
   
    public sealed class ApplicationDbContext : IdentityDbContext<User, Role, Guid>, IUnitOfWork
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

      
       

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
         
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
