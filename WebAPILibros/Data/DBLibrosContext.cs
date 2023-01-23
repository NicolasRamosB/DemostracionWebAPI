using Microsoft.EntityFrameworkCore;
using WebAPILibros.Models;

namespace WebAPILibros.Data
{
    public class DBLibrosContext : DbContext
    {
        //Constructor               En vez de pasarle KeyDB le personalizamos el Key
        public DBLibrosContext(DbContextOptions<DBLibrosContext> options) : base(options) { }
        
        //Propiedades DBSet

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros{ get; set; }
    }
}
