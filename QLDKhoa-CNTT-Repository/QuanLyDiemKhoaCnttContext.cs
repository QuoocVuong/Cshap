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

    public virtual DbSet<HinhThuc> HinhThucs { get; set; }

    public virtual DbSet<HocKy> HocKies { get; set; }

    public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }

    public virtual DbSet<LanThi> LanThis { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    public virtual DbSet<NganhHoc> NganhHocs { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer(GetConnectionString());
    //ham doc chuoi ket noi csdl tu file cau hinh appsettings.json
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
            entity.HasKey(e => e.Id).HasName("PK__Diem__3214EC2763EB33E9");

            entity.ToTable("Diem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Diem1).HasColumnName("Diem");
            entity.Property(e => e.IdMonHoc).HasColumnName("ID_MonHoc");
            entity.Property(e => e.IdSinhVien).HasColumnName("ID_SinhVien");
            entity.Property(e => e.IdlanThi).HasColumnName("IDLanThi");

            entity.HasOne(d => d.IdMonHocNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.IdMonHoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diem__ID_MonHoc__4E88ABD4");

            entity.HasOne(d => d.IdSinhVienNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.IdSinhVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diem__ID_SinhVie__4D94879B");

            entity.HasOne(d => d.IdlanThiNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.IdlanThi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diem__IDLanThi__4F7CD00D");
        });

        modelBuilder.Entity<HinhThuc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HinhThuc__3214EC27F5C0D02D");

            entity.ToTable("HinhThuc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HinhThuc1)
                .HasMaxLength(255)
                .HasColumnName("HinhThuc");
            entity.Property(e => e.IdHocKy).HasColumnName("ID_HocKy");

            entity.HasOne(d => d.IdHocKyNavigation).WithMany(p => p.HinhThucs)
                .HasForeignKey(d => d.IdHocKy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HinhThuc__ID_Hoc__3F466844");
        });

        modelBuilder.Entity<HocKy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HocKy__3214EC2774444EDC");

            entity.ToTable("HocKy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdNganhHoc).HasColumnName("ID_NganhHoc");
            entity.Property(e => e.TenHocKy).HasMaxLength(50);

            entity.HasOne(d => d.IdNganhHocNavigation).WithMany(p => p.HocKies)
                .HasForeignKey(d => d.IdNganhHoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HocKy__ID_NganhH__3C69FB99");
        });

        modelBuilder.Entity<KhoaHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KhoaHoc__3214EC27FAFD4586");

            entity.ToTable("KhoaHoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TenKhoa).HasMaxLength(255);
        });

        modelBuilder.Entity<LanThi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LanThi__3214EC27DE2E1C89");

            entity.ToTable("LanThi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdMonHoc).HasColumnName("ID_MonHoc");
            entity.Property(e => e.LanThi1).HasColumnName("LanThi");

            entity.HasOne(d => d.IdMonHocNavigation).WithMany(p => p.LanThis)
                .HasForeignKey(d => d.IdMonHoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LanThi__ID_MonHo__4AB81AF0");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LopHoc__3214EC27EC78F99A");

            entity.ToTable("LopHoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdNganh).HasColumnName("ID_Nganh");
            entity.Property(e => e.TenLop).HasMaxLength(50);

            entity.HasOne(d => d.IdNganhNavigation).WithMany(p => p.LopHocs)
                .HasForeignKey(d => d.IdNganh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LopHoc__ID_Nganh__4222D4EF");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonHoc__3214EC2737642F3A");

            entity.ToTable("MonHoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdHinhThuc).HasColumnName("ID_HinhThuc");
            entity.Property(e => e.MaMonHoc).HasMaxLength(50);
            entity.Property(e => e.TenMonHoc).HasMaxLength(255);

            entity.HasOne(d => d.IdHinhThucNavigation).WithMany(p => p.MonHocs)
                .HasForeignKey(d => d.IdHinhThuc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MonHoc__ID_HinhT__47DBAE45");
        });

        modelBuilder.Entity<NganhHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NganhHoc__3214EC274E32B14D");

            entity.ToTable("NganhHoc");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdKhoa).HasColumnName("ID_Khoa");
            entity.Property(e => e.TenNganhHoc).HasMaxLength(255);

            entity.HasOne(d => d.IdKhoaNavigation).WithMany(p => p.NganhHocs)
                .HasForeignKey(d => d.IdKhoa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NganhHoc__ID_Kho__398D8EEE");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SinhVien__3214EC2791727C93");

            entity.ToTable("SinhVien");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdLop).HasColumnName("ID_Lop");
            entity.Property(e => e.MaSinhVien).HasMaxLength(50);
            entity.Property(e => e.TenSinhVien).HasMaxLength(255);

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.IdLop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SinhVien__ID_Lop__44FF419A");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3214EC2729B7A90D");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0F427DCD6").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.GhiChu).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
