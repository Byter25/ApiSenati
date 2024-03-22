using Microsoft.EntityFrameworkCore;

namespace AppCosoleAPI
{
    // Se define una clase 'SenatiContext' que hereda de 'DbContext'
    // una clase de Entity Framework Core que representa una sesión con la base de datos.
    public class SenatiContext : DbContext
    {
        
        public SenatiContext(DbContextOptions<SenatiContext> options) : base(options) { }

        //Definimos las propiedades de tipo 'DbSet' para cada entidad que se quiere mapear a la base de datos.
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Conocimiento> Conocimientos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<TecnicosProyecto> TecnicosProyectos { get; set; }


        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<TecnicosProyecto>().HasKey(x => new {x.TecnicoId,x.ProyectoId});

        //}

    }

}
