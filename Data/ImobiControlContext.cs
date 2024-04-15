using ImobiControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ImobiControl.Data
{
    public class ImobiControlContext(DbContextOptions<ImobiControlContext> options) : DbContext(options)
    {
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Foto> Foto  { get; set; }
    }
}