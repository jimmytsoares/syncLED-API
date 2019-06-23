using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SyncLED.Models
{
    public partial class SyncLED_DBContext : DbContext
    {
        public SyncLED_DBContext()
        {
        }

        public SyncLED_DBContext(DbContextOptions<SyncLED_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Luminarias> Luminarias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:syncled.database.windows.net,1433;Initial Catalog=SyncLED_DB;Persist Security Info=False;User ID=syncled;Password=adminTCC!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Luminarias>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
