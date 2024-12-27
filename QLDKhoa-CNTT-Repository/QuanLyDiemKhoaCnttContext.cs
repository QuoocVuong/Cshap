using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLDKhoa_CNTT.DAL.Entities;

namespace QLDKhoa_CNTT.DAL;

public partial class QuanLyDiemKhoaCnttContext : DbContext
{
    public QuanLyDiemKhoaCnttContext()
    {
    }

    public QuanLyDiemKhoaCnttContext(DbContextOptions<QuanLyDiemKhoaCnttContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Diem> Diems { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<HocKy> HocKies { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<LanThi> LanThis { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<NamHoc> NamHocs { get; set; }

    public virtual DbSet<NganhHoc> NganhHocs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    private string? GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        return configuration["ConnectionStrings:QuanLyDiemKhoaCNTT"];
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diem__3214EC27BB5BA411");

            entity.ToTable("Diem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Diem1).HasColumnName("Diem");
            entity.Property(e => e.IdLanThi).HasColumnName("ID_LanThi");
            entity.Property(e => e.IdSinhVien).HasColumnName("ID_SinhVien");

            entity.HasOne(d => d.IdLanThiNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.IdLanThi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diem__ID_LanThi__4F7CD00D");

            entity.HasOne(d => d.IdSinhVienNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.IdSinhVien)
                .HasConstraintName("FK__Diem__ID_SinhVie__4E88ABD4");
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GiangVie__3214EC27F9A4D8B2");

            entity.ToTable("GiangVien");

            entity.HasIndex(e => e.MaGiangVien, "UQ__GiangVie__C03BEEBB000B30CE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaGiangVien).HasMaxLength(50);
            entity.Property(e => e.TenGiangVien).HasMaxLength(255);
        });

        modelBuilder.Entity<HocKy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HocKy__3214EC272C3B5664");

            entity.ToTable("HocKy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdNamHoc).HasColumnName("ID_NamHoc");
            entity.Property(e => e.TenHocKy).HasMaxLength(50);

            entity.HasOne(d => d.IdNamHocNavigation).WithMany(p => p.HocKies)
                .HasForeignKey(d => d.IdNamHoc)
                .HasConstraintName("FK__HocKy__ID_NamHoc__44FF419A");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khoa__3214EC278D500B06");

            entity.ToTable("Khoa");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenKhoa).HasMaxLength(255);
        });

        modelBuilder.Entity<LanThi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LanThi__3214EC27E967FB2F");

            entity.ToTable("LanThi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdMonHoc).HasColumnName("ID_MonHoc");
            entity.Property(e => e.LanThi1).HasColumnName("LanThi");

            entity.HasOne(d => d.IdMonHocNavigation).WithMany(p => p.LanThis)
                .HasForeignKey(d => d.IdMonHoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LanThi__ID_MonHo__4BAC3F29");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LopHoc__3214EC272848ED99");

            entity.ToTable("LopHoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdNganh).HasColumnName("ID_Nganh");
            entity.Property(e => e.TenLop).HasMaxLength(50);

            entity.HasOne(d => d.IdNganhNavigation).WithMany(p => p.LopHocs)
                .HasForeignKey(d => d.IdNganh)
                .HasConstraintName("FK__LopHoc__ID_Nganh__3C69FB99");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonHoc__3214EC27DF4B03DB");

            entity.ToTable("MonHoc");

            entity.HasIndex(e => e.MaMonHoc, "UQ__MonHoc__4127737E3AA595E0").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdHocKy).HasColumnName("ID_HocKy");
            entity.Property(e => e.MaMonHoc).HasMaxLength(50);
            entity.Property(e => e.TenMonHoc).HasMaxLength(255);

            entity.HasOne(d => d.IdHocKyNavigation).WithMany(p => p.MonHocs)
                .HasForeignKey(d => d.IdHocKy)
                .HasConstraintName("FK__MonHoc__ID_HocKy__48CFD27E");

            entity.HasMany(d => d.IdGiangViens).WithMany(p => p.IdMonHocs)
                .UsingEntity<Dictionary<string, object>>(
                    "MonHocGiangVien",
                    r => r.HasOne<GiangVien>().WithMany()
                        .HasForeignKey("IdGiangVien")
                        .HasConstraintName("FK__MonHoc_Gi__ID_Gi__59063A47"),
                    l => l.HasOne<MonHoc>().WithMany()
                        .HasForeignKey("IdMonHoc")
                        .HasConstraintName("FK__MonHoc_Gi__ID_Mo__5812160E"),
                    j =>
                    {
                        j.HasKey("IdMonHoc", "IdGiangVien").HasName("PK__MonHoc_G__158F29AEFB3C8BE8");
                        j.ToTable("MonHoc_GiangVien");
                        j.IndexerProperty<int>("IdMonHoc").HasColumnName("ID_MonHoc");
                        j.IndexerProperty<int>("IdGiangVien").HasColumnName("ID_GiangVien");
                    });
        });

        modelBuilder.Entity<NamHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NamHoc__3214EC27DC7770A3");

            entity.ToTable("NamHoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenNamHoc).HasMaxLength(50);
        });

        modelBuilder.Entity<NganhHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NganhHoc__3214EC27BCAD0FF6");

            entity.ToTable("NganhHoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdKhoa).HasColumnName("ID_Khoa");
            entity.Property(e => e.TenNganhHoc).HasMaxLength(255);

            entity.HasOne(d => d.IdKhoaNavigation).WithMany(p => p.NganhHocs)
                .HasForeignKey(d => d.IdKhoa)
                .HasConstraintName("FK__NganhHoc__ID_Kho__398D8EEE");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SinhVien__3214EC270C95AF4B");

            entity.ToTable("SinhVien");

            entity.HasIndex(e => e.MaSinhVien, "UQ__SinhVien__939AE7745FBEFB86").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdLop).HasColumnName("ID_Lop");
            entity.Property(e => e.MaSinhVien).HasMaxLength(50);
            entity.Property(e => e.TenSinhVien).HasMaxLength(255);

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.IdLop)
                .HasConstraintName("FK__SinhVien__ID_Lop__403A8C7D");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3214EC278D2B42DC");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC096E6CC06").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.IdNguoiDung).HasColumnName("ID_NguoiDung");
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
