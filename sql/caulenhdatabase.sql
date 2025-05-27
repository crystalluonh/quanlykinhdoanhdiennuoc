CREATE DATABASE QuanLyKinhDoanhDichVuDienNuoc;
GO

USE QuanLyKinhDoanhDichVuDienNuoc;
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(200),
    Ward NVARCHAR(50), -- Thêm cột Ward
    Role NVARCHAR(20) CHECK (Role IN ('Admin', 'User')) NOT NULL
);
CREATE TABLE DichVuDien (
    MaDV VARCHAR(10) PRIMARY KEY,          -- Mã dịch vụ như DV01
    TenDichVu NVARCHAR(100) NOT NULL,      -- Tên dịch vụ
    DonVi NVARCHAR(20) NOT NULL DEFAULT 'kWh', -- Đơn vị đo (mặc định là kWh)
    NgayBatDau DATE NOT NULL,              -- Ngày bắt đầu áp dụng
    DonGia DECIMAL(10,2) NOT NULL,         -- Đơn giá
    TrangThai NVARCHAR(50) NOT NULL,       -- Trạng thái (VD: Còn áp dụng)
    MoTa NVARCHAR(255)                     -- Mô tả chi tiết
);
CREATE TABLE DichVuNuoc (
    MaDV VARCHAR(10) PRIMARY KEY,          -- Mã dịch vụ như DV01
    TenDichVu NVARCHAR(100) NOT NULL,      -- Tên dịch vụ
    DonVi NVARCHAR(20) NOT NULL DEFAULT 'm³', -- Đơn vị đo (mặc định là kWh)
    NgayBatDau DATE NOT NULL,              -- Ngày bắt đầu áp dụng
    DonGia DECIMAL(10,2) NOT NULL,         -- Đơn giá
    TrangThai NVARCHAR(50) NOT NULL,       -- Trạng thái (VD: Còn áp dụng)
    MoTa NVARCHAR(255)                     -- Mô tả chi tiết
);
CREATE TABLE HoaDonDien (
    MaHoaDon NVARCHAR(20) PRIMARY KEY,
    MaDV VARCHAR(10) NOT NULL,
    ThoiGian NVARCHAR(7) NOT NULL, -- định dạng MM/yyyy
    TenKhachHang NVARCHAR(100) NOT NULL,
    PhuongXa NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    ChiSoDien INT NOT NULL,
    TongTien DECIMAL(18, 2) NOT NULL,
    TrangThaiThanhToan BIT DEFAULT 0,    -- 0: chưa thanh toán, 1: đã thanh toán
    NgayThanhToan DATE NULL,
    UserID INT NULL,

    CONSTRAINT FK_HoaDonDien_DichVuDien FOREIGN KEY (MaDV) REFERENCES DichVuDien(MaDV),
    CONSTRAINT FK_HoaDonDien_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
CREATE TABLE HoaDonNuoc (
    MaHoaDon NVARCHAR(20) PRIMARY KEY,
    MaDV VARCHAR(10) NOT NULL,
    ThoiGian NVARCHAR(7) NOT NULL, -- định dạng MM/yyyy
    TenKhachHang NVARCHAR(100) NOT NULL,
    PhuongXa NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    ChiSoNuoc INT NOT NULL,
    TongTien DECIMAL(18, 2) NOT NULL,
    TrangThaiThanhToan BIT DEFAULT 0,    -- 0: chưa thanh toán, 1: đã thanh toán
    NgayThanhToan DATE NULL,
    UserID INT NULL,

    CONSTRAINT FK_HoaDonNuoc_DichVuNuoc FOREIGN KEY (MaDV) REFERENCES DichVuNuoc(MaDV),
    CONSTRAINT FK_HoaDonNuoc_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);