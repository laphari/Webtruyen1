using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebsiteTruyen.Model
{
    public partial class WebsiteTruyenContext : DbContext
    {
        public WebsiteTruyenContext()
        {
        }

        public WebsiteTruyenContext(DbContextOptions<WebsiteTruyenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnhBia> AnhBia { get; set; }
        public virtual DbSet<ChitetTruyen> ChitetTruyen { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<NoiDungTruyen> NoiDungTruyen { get; set; }
        public virtual DbSet<QuyenHan> QuyenHan { get; set; }
        public virtual DbSet<TheLoai> TheLoai { get; set; }
        public virtual DbSet<Truyen> Truyen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-0DPIE1RR\\SQLEXPRESS;Database=WebsiteDocTruyen;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnhBia>(entity =>
            {
                entity.HasKey(e => e.IdanhBia)
                    .HasName("PK_Table_1_1");

                entity.Property(e => e.IdanhBia).ValueGeneratedNever();

                entity.HasOne(d => d.IdanhBiaNavigation)
                    .WithOne(p => p.AnhBia)
                    .HasForeignKey<AnhBia>(d => d.IdanhBia)
                    .HasConstraintName("FK_AnhBia_Truyen");
            });

            modelBuilder.Entity<ChitetTruyen>(entity =>
            {
                entity.HasKey(e => e.IdChitietTruyen)
                    .HasName("PK_Table_1");

                entity.Property(e => e.IdChitietTruyen).ValueGeneratedNever();

                entity.HasOne(d => d.IdChitietTruyenNavigation)
                    .WithOne(p => p.ChitetTruyen)
                    .HasForeignKey<ChitetTruyen>(d => d.IdChitietTruyen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChitetTruyen_Truyen");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.Property(e => e.IdNguoidung).ValueGeneratedNever();
            });

            modelBuilder.Entity<NoiDungTruyen>(entity =>
            {
                entity.HasOne(d => d.IdchietTietTruyenNavigation)
                    .WithMany(p => p.NoiDungTruyen)
                    .HasForeignKey(d => d.IdchietTietTruyen)
                    .HasConstraintName("FK_NoiDungTruyen_ChitetTruyen");
            });

            modelBuilder.Entity<QuyenHan>(entity =>
            {
                entity.Property(e => e.IdquyenHan).ValueGeneratedNever();

                entity.HasOne(d => d.IdquyenHanNavigation)
                    .WithOne(p => p.QuyenHanNavigation)
                    .HasForeignKey<QuyenHan>(d => d.IdquyenHan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuyenHan_NguoiDung");
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.Property(e => e.IdtheLoai).ValueGeneratedNever();
            });

            modelBuilder.Entity<Truyen>(entity =>
            {
                entity.Property(e => e.Idtruyen).ValueGeneratedNever();

                entity.HasOne(d => d.IdtheLoaiNavigation)
                    .WithMany(p => p.Truyen)
                    .HasForeignKey(d => d.IdtheLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Truyen_TheLoai");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
