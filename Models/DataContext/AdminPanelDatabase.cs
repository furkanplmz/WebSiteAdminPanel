using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using WebSiteAdminPanel.Models;
using WebSiteAdminPanel.Models.Model;

namespace WebSiteAdminPanel.Models
{
    public partial class AdminPanelDatabase : DbContext
    {
        public AdminPanelDatabase()
            : base("name=AdminPanelDatabase")
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Hakkimizda> Hakkimizda { get; set; }
        public virtual DbSet<Hizmet> Hizmet { get; set; }
        public virtual DbSet<Iletisim> Iletisim { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Yetki)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Baslik)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.Icerik)
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.ResimUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Hakkimizda>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Hizmet>()
                .Property(e => e.Baslik)
                .IsUnicode(false);

            modelBuilder.Entity<Hizmet>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Hizmet>()
                .Property(e => e.ResimUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Whatsapp)
                .IsUnicode(false);

            modelBuilder.Entity<Iletisim>()
                .Property(e => e.Twitter)
                .IsUnicode(false);

            modelBuilder.Entity<Kategori>()
                .Property(e => e.KategoriAd)
                .IsUnicode(false);

            modelBuilder.Entity<Kategori>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Site>()
                .Property(e => e.Baslik)
                .IsUnicode(false);

            modelBuilder.Entity<Site>()
                .Property(e => e.AnahtarKelimeler)
                .IsUnicode(false);

            modelBuilder.Entity<Site>()
                .Property(e => e.Tanim)
                .IsUnicode(false);

            modelBuilder.Entity<Site>()
                .Property(e => e.LogoUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Site>()
                .Property(e => e.Unvan)
                .IsUnicode(false);    
        }
    }
}
