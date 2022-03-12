using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLTV.Models
{
    public partial class QLTV_DesktopContext : DbContext
    {
        public QLTV_DesktopContext() { }

        public QLTV_DesktopContext(DbContextOptions<QLTV_DesktopContext> options) : base(options)
        { }

        public virtual DbSet<TbAcount> TbAcounts { get; set; }
        public virtual DbSet<TbBbNhanlaisach> TbBbNhanlaisaches { get; set; }
        public virtual DbSet<TbCtNhanlai> TbCtNhanlais { get; set; }
        public virtual DbSet<TbCtPhieubangiao> TbCtPhieubangiaos { get; set; }
        public virtual DbSet<TbCtPhieuphat> TbCtPhieuphats { get; set; }
        public virtual DbSet<TbCtTacgium> TbCtTacgia { get; set; }
        public virtual DbSet<TbDausach> TbDausaches { get; set; }
        public virtual DbSet<TbDocgium> TbDocgia { get; set; }
        public virtual DbSet<TbNhanVien> TbNhanViens { get; set; }
        public virtual DbSet<TbPhieubangiaosach> TbPhieubangiaosaches { get; set; }
        public virtual DbSet<TbPhieuphat> TbPhieuphats { get; set; }
        public virtual DbSet<TbSach> TbSaches { get; set; }
        public virtual DbSet<TbTacgium> TbTacgia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("QLTV_Desktop"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAcount>(
                entity =>
                {
                    entity.HasNoKey();

                    entity.ToTable("tb_Acount");

                    entity.Property(e => e.Gmail).IsRequired().HasMaxLength(30);

                    entity
                        .Property(e => e.Manhanvien)
                        .ValueGeneratedOnAdd()
                        .HasColumnName("manhanvien");

                    entity.Property(e => e.Password).IsRequired().HasMaxLength(30);

                    entity.Property(e => e.Quyen).HasColumnName("quyen");

                    entity
                        .HasOne(d => d.ManhanvienNavigation)
                        .WithMany()
                        .HasForeignKey(d => d.Manhanvien)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tb_Acount__manha__59063A47");
                }
            );

            modelBuilder.Entity<TbBbNhanlaisach>(
                entity =>
                {
                    entity.HasKey(e => e.Mabbnhanlai).HasName("pk_bb_nhanlaisach");

                    entity.ToTable("tb_bb_nhanlaisach");

                    entity.Property(e => e.Mabbnhanlai).HasColumnName("mabbnhanlai");

                    entity.Property(e => e.Manhanvien).HasColumnName("manhanvien");

                    entity.Property(e => e.Mathedocgia).HasColumnName("mathedocgia");

                    entity
                        .Property(e => e.Ngaytra)
                        .HasColumnType("date")
                        .HasColumnName("ngaytra")
                        .HasDefaultValueSql("(getdate())");

                    entity
                        .HasOne(d => d.ManhanvienNavigation)
                        .WithMany(p => p.TbBbNhanlaisaches)
                        .HasForeignKey(d => d.Manhanvien)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_nhanvien_tb_bb_nhanlaisach");

                    entity
                        .HasOne(d => d.MathedocgiaNavigation)
                        .WithMany(p => p.TbBbNhanlaisaches)
                        .HasForeignKey(d => d.Mathedocgia)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_docgia_tb_bb_nhanlaisach");
                }
            );

            modelBuilder.Entity<TbCtNhanlai>(
                entity =>
                {
                    entity
                        .HasKey(e => new { e.Mabbnhanlai, e.Maquyensach })
                        .HasName("PK__tb_ct_nh__0EEC7FE1E16EB8E4");

                    entity.ToTable("tb_ct_nhanlai");

                    entity.Property(e => e.Mabbnhanlai).HasColumnName("mabbnhanlai");

                    entity.Property(e => e.Maquyensach).HasColumnName("maquyensach");

                    entity
                        .Property(e => e.Tinhtrangnhanlai)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("tinhtrangnhanlai");

                    entity
                        .HasOne(d => d.MabbnhanlaiNavigation)
                        .WithMany(p => p.TbCtNhanlais)
                        .HasForeignKey(d => d.Mabbnhanlai)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_bb_nhanlaisach_tb_ct_nhanlai");

                    entity
                        .HasOne(d => d.MaquyensachNavigation)
                        .WithMany(p => p.TbCtNhanlais)
                        .HasForeignKey(d => d.Maquyensach)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_sach_tb_ct_nhalai");
                }
            );

            modelBuilder.Entity<TbCtPhieubangiao>(
                entity =>
                {
                    entity
                        .HasKey(e => new { e.Maquyensach, e.Maphieubangiao })
                        .HasName("PK__tb_ct_ph__0BB572DA63F17DAC");

                    entity.ToTable("tb_ct_phieubangiao");

                    entity.Property(e => e.Maquyensach).HasColumnName("maquyensach");

                    entity.Property(e => e.Maphieubangiao).HasColumnName("maphieubangiao");

                    entity
                        .HasOne(d => d.MaphieubangiaoNavigation)
                        .WithMany(p => p.TbCtPhieubangiaos)
                        .HasForeignKey(d => d.Maphieubangiao)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_phieubangiaosach_tb_ct_phieubangiao");

                    entity
                        .HasOne(d => d.MaquyensachNavigation)
                        .WithMany(p => p.TbCtPhieubangiaos)
                        .HasForeignKey(d => d.Maquyensach)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_sach_tb_ct_phieubangiao");
                }
            );

            modelBuilder.Entity<TbCtPhieuphat>(
                entity =>
                {
                    entity
                        .HasKey(e => new { e.Maphieuphat, e.Maquyensach })
                        .HasName("PK__tb_ct_ph__C4C1A2A6BC3AE23D");

                    entity.ToTable("tb_ct_phieuphat");

                    entity.Property(e => e.Maphieuphat).HasColumnName("maphieuphat");

                    entity.Property(e => e.Maquyensach).HasColumnName("maquyensach");

                    entity.Property(e => e.Songayquahan).HasColumnName("songayquahan");

                    entity
                        .Property(e => e.Tinhtranghong)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("tinhtranghong");

                    entity
                        .HasOne(d => d.MaphieuphatNavigation)
                        .WithMany(p => p.TbCtPhieuphats)
                        .HasForeignKey(d => d.Maphieuphat)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_phieuphat_tb_ct_phieuphat");

                    entity
                        .HasOne(d => d.MaquyensachNavigation)
                        .WithMany(p => p.TbCtPhieuphats)
                        .HasForeignKey(d => d.Maquyensach)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_sach_tb_ct_phieuphat");
                }
            );

            modelBuilder.Entity<TbCtTacgium>(
                entity =>
                {
                    entity
                        .HasKey(e => new { e.Matacgia, e.Madausach })
                        .HasName("PK__tb_ct_ta__D0B63B97F026B7C9");

                    entity.ToTable("tb_ct_tacgia");

                    entity.Property(e => e.Matacgia).HasColumnName("matacgia");

                    entity.Property(e => e.Madausach).HasColumnName("madausach");

                    entity
                        .Property(e => e.Vaitrotacgia)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("vaitrotacgia");

                    entity
                        .HasOne(d => d.MadausachNavigation)
                        .WithMany(p => p.TbCtTacgia)
                        .HasForeignKey(d => d.Madausach)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_dausach_tb_ct_tacgia");

                    entity
                        .HasOne(d => d.MatacgiaNavigation)
                        .WithMany(p => p.TbCtTacgia)
                        .HasForeignKey(d => d.Matacgia)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_tacgia_tb_ct_tacgia");
                }
            );

            modelBuilder.Entity<TbDausach>(
                entity =>
                {
                    entity.HasKey(e => e.Madausach).HasName("pk_tb_dausach");

                    entity.ToTable("tb_dausach");

                    entity.Property(e => e.Madausach).HasColumnName("madausach");

                    entity
                        .Property(e => e.Soluong)
                        .HasColumnName("soluong")
                        .HasDefaultValueSql("('0')");

                    entity.Property(e => e.Sotrang).HasColumnName("sotrang");

                    entity
                        .Property(e => e.Tansuat)
                        .HasColumnName("tansuat")
                        .HasDefaultValueSql("((0))");

                    entity
                        .Property(e => e.Tendausach)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("tendausach");
                }
            );

            modelBuilder.Entity<TbDocgium>(
                entity =>
                {
                    entity.HasKey(e => e.Mathedocgia).HasName("pk_tb_docgia");

                    entity.ToTable("tb_docgia");

                    entity.Property(e => e.Mathedocgia).HasColumnName("mathedocgia");

                    entity
                        .Property(e => e.Diachi)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("diachi");

                    entity
                        .Property(e => e.Doituongdocgia)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("doituongdocgia");

                    entity
                        .Property(e => e.Hoten)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("hoten");

                    entity
                        .Property(e => e.Ngaylamthe)
                        .HasColumnType("date")
                        .HasColumnName("ngaylamthe")
                        .HasDefaultValueSql("(getdate())");

                    entity
                        .Property(e => e.Ngaysinh)
                        .HasColumnType("date")
                        .HasColumnName("ngaysinh")
                        .HasDefaultValueSql("(getdate())");
                }
            );

            modelBuilder.Entity<TbNhanVien>(
                entity =>
                {
                    entity.HasKey(e => e.Manhanvien).HasName("pk_tb_NhanVien");

                    entity.ToTable("tb_NhanVien");

                    entity.Property(e => e.Manhanvien).HasColumnName("manhanvien");

                    entity
                        .Property(e => e.Tennhanvien)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("tennhanvien");
                }
            );

            modelBuilder.Entity<TbPhieubangiaosach>(
                entity =>
                {
                    entity.HasKey(e => e.Maphieubangiao).HasName("pk_tb_phieubangiaosach");

                    entity.ToTable("tb_phieubangiaosach");

                    entity.Property(e => e.Maphieubangiao).HasColumnName("maphieubangiao");

                    entity.Property(e => e.Manhanvien).HasColumnName("manhanvien");

                    entity.Property(e => e.Mathedocgia).HasColumnName("mathedocgia");

                    entity
                        .Property(e => e.Ngaydukientra)
                        .HasColumnType("date")
                        .HasColumnName("ngaydukientra")
                        .HasDefaultValueSql("(getdate())");

                    entity
                        .Property(e => e.Ngaymuon)
                        .HasColumnType("date")
                        .HasColumnName("ngaymuon")
                        .HasDefaultValueSql("(getdate())");

                    entity
                        .Property(e => e.Tinhtrangkhigiao)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("tinhtrangkhigiao");

                    entity
                        .HasOne(d => d.ManhanvienNavigation)
                        .WithMany(p => p.TbPhieubangiaosaches)
                        .HasForeignKey(d => d.Manhanvien)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_ct_chomuon_tb_phieubangiaosach");

                    entity
                        .HasOne(d => d.MathedocgiaNavigation)
                        .WithMany(p => p.TbPhieubangiaosaches)
                        .HasForeignKey(d => d.Mathedocgia)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_ct_phieubangiao_tb_phieubangiaosach");
                }
            );

            modelBuilder.Entity<TbPhieuphat>(
                entity =>
                {
                    entity.HasKey(e => e.Maphieuphat).HasName("pk_tb_phieuphat");

                    entity.ToTable("tb_phieuphat");

                    entity.Property(e => e.Maphieuphat).HasColumnName("maphieuphat");

                    entity.Property(e => e.Mabbnhanlai).HasColumnName("mabbnhanlai");

                    entity
                        .Property(e => e.Tongtien)
                        .HasColumnName("tongtien")
                        .HasDefaultValueSql("('0')");

                    entity
                        .HasOne(d => d.MabbnhanlaiNavigation)
                        .WithMany(p => p.TbPhieuphats)
                        .HasForeignKey(d => d.Mabbnhanlai)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_bb_nhanlaisach_tb_phieuphat");
                }
            );

            modelBuilder.Entity<TbSach>(
                entity =>
                {
                    entity.HasKey(e => e.Maquyensach).HasName("pk_tb_sach");

                    entity.ToTable("tb_sach");

                    entity.Property(e => e.Maquyensach).HasColumnName("maquyensach");

                    entity.Property(e => e.Madausach).HasColumnName("madausach");

                    entity.Property(e => e.Tinhtrangsach).HasColumnName("tinhtrangsach");

                    entity
                        .HasOne(d => d.MadausachNavigation)
                        .WithMany(p => p.TbSaches)
                        .HasForeignKey(d => d.Madausach)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tb_dausach_tb_sach");
                }
            );

            modelBuilder.Entity<TbTacgium>(
                entity =>
                {
                    entity.HasKey(e => e.Matacgia).HasName("pk_tb_tacgia");

                    entity.ToTable("tb_tacgia");

                    entity.Property(e => e.Matacgia).HasColumnName("matacgia");

                    entity
                        .Property(e => e.Tentacgia)
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnName("tentacgia");
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
