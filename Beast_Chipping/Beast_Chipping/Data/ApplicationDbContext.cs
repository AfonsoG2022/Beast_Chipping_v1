using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Beast_Chipping.Models;

namespace Beast_Chipping.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Beast_Chipping.Models.Artigo>? Artigo { get; set; }
        public DbSet<Beast_Chipping.Models.Categoria>? Categoria { get; set; }
        public DbSet<Beast_Chipping.Models.Cliente>? Cliente { get; set; }
        public DbSet<Beast_Chipping.Models.Encomenda>? Encomenda { get; set; }
        public DbSet<Beast_Chipping.Models.Foto>? Foto { get; set; }
        public DbSet<Beast_Chipping.Models.Produto>? Produto { get; set; }
    }
}