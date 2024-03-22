using ImobiControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ImobiControl.Data
{
    public class ImobiControlContext(DbContextOptions<ImobiControlContext> options) : DbContext(options)
    {
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
    }
}