using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyPhongKhachSan.Models;

public partial class QlpksContext : DbContext
{
    public QlpksContext()
    {
    }

    public QlpksContext(DbContextOptions<QlpksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CanhBao> CanhBaos { get; set; }

    public virtual DbSet<ChiTietDuBao> ChiTietDuBaos { get; set; }

    public virtual DbSet<CongSuatPhong> CongSuatPhongs { get; set; }

    public virtual DbSet<CongSuatPhongBackup> CongSuatPhongBackups { get; set; }

    public virtual DbSet<CongSuatPhongImport> CongSuatPhongImports { get; set; }

    public virtual DbSet<CongSuatPhongTemp> CongSuatPhongTemps { get; set; }

    public virtual DbSet<DanhGiaMoHinh> DanhGiaMoHinhs { get; set; }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<DuBao> DuBaos { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoaDonBackup> HoaDonBackups { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KhuyenNghi> KhuyenNghis { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhatKyDuBao> NhatKyDuBaos { get; set; }

    public virtual DbSet<NhatKyHeThong> NhatKyHeThongs { get; set; }

    
    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<PhongBackup> PhongBackups { get; set; }

    public virtual DbSet<QuyetDinh> QuyetDinhs { get; set; }

    public virtual DbSet<VwCanhBaoTuDong> VwCanhBaoTuDongs { get; set; }

    public virtual DbSet<VwCongSuatPhong> VwCongSuatPhongs { get; set; }

    public virtual DbSet<VwDuLieuProphet> VwDuLieuProphets { get; set; }

    public virtual DbSet<VwHoTroQuyetDinh> VwHoTroQuyetDinhs { get; set; }

    public virtual DbSet<VwHoTroRaQuyetDinh> VwHoTroRaQuyetDinhs { get; set; }

    public virtual DbSet<VwKpi> VwKpis { get; set; }

    public virtual DbSet<VwThongKeKhachSan> VwThongKeKhachSans { get; set; }

    public virtual DbSet<VwTongHopDss> VwTongHopDsses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-I4NKHGBJ\\SQLEXPRESS;Database=QLPKS;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CanhBao>(entity =>
        {
            entity.HasKey(e => e.MaCanhBao).HasName("PK__CanhBao__73C23D930C4B018F");

            entity.ToTable("CanhBao");

            entity.Property(e => e.MucDo).HasMaxLength(20);
            entity.Property(e => e.NoiDung).HasMaxLength(500);
        });

        modelBuilder.Entity<ChiTietDuBao>(entity =>
        {
            entity.HasKey(e => e.MaChiTiet).HasName("PK__ChiTietD__CDF0A114CC7982D5");

            entity.ToTable("ChiTietDuBao");

            entity.HasIndex(e => e.MaDuBao, "IX_ChiTietDuBao_MaDuBao");

            entity.HasOne(d => d.MaDuBaoNavigation).WithMany(p => p.ChiTietDuBaos)
                .HasForeignKey(d => d.MaDuBao)
                .HasConstraintName("FK__ChiTietDu__MaDuB__5DCAEF64");
        });

        modelBuilder.Entity<CongSuatPhong>(entity =>
        {
            entity.HasKey(e => e.MaCongSuat).HasName("PK__CongSuat__7795A83D0F8909C2");

            entity.ToTable("CongSuatPhong");

            entity.HasIndex(e => e.Ngay, "IX_CongSuatPhong_Ngay");

            entity.HasIndex(e => e.Ngay, "UQ__CongSuat__6BCCE7B378FA88E7").IsUnique();
        });

        modelBuilder.Entity<CongSuatPhongBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CongSuatPhong_Backup");

            entity.Property(e => e.MaCongSuat).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<CongSuatPhongImport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CongSuatPhong_Import");

            entity.Property(e => e.DayOfWeek).HasMaxLength(50);
        });

        modelBuilder.Entity<CongSuatPhongTemp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CongSuatPhong_Temp");
        });

        modelBuilder.Entity<DanhGiaMoHinh>(entity =>
        {
            entity.HasKey(e => e.MaDanhGia).HasName("PK__DanhGiaM__AA9515BFF7FBF479");

            entity.ToTable("DanhGiaMoHinh");

            entity.Property(e => e.Mae).HasColumnName("MAE");
            entity.Property(e => e.Mape).HasColumnName("MAPE");
            entity.Property(e => e.NgayDanhGia)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rmse).HasColumnName("RMSE");
            entity.Property(e => e.TenMoHinh).HasMaxLength(50);
        });

        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => e.MaDatPhong).HasName("PK__DatPhong__6344ADEAC0B8008E");

            entity.ToTable("DatPhong", tb => tb.HasTrigger("trg_InsertDatPhong"));

            entity.HasIndex(e => e.MaKhachHang, "IX_DatPhong_MaKhachHang");

            entity.HasIndex(e => e.MaPhong, "IX_DatPhong_MaPhong");

            entity.HasIndex(e => e.NgayNhanPhong, "IX_DatPhong_NgayNhan");

            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DatPhong__MaKhac__5441852A");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DatPhong__MaPhon__5535A963");
        });

        modelBuilder.Entity<DuBao>(entity =>
        {
            entity.HasKey(e => e.MaDuBao).HasName("PK__DuBao__03C13C22275E2CCD");

            entity.ToTable("DuBao");

            entity.Property(e => e.MoHinhSuDung).HasMaxLength(50);
            entity.Property(e => e.NgayDuBao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13BFD90CC29");

            entity.ToTable("HoaDon");

            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(50);

            entity.HasOne(d => d.MaDatPhongNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaDatPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaDatPho__08B54D69");
        });

        modelBuilder.Entity<HoaDonBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HoaDon_Backup");

            entity.Property(e => e.MaHoaDon).ValueGeneratedOnAdd();
            entity.Property(e => e.NgayLap).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThaiThanhToan).HasMaxLength(50);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5D04AD159");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Cccd, "UQ_KhachHang_CCCD").IsUnique();

            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .HasColumnName("CCCD");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
        });

        modelBuilder.Entity<KhuyenNghi>(entity =>
        {
            entity.HasKey(e => e.MaKhuyenNghi).HasName("PK__KhuyenNg__032D0D048C3F1D46");

            entity.ToTable("KhuyenNghi");

            entity.HasIndex(e => e.MaDuBao, "IX_KhuyenNghi_MaDuBao");

            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasMaxLength(1000);

            entity.HasOne(d => d.MaDuBaoNavigation).WithMany(p => p.KhuyenNghis)
                .HasForeignKey(d => d.MaDuBao)
                .HasConstraintName("FK__KhuyenNgh__MaDuB__619B8048");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoaiPhong).HasName("PK__LoaiPhon__23021217E02AB8B5");

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.GiaCoBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenLoaiPhong).HasMaxLength(100);
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__C539D762E8C07BDF");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.TenDangNhap, "UQ__NguoiDun__55F68FC0F49FD54D").IsUnique();

            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
            entity.Property(e => e.VaiTro).HasMaxLength(20);
        });

        modelBuilder.Entity<NhatKyDuBao>(entity =>
        {
            entity.HasKey(e => e.MaNhatKy).HasName("PK__NhatKyDu__E42EF42E6009F545");

            entity.ToTable("NhatKyDuBao");

            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.Mae).HasColumnName("MAE");
            entity.Property(e => e.Mape).HasColumnName("MAPE");
            entity.Property(e => e.MoHinh).HasMaxLength(50);
            entity.Property(e => e.Rmse).HasColumnName("RMSE");
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<NhatKyHeThong>(entity =>
        {
            entity.HasKey(e => e.MaNhatKy).HasName("PK__NhatKyHe__E42EF42EF3B1166E");

            entity.ToTable("NhatKyHeThong");

            entity.Property(e => e.HanhDong).HasMaxLength(300);
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.NhatKyHeThongs)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK__NhatKyHeT__MaNgu__0C85DE4D");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__Phong__20BD5E5BB442C59E");

            entity.ToTable("Phong");

            entity.HasIndex(e => e.SoPhong, "UQ_Phong_SoPhong").IsUnique();

            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.SoPhong).HasMaxLength(20);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaLoaiPhongNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaLoaiPhong)
                .HasConstraintName("FK_Phong_LoaiPhong");
        });

        modelBuilder.Entity<PhongBackup>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Phong_Backup");

            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.MaPhong).ValueGeneratedOnAdd();
            entity.Property(e => e.SoPhong).HasMaxLength(20);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<QuyetDinh>(entity =>
        {
            entity.HasKey(e => e.MaQuyetDinh).HasName("PK__QuyetDin__3F6D3FCBD7077EBF");

            entity.ToTable("QuyetDinh");

            entity.HasIndex(e => e.MaDuBao, "IX_QuyetDinh_MaDuBao");

            entity.Property(e => e.LoaiQuyetDinh).HasMaxLength(100);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(50)
                .HasDefaultValue("Đã duyệt", "DF_QuyetDinh_TrangThai");

            entity.HasOne(d => d.MaDuBaoNavigation).WithMany(p => p.QuyetDinhs)
                .HasForeignKey(d => d.MaDuBao)
                .HasConstraintName("FK__QuyetDinh__MaDuB__17036CC0");
        });

        modelBuilder.Entity<VwCanhBaoTuDong>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CanhBaoTuDong");

            entity.Property(e => e.MucDo).HasMaxLength(10);
        });

        modelBuilder.Entity<VwCongSuatPhong>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CongSuatPhong");
        });

        modelBuilder.Entity<VwDuLieuProphet>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DuLieuProphet");

            entity.Property(e => e.Ds).HasColumnName("ds");
            entity.Property(e => e.Y).HasColumnName("y");
        });

        modelBuilder.Entity<VwHoTroQuyetDinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_HoTroQuyetDinh");

            entity.Property(e => e.DeXuat).HasMaxLength(21);
        });

        modelBuilder.Entity<VwHoTroRaQuyetDinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_HoTroRaQuyetDinh");

            entity.Property(e => e.KhuyenNghi).HasMaxLength(1000);
            entity.Property(e => e.MaDuBao).ValueGeneratedOnAdd();
            entity.Property(e => e.NgayDuBao).HasColumnType("datetime");
            entity.Property(e => e.QuyetDinh).HasMaxLength(1000);
        });

        modelBuilder.Entity<VwKpi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_KPI");
        });

        modelBuilder.Entity<VwThongKeKhachSan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ThongKeKhachSan");
        });

        modelBuilder.Entity<VwTongHopDss>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_TongHopDSS");

            entity.Property(e => e.MaDuBao).ValueGeneratedOnAdd();
            entity.Property(e => e.Mae).HasColumnName("MAE");
            entity.Property(e => e.Mape).HasColumnName("MAPE");
            entity.Property(e => e.MoHinhSuDung).HasMaxLength(50);
            entity.Property(e => e.NgayDuBao).HasColumnType("datetime");
            entity.Property(e => e.Rmse).HasColumnName("RMSE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
