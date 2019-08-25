namespace GSHCService.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GSHCTec : DbContext
    {
        public GSHCTec()
            : base("name=GSHCTec1")
        {
        }

        public virtual DbSet<Acceso> Acceso { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acceso>()
                .Property(e => e.strEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Acceso>()
                .Property(e => e.strPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Acceso>()
                .Property(e => e.strPin)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.strNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.strnApellidoPaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.strnApellidoMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.strnTelefono)
                .IsUnicode(false);
        }
    }
}
