namespace WebSiteAdminPanel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Site")]
    public partial class Site
    {
        public int SiteId { get; set; }

        [StringLength(50)]
        public string Baslik { get; set; }

        [StringLength(50)]
        public string AnahtarKelimeler { get; set; }

        [StringLength(500)]
        public string Tanim { get; set; }

        [StringLength(500)]
        public string LogoUrl { get; set; }

        [StringLength(500)]
        public string Unvan { get; set; }
    }
}
