namespace WebSiteAdminPanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogId { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        [Required]
        public string Icerik { get; set; }

        [StringLength(500)]
        public string ResimUrl { get; set; }

        public int? KategoriId { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
