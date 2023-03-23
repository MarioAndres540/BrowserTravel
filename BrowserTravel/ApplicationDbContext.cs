using BrowserTravel.Entidades;
using BrowserTravel.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrowserTravel
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) :  base(options)
        {
            
        }
        //aplifluente
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
        //se crea la tabla Autores a partir de la clase Autor
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public DbSet<Editorials> Editoriales  { get; set; }
    }
}
