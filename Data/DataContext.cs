using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Substitua "SEJA_WepApp" pelo nome real do seu projeto, se for diferente.
namespace SEJA_WepApp.Data 
{
    // MUITO IMPORTANTE: Herde de 'IdentityDbContext' em vez de 'DbContext'
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}