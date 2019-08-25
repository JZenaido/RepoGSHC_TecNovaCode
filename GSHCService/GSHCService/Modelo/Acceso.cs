namespace GSHCService.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Acceso")]
    public partial class Acceso
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string strEmail { get; set; }

        [StringLength(50)]
        public string strPassword { get; set; }

        public string strPin { get; set; }

        public int? UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
