using Microsoft.EntityFrameworkCore;
using WebApiLibros.Entidades;

namespace WebApiLibros.Contexto
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
        DbSet<Autor>Autores { get; set; }
    }
}
