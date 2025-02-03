using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Exame.Models.Clube> Clubes { get; set; } = default!;
        public DbSet<Exame.Models.Comentario> Comentarios { get; set; } = default!;
    }
}
