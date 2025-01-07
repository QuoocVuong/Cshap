using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLDKhoa_CNTT.DAL.Entities;

namespace QLDKhoa_CNTT.DAL;

public partial class QuanLyDiemKhoaCNTTContext : DbContext
{
    public QuanLyDiemKhoaCNTTContext()
    {
    }

    public QuanLyDiemKhoaCNTTContext(DbContextOptions<QuanLyDiemKhoaCNTTContext> options)
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

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

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

            entity.HasOne(d => d.IdLanThiNavigation).WithMany(p => p.Diems)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Diem__ID_LanThi__4F7CD00D");

            entity.HasOne(d => d.IdSinhVienNavigation).WithMany(p => p.Diems).HasConstraintName("FK__Diem__ID_SinhVie__4E88ABD4");
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GiangVie__3214EC27F9A4D8B2");

            entity.ToTable("GiangVien", tb => tb.HasTrigger("TR_GiangVien_Insert_AssignRole"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.GiangViens).HasConstraintName("FK_GiangVien_Users");
        });

        modelBuilder.Entity<HocKy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HocKy__3214EC272C3B5664");

            entity.HasOne(d => d.IdNamHocNavigation).WithMany(p => p.HocKies).HasConstraintName("FK__HocKy__ID_NamHoc__44FF419A");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khoa__3214EC278D500B06");
        });

        modelBuilder.Entity<LanThi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LanThi__3214EC27E967FB2F");

            entity.HasOne(d => d.IdMonHocNavigation).WithMany(p => p.LanThis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LanThi__ID_MonHo__4BAC3F29");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LopHoc__3214EC272848ED99");

            entity.HasOne(d => d.IdNganhNavigation).WithMany(p => p.LopHocs).HasConstraintName("FK__LopHoc__ID_Nganh__3C69FB99");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonHoc__3214EC27DF4B03DB");

            entity.HasOne(d => d.IdHocKyNavigation).WithMany(p => p.MonHocs).HasConstraintName("FK__MonHoc__ID_HocKy__48CFD27E");

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
        });

        modelBuilder.Entity<NganhHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NganhHoc__3214EC27BCAD0FF6");

            entity.HasOne(d => d.IdKhoaNavigation).WithMany(p => p.NganhHocs).HasConstraintName("FK__NganhHoc__ID_Kho__398D8EEE");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB0F136CC2EF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AE25F0E53");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.PermissionId }).HasName("PK__RolePerm__6400A18AE49D805E");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__Permi__2BFE89A6");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RolePermi__RoleI__2B0A656D");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SinhVien__3214EC270C95AF4B");

            entity.ToTable("SinhVien", tb => tb.HasTrigger("TR_SinhVien_Insert_AssignRole"));

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdLopNavigation).WithMany(p => p.SinhViens).HasConstraintName("FK__SinhVien__ID_Lop__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.SinhViens).HasConstraintName("FK_SinhVien_Users");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3214EC278D2B42DC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC0C46A584");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__UserRole__AF27604FAB261007");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoles__RoleI__2739D489");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoles__UserI__2645B050");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
