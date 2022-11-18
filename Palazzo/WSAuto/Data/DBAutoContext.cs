using Microsoft.EntityFrameworkCore;
using WSAuto.Modelos;

namespace WSAuto.Data
{
    public class DBAutoContext : DbContext
    {
        public DBAutoContext(DbContextOptions<DBAutoContext>options ): base (options) { }

        public DbSet<Auto> Autos { get; set; }
    }
}
