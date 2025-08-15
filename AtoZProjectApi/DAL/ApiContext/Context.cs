using AtoZProjectApi.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace AtoZProjectApi.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
            (
                "server = YUSUF_BILGIN\\SQLEXPRESS;" +
                " database=CoreProjeDB2; " +
                "integrated security = true"
            );
        }

        public DbSet<Category> Categories { get; set; }
    }
}
