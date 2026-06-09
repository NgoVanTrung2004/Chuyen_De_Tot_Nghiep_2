CREATE DATABASE QLPKS;
GO

USE QLPKS;
GO

--BẢNG NGƯỜI DÙNG--
CREATE TABLE NguoiDung
(
    MaNguoiDung INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    HoTen NVARCHAR(100),
    VaiTro NVARCHAR(20),
    TrangThai BIT DEFAULT 1
);

--BẢNG LOẠI PHÒNG--
CREATE TABLE LoaiPhong
(
    MaLoaiPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenLoaiPhong NVARCHAR(100),
    GiaCoBan DECIMAL(18,2),
    MoTa NVARCHAR(500)
);

--BẢNG PHÒNG--
CREATE TABLE Phong
(
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    SoPhong NVARCHAR(20),
    MaLoaiPhong INT,
    TrangThai NVARCHAR(50),
    CONSTRAINT FK_Phong_LoaiPhong
    FOREIGN KEY(MaLoaiPhong)
    REFERENCES LoaiPhong(MaLoaiPhong)
);

--BẢNG KHÁCH HÀNG--
CREATE TABLE KhachHang
(
    MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100),
    CCCD NVARCHAR(20),
    SoDienThoai NVARCHAR(20),
    Email NVARCHAR(100)
);

--BẢNG ĐẶT PHÒNG--
CREATE TABLE DatPhong
(
    MaDatPhong INT IDENTITY(1,1) PRIMARY KEY,
    MaKhachHang INT NOT NULL,
    MaPhong INT NOT NULL,
    NgayNhanPhong DATE,
    NgayTraPhong DATE,
    TongTien DECIMAL(18,2),
    TrangThai NVARCHAR(50),
    FOREIGN KEY(MaKhachHang)
    REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY(MaPhong)
    REFERENCES Phong(MaPhong)
);

--BẢNG CÔNG SUẤT PHÒNG--
CREATE TABLE CongSuatPhong
(
    MaCongSuat INT IDENTITY(1,1) PRIMARY KEY,
    Ngay DATE NOT NULL UNIQUE,
    TongPhong INT NOT NULL,
    PhongDaDat INT NOT NULL,
    TyLeCongSuat FLOAT NOT NULL
);
-------------------------------------------------
CREATE TABLE CongSuatPhong_Temp
(
    Date DATE,
    BookedRooms INT,
    OccupancyRate FLOAT,
    RollingMean7 FLOAT,
    Month INT,
    DayOfWeek INT
);
-----------------------------------------------
--BẢNG DỰ BÁO--
CREATE TABLE DuBao
(
    MaDuBao INT IDENTITY(1,1) PRIMARY KEY,
    NgayDuBao DATETIME DEFAULT GETDATE(),
    SoNgayDuBao INT,
    CongSuatTrungBinh FLOAT,
    MoHinhSuDung NVARCHAR(50)
);

--BẢNG CHI TIẾT DỰ BÁO--
CREATE TABLE ChiTietDuBao
(
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaDuBao INT,
    Ngay DATE,
    CongSuatDuBao FLOAT,
    FOREIGN KEY(MaDuBao)
    REFERENCES DuBao(MaDuBao)
);

--BẢNG KHUYẾN NGHỊ--
CREATE TABLE KhuyenNghi
(
    MaKhuyenNghi INT IDENTITY(1,1) PRIMARY KEY,
    MaDuBao INT,
    NoiDung NVARCHAR(1000),
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY(MaDuBao)
    REFERENCES DuBao(MaDuBao)
);

--BẢNG LỊCH SỬ DỰ BÁO--
CREATE TABLE NhatKyDuBao
(
    MaNhatKy INT IDENTITY(1,1) PRIMARY KEY,
    ThoiGian DATETIME DEFAULT GETDATE(),
    MoHinh NVARCHAR(50),
    SoNgayDuBao INT,
    RMSE FLOAT,
    MAE FLOAT,
    MAPE FLOAT,
    GhiChu NVARCHAR(500)
);

--BẢNG CẢNH BÁO--
CREATE TABLE CanhBao
(
    MaCanhBao INT IDENTITY(1,1) PRIMARY KEY,
    NgayCanhBao DATE,
    MucDo NVARCHAR(20),
    NoiDung NVARCHAR(500)
);

--BẢNG HÓA ĐƠN--
CREATE TABLE HoaDon
(
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    MaDatPhong INT NOT NULL,
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,2),
    TrangThaiThanhToan NVARCHAR(50),
    FOREIGN KEY(MaDatPhong)
    REFERENCES DatPhong(MaDatPhong)
);

--BẢNG NHẬT KÝ HỆ THỐNG--
CREATE TABLE NhatKyHeThong
(
    MaNhatKy INT IDENTITY(1,1) PRIMARY KEY,
    MaNguoiDung INT,
    HanhDong NVARCHAR(300),
    ThoiGian DATETIME DEFAULT GETDATE(),
    FOREIGN KEY(MaNguoiDung)
    REFERENCES NguoiDung(MaNguoiDung)
);

--BẢNG RA QUYẾT ĐỊNH--
CREATE TABLE QuyetDinh
(
    MaQuyetDinh INT IDENTITY(1,1) PRIMARY KEY,
    MaDuBao INT,
    LoaiQuyetDinh NVARCHAR(100),
    NoiDung NVARCHAR(1000),
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY(MaDuBao)
    REFERENCES DuBao(MaDuBao)
);

CREATE TABLE DanhGiaMoHinh
(
    MaDanhGia INT IDENTITY(1,1) PRIMARY KEY,
    TenMoHinh NVARCHAR(50),
    RMSE FLOAT,
    MAE FLOAT,
    MAPE FLOAT,
    NgayDanhGia DATETIME DEFAULT GETDATE()
);
-------------------------------------------------------
--DỮ LIỆU MẪU
------------------------------------------------------
--LOẠI PHÒNG
INSERT INTO LoaiPhong
VALUES
(N'Standard',500000,N'Phòng tiêu chuẩn'),
(N'Deluxe',800000,N'Phòng cao cấp'),
(N'VIP',1500000,N'Phòng VIP');

--PHÒNG
INSERT INTO Phong
VALUES
('P101',1,N'Trống'),
('P102',1,N'Trống'),
('P201',2,N'Trống'),
('P202',2,N'Trống'),
('P301',3,N'Trống');
--tạo thêm phòng
DECLARE @i INT = 1000;

WHILE (SELECT COUNT(*) FROM Phong) < 255
BEGIN
    INSERT INTO Phong
    (
        SoPhong,
        MaLoaiPhong,
        TrangThai
    )
    VALUES
    (
        'P' + CAST(@i AS VARCHAR(10)),
        ((@i - 1000) % 3) + 1,
        N'Trống'
    );

    SET @i = @i + 1;
END

--NGƯỜI DÙNG
INSERT INTO NguoiDung
VALUES
('admin','123456',N'Quản trị viên','Admin',1),

INSERT INTO NguoiDung
VALUES
('nhanvien','123456',N'Nhân viên','NhanVien',1);

--------------------------
--------------------------
--TẠO 200 KHÁCH HÀNG
SET NOCOUNT ON;

DECLARE @i INT = 1;

WHILE @i <= 200
BEGIN
    INSERT INTO KhachHang (HoTen, CCCD, SoDienThoai, Email)
    VALUES (
        N'Khách hàng ' + CAST(@i AS NVARCHAR),
        RIGHT('000000000000' + CAST(ABS(CHECKSUM(NEWID())) % 999999999999 AS NVARCHAR), 12),
        '09' + RIGHT('000000000' + CAST(ABS(CHECKSUM(NEWID())) % 999999999 AS NVARCHAR), 8),
        'khachhang' + CAST(@i AS NVARCHAR) + '@mail.com'
    );

    SET @i += 1;
END;


--TẠO 1000 LƯỢT ĐẶT PHÒNG
SET NOCOUNT ON;

DECLARE @i INT = 1;
DECLARE @MaxKH INT = (SELECT MAX(MaKhachHang) FROM KhachHang);
DECLARE @MaxPhong INT = (SELECT MAX(MaPhong) FROM Phong);
DECLARE @MinPhong INT = (SELECT MIN(MaPhong) FROM Phong);

WHILE @i <= 1000
BEGIN
    DECLARE @MaKH INT = (ABS(CHECKSUM(NEWID())) % @MaxKH) + 1;
    DECLARE @MaPhong INT = (ABS(CHECKSUM(NEWID())) % (@MaxPhong - @MinPhong + 1)) + @MinPhong;

    DECLARE @NgayNhan DATE = DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE());
    DECLARE @NgayTra DATE = DATEADD(DAY, ABS(CHECKSUM(NEWID())) % 10 + 1, @NgayNhan);

    INSERT INTO DatPhong (MaKhachHang, MaPhong, NgayNhanPhong, NgayTraPhong, TongTien, TrangThai)
    VALUES (
        @MaKH,
        @MaPhong,
        @NgayNhan,
        @NgayTra,
        (ABS(CHECKSUM(NEWID())) % 2000000) + 200000, -- 200k - 2.2M
        CASE 
            WHEN ABS(CHECKSUM(NEWID())) % 3 = 0 THEN N'Đã thanh toán'
            WHEN ABS(CHECKSUM(NEWID())) % 3 = 1 THEN N'Chưa thanh toán'
            ELSE N'Đã hủy'
        END
    );

    SET @i += 1;
END;

----TẠO HÓA ĐƠN MẪU:
INSERT INTO HoaDon
(
    MaDatPhong,
    TongTien,
    TrangThaiThanhToan
)
SELECT
    MaDatPhong,
    TongTien,
    CASE
        WHEN TrangThai = N'Đã thanh toán'
        THEN N'Đã thanh toán'
        ELSE N'Chưa thanh toán'
    END
FROM DatPhong;

--BẢN GHI NHẬT KÝ
INSERT INTO NhatKyHeThong
(MaNguoiDung, HanhDong)
VALUES
(1,N'Đăng nhập hệ thống'),
(1,N'Tạo dự báo công suất phòng'),
(1,N'Xem Dashboard');



----------------------------
--BƯỚC 4: TẠO VIEW CHO DASHBOARD
--VIEW CÔNG SUẤT PHÒNG
CREATE VIEW vw_CongSuatPhong
AS
SELECT
    Ngay,
    TongPhong,
    PhongDaDat,
    TyLeCongSuat
FROM CongSuatPhong;

----VIEW KPI
CREATE OR ALTER VIEW vw_KPI
AS
SELECT
    AVG(TyLeCongSuat) AS CongSuatTrungBinh,
    MAX(TyLeCongSuat) AS CongSuatCaoNhat,
    MIN(TyLeCongSuat) AS CongSuatThapNhat,
    COUNT(*) AS SoNgayThongKe
FROM CongSuatPhong;
GO

--TẠO VIEW CHO PROPHET
CREATE VIEW vw_DuLieuProphet
AS
SELECT
    Ngay AS ds,
    TyLeCongSuat AS y
FROM CongSuatPhong;


--DASHBOARD THỐNG KÊ KHÁCH SẠN
CREATE VIEW vw_ThongKeKhachSan
AS
SELECT
(
    SELECT COUNT(*) FROM KhachHang
) TongKhachHang,

(
    SELECT COUNT(*) FROM DatPhong
) TongLuotDatPhong,

(
    SELECT COUNT(*) FROM HoaDon
) TongHoaDon;

--TẠO VIEW DOANH THU
CREATE VIEW vw_DoanhThu
AS
SELECT
    CAST(NgayLap AS DATE) AS Ngay,
    SUM(TongTien) AS DoanhThu
FROM HoaDon
GROUP BY CAST(NgayLap AS DATE);
GO

--VIEW CẢNH BÁO TỰ ĐỘNG 
CREATE VIEW vw_CanhBaoTuDong
AS
SELECT
    Ngay,
    TyLeCongSuat,
    CASE
        WHEN TyLeCongSuat >= 80 THEN N'Cao'
        WHEN TyLeCongSuat >= 60 THEN N'Trung bình'
        ELSE N'Thấp'
    END AS MucDo
FROM CongSuatPhong;

--TẠO VIEW HỖ TRỢ QUYẾT ĐỊNH
CREATE VIEW vw_HoTroQuyetDinh
AS
SELECT
    Ngay,

    CongSuatDuBao,

    CASE
        WHEN CongSuatDuBao >= 80
            THEN N'Tăng nhân sự'

        WHEN CongSuatDuBao <= 40
            THEN N'Triển khai khuyến mãi'

        ELSE N'Hoạt động bình thường'
    END AS DeXuat
FROM ChiTietDuBao;


--TẠO VIEW TỔNG HỢP DSS( ĐÁNH GIÁ MÔ HÌNH)
CREATE OR ALTER VIEW vw_TongHopDSS
AS
SELECT
    d.MaDuBao,
    d.NgayDuBao,
    d.CongSuatTrungBinh,
    d.MoHinhSuDung,
    d.DoTinCay,

    (
        SELECT TOP 1 RMSE
        FROM DanhGiaMoHinh
        WHERE TenMoHinh = d.MoHinhSuDung
        ORDER BY MaDanhGia DESC
    ) AS RMSE,

    (
        SELECT TOP 1 MAE
        FROM DanhGiaMoHinh
        WHERE TenMoHinh = d.MoHinhSuDung
        ORDER BY MaDanhGia DESC
    ) AS MAE,

    (
        SELECT TOP 1 MAPE
        FROM DanhGiaMoHinh
        WHERE TenMoHinh = d.MoHinhSuDung
        ORDER BY MaDanhGia DESC
    ) AS MAPE

FROM DuBao d;
GO


--TẠO VIEW KHUYẾN NGHỊ VÀ QUYẾT ĐỊNH(DSS HOÀN CHỈNH)
CREATE OR ALTER VIEW vw_HoTroRaQuyetDinh
AS
SELECT
    d.MaDuBao,
    d.NgayDuBao,

    (
        SELECT TOP 1 NoiDung
        FROM KhuyenNghi k
        WHERE k.MaDuBao = d.MaDuBao
        ORDER BY k.MaKhuyenNghi DESC
    ) AS KhuyenNghi,

    (
        SELECT TOP 1 NoiDung
        FROM QuyetDinh q
        WHERE q.MaDuBao = d.MaDuBao
        ORDER BY q.MaQuyetDinh DESC
    ) AS QuyetDinh

FROM DuBao d;
GO



-----------------------------------------------------------------------------------------
--BƯỚC 5: TẠO STORED PROCEDURE
-------------------------------------------------------------------------------------------
--LẤY DỮ LIỆU DASHBOARD
CREATE PROC sp_LayKPI
AS
BEGIN

SELECT
AVG(TyLeCongSuat) AS TrungBinh,
MAX(TyLeCongSuat) AS CaoNhat,
MIN(TyLeCongSuat) AS ThapNhat

FROM CongSuatPhong;

END

---LẤY DỮ LIỆU HUẤN LUYỆN AI
CREATE PROC sp_DuLieuDuBao
AS
BEGIN

SELECT
Ngay,
TyLeCongSuat

FROM CongSuatPhong

ORDER BY Ngay;

END

---TẠO STORED PROCEDURE CHO PROPHET
CREATE OR ALTER PROC sp_LayDuLieuProphet
AS
BEGIN

    SELECT
        Ngay AS ds,
        TyLeCongSuat AS y
    FROM CongSuatPhong
    ORDER BY Ngay;

END;
GO

--LẤY DANH SÁCH CẢNH BÁO MỚI NHẤT CHO DASHBOARD DSS
CREATE OR ALTER PROC sp_LayCanhBao
AS
BEGIN

    SELECT
        MaCanhBao,
        NgayCanhBao,
        MucDo,
        NoiDung
    FROM CanhBao
    ORDER BY NgayCanhBao DESC;

END
GO

--LẤY CÁC KHUYẾN NGHỊ DSS.
CREATE OR ALTER PROC sp_LayKhuyenNghi
AS
BEGIN

    SELECT
        MaKhuyenNghi,
        MaDuBao,
        NoiDung,
        NgayTao
    FROM KhuyenNghi
    ORDER BY NgayTao DESC;

END
GO

--LẤY CÁC QUYẾT ĐỊNH ĐÃ TẠO.
CREATE OR ALTER PROC sp_LayQuyetDinh
AS
BEGIN

    SELECT
        MaQuyetDinh,
        LoaiQuyetDinh,
        NoiDung,
        TrangThai,
        NgayTao
    FROM QuyetDinh
    ORDER BY NgayTao DESC;

END
GO



-------------------------------------------------
--THÊM CONSTRAINT
-------------------------------------------------
--CCCD không được trùng
ALTER TABLE KhachHang
ADD CONSTRAINT UQ_KhachHang_CCCD
UNIQUE(CCCD);

--Giá phòng phải lớn hơn 0
ALTER TABLE LoaiPhong
ADD CONSTRAINT CK_GiaPhong
CHECK (GiaCoBan > 0);

--Ngày trả phải lớn hơn ngày nhận
ALTER TABLE DatPhong
ADD CONSTRAINT CK_DatPhong_Ngay
CHECK (NgayTraPhong > NgayNhanPhong);

--Công suất phòng từ 0 đến 100
ALTER TABLE CongSuatPhong
ADD CONSTRAINT CK_CongSuat
CHECK (TyLeCongSuat BETWEEN 0 AND 100);
----------------------------------------------------------
---BỔ SUNG BẢNG-------
---------------------------------------------------------
ALTER TABLE Phong
ADD Tang INT NULL;

ALTER TABLE Phong
ADD SucChua INT NULL;

ALTER TABLE Phong
ADD GhiChu NVARCHAR(200) NULL;

ALTER TABLE Phong
ADD CONSTRAINT UQ_Phong_SoPhong
UNIQUE(SoPhong);

ALTER TABLE DuBao
ADD DoTinCay FLOAT NULL;

ALTER TABLE QuyetDinh
ADD TrangThai NVARCHAR(50);

ALTER TABLE QuyetDinh
ADD CONSTRAINT DF_QuyetDinh_TrangThai
DEFAULT N'Đã duyệt'
FOR TrangThai;
----------------------------------------------------------------
--CẬP NHẬT DỮ LIỆU
------------------------------------------------------------------
UPDATE Phong
SET Tang = 1,
    SucChua = 2
WHERE SoPhong LIKE 'P1%';

UPDATE Phong
SET Tang = 2,
    SucChua = 3
WHERE SoPhong LIKE 'P2%';

UPDATE Phong
SET Tang = 3,
    SucChua = 4
WHERE SoPhong LIKE 'P3%';

--chia đều 255p vào 10 tầng
UPDATE Phong
SET Tang =
    CASE
        WHEN MaPhong <= 250
            THEN ((MaPhong - 1) / 25) + 1
        ELSE 10
    END;

--cặp nhật tầng và sức chứa
UPDATE Phong
SET
    Tang =
        CASE
            WHEN MaLoaiPhong = 1 THEN 1
            WHEN MaLoaiPhong = 2 THEN 2
            WHEN MaLoaiPhong = 3 THEN 3
        END,

    SucChua =
        CASE
            WHEN MaLoaiPhong = 1 THEN 2
            WHEN MaLoaiPhong = 2 THEN 3
            WHEN MaLoaiPhong = 3 THEN 4
        END
WHERE Tang IS NULL
   OR SucChua IS NULL;


UPDATE Phong
SET Tang =
    CASE
        WHEN MaPhong BETWEEN 1 AND 25 THEN 1
        WHEN MaPhong BETWEEN 26 AND 50 THEN 2
        WHEN MaPhong BETWEEN 51 AND 75 THEN 3
        WHEN MaPhong BETWEEN 76 AND 100 THEN 4
        WHEN MaPhong BETWEEN 101 AND 125 THEN 5
        WHEN MaPhong BETWEEN 126 AND 150 THEN 6
        WHEN MaPhong BETWEEN 151 AND 175 THEN 7
        WHEN MaPhong BETWEEN 176 AND 200 THEN 8
        WHEN MaPhong BETWEEN 201 AND 225 THEN 9
        ELSE 10
    END;

-- Dữ liệu mẫu cho nhật ký dự báo
UPDATE NhatKyDuBao
SET
    MAE = 3.5,
    MAPE = 8.2
WHERE MAE IS NULL;

UPDATE QuyetDinh
SET TrangThai = N'Đã duyệt';

UPDATE QuyetDinh
SET TrangThai = N'Đã duyệt'
WHERE TrangThai IS NULL;

UPDATE CongSuatPhong
SET TongPhong = 255;

UPDATE CongSuatPhong
SET TyLeCongSuat =
    ROUND((PhongDaDat * 100.0) / TongPhong, 2);

 SELECT
    MIN(TyLeCongSuat) AS MinCS,
    AVG(TyLeCongSuat) AS AvgCS,
    MAX(TyLeCongSuat) AS MaxCS
FROM CongSuatPhong;

UPDATE Phong SET SoPhong = 'P103' WHERE MaPhong = 6;
UPDATE Phong SET SoPhong = 'P104' WHERE MaPhong = 7;
UPDATE Phong SET SoPhong = 'P203' WHERE MaPhong = 8;
UPDATE Phong SET SoPhong = 'P204' WHERE MaPhong = 9;
UPDATE Phong SET SoPhong = 'P302' WHERE MaPhong = 10;


UPDATE DuBao
SET DoTinCay = 84.15
WHERE MoHinhSuDung='ARIMA'
AND DoTinCay IS NULL;

UPDATE DuBao
SET DoTinCay = 82.28
WHERE MoHinhSuDung='Prophet'
AND DoTinCay IS NULL;
-------------------------------------------------
--TẠO TRIGGER
-----------------------------------------------------
CREATE OR ALTER TRIGGER trg_InsertDatPhong
ON DatPhong
AFTER INSERT
AS
BEGIN

    INSERT INTO NhatKyHeThong
    (
        MaNguoiDung,
        HanhDong
    )
    SELECT
        1,
        N'Tạo đặt phòng mới - Mã đặt phòng: '
        + CAST(MaDatPhong AS NVARCHAR(20))
    FROM inserted;

END
GO
-------------------------------------------------------------------------------------------
--TẠO INDEX
--INDEX CHO DATPHONG
CREATE INDEX IX_DatPhong_MaKhachHang
ON DatPhong(MaKhachHang);

CREATE INDEX IX_DatPhong_MaPhong
ON DatPhong(MaPhong);

CREATE INDEX IX_DatPhong_NgayNhan
ON DatPhong(NgayNhanPhong);

--INDEX CHO CÔNG SUẤT PHÒNG
CREATE INDEX IX_CongSuatPhong_Ngay
ON CongSuatPhong(Ngay);

--INDEX CHO CÁC BẢNG DSS
CREATE INDEX IX_ChiTietDuBao_MaDuBao
ON ChiTietDuBao(MaDuBao);

CREATE INDEX IX_KhuyenNghi_MaDuBao
ON KhuyenNghi(MaDuBao);

CREATE INDEX IX_QuyetDinh_MaDuBao
ON QuyetDinh(MaDuBao);

SELECT *
FROM NguoiDung