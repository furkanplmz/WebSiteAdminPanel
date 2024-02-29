namespace WebSiteAdminPanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hizmet")]
    public partial class Hizmet
    {
        public int HizmetId { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }

        [StringLength(50)]
        public string ResimUrl { get; set; }
    }
}
