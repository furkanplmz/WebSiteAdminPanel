using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSiteAdminPanel.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        public int SliderId { get; set; }

        [Required]
        [StringLength(500)]
        public string Baslik { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [StringLength(500)]
        public string ResimUrl { get; set; }

    }
}