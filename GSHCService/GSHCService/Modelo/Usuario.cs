namespace GSHCService.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Acceso = new HashSet<Acceso>();
        }

        public int Id { get; set; }

        [StringLength(150)]
        public string strNombre { get; set; }

        [StringLength(150)]
        public string strnApellidoPaterno { get; set; }

        [StringLength(150)]
        public string strnApellidoMaterno { get; set; }

        [StringLength(10)]
        public string strnTelefono { get; set; }

        public byte[] imgFotoPerfil { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acceso> Acceso { get; set; }
    }
}
