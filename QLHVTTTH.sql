CREATE DATABASE QLHVTTTH

USE QLHVTTTH;
GO

-- Tạo bảng "HocVien" để lưu trữ thông tin học viên
CREATE TABLE HocVien (
    IDHocVien NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50),
    NgaySinh DATE,
	GioiTinh NVARCHAR (5),
    Email NVARCHAR(100),
    DienThoai NVARCHAR(20),
	IDKhoaHoc INT,
	TaiKhoan NVARCHAR (20),
	CONSTRAINT FK_HocVien_KhoaHoc FOREIGN KEY (IDKhoaHoc) REFERENCES KhoaHoc(IDKhoaHoc),
	CONSTRAINT FK_HocVien_NguoiDung FOREIGN KEY (TaiKhoan) REFERENCES NguoiDung(TaiKhoan)
	
);


CREATE TABLE GiangVien (
    IDGiangVien INT PRIMARY KEY,
    TenGiangVien NVARCHAR(50),
	TaiKhoan NVARCHAR (20),
	CONSTRAINT FK_GiangVien_NguoiDung FOREIGN KEY (TaiKhoan) REFERENCES NguoiDung(TaiKhoan)
);

CREATE TABLE KhoaHoc (
    IDKhoaHoc INT PRIMARY KEY,
    TenKhoaHoc NVARCHAR(100),
    Description NVARCHAR(MAX),
    IDGiangVien INT,
   -- FOREIGN KEY (IDGiangVien) REFERENCES GiangVien(IDGiangVien)
 CONSTRAINT FK_KhoaHoc_GiangVien FOREIGN KEY (IDGiangVien) REFERENCES GiangVien(IDGiangVien)
)


CREATE TABLE DangKiKhoaHoc (
    IDDangKy INT PRIMARY KEY,
    IDHocVien NVARCHAR(10),
    IDKhoaHoc INT,
    NgayDangKy DATE,
    CONSTRAINT FK_DangKiKhoaHoc_HocVien FOREIGN KEY (IDHocVien) REFERENCES HocVien(IDHocVien),
    CONSTRAINT FK_DangKiKhoaHoc_KhoaHoc FOREIGN KEY (IDKhoaHoc) REFERENCES KhoaHoc(IDKhoaHoc)
);

DROP TABLE LichHoc
CREATE TABLE LichHoc (
    IDLichHoc INT PRIMARY KEY,
    IDKhoaHoc INT,
	 IDHocVien NVARCHAR(10),
    DayOfWeek INT, -- Ví dụ: 1 (Thứ Hai), 2 (Thứ Ba), ...
    ThoiGianBD TIME,
    ThoiGianKT TIME,
    CONSTRAINT FK_LichHoc_KhoaHoc FOREIGN KEY (IDKhoaHoc) REFERENCES KhoaHoc(IDKhoaHoc),
	CONSTRAINT FK_LichHoc_HocVien FOREIGN KEY (IDHocVien) REFERENCES HocVien(IDHocVien)
);


CREATE TABLE Diem (
    IDHocVien NVARCHAR(10),
    IDKhoaHoc INT,
    NgayThi DATE,
    DiemThi DECIMAL(5, 2),
    CONSTRAINT FK_Diem_HocVien FOREIGN KEY (IDHocVien) REFERENCES HocVien(IDHocVien),
    CONSTRAINT FK_Diem_KhoaHoc FOREIGN KEY (IDKhoaHoc) REFERENCES KhoaHoc(IDKhoaHoc)
);
DROP TABLE NguoiDung
CREATE TABLE NguoiDung
(
	 --UserID INT IDENTITY(1,1) PRIMARY KEY,
	 TaiKhoan NVARCHAR (20)NOT NULL PRIMARY KEY, 
	 MatKhau NVARCHAR (50),
	 TruyCap NCHAR (10) DEFAULT 'User'  
)
ALTER TABLE NguoiDung
ADD Email NVARCHAR (255);
SET DATEFORMAT DMY

-- Thêm dữ liệu mẫu vào bảng "Students"
INSERT INTO HocVien (IDHocVien, HoTen, NgaySinh, GioiTinh, Email, DienThoai, IDKhoaHoc, TaiKhoan)
VALUES
    (N'HV1', N'Nguyễn Văn A', '15/05/2000', N'Nam', N'nguyenvana@gmail.com', N'0123456789', 1, 'user1'),
    (N'HV2', N'Trần Thị B', '26/08/1999', N'Nữ', N'tranthib@gmail.com', N'0987654321',2,'user2'),
    (N'HV3', N'Lê Minh C', '10/03/2001', N'Nam', N'leminhc@gmail.com', N'0369874123',1,'user3'),
    (N'HV4', N'Phạm Anh D', '20/08/2000', N'Nam', N'phamanhd@gmail.com', N'0932145678',3,'user4'),
    (N'HV5', N'Huỳnh Thị E', '17/09/2001', N'Nữ', N'huynhthie@gmail.com', N'0456123789', 5,'user5'),
    (N'HV6', N'Ngô Quang F', '29/09/2003', N'Nam', N'ngoquangf@gmail.com', N'0765432901',5,'user6');

-- Thêm dữ liệu vào bảng GiangVien
INSERT INTO GiangVien (IDGiangVien, TenGiangVien, TaiKhoan)
VALUES
    (1, N'Phan Đình Phùng', 'admin1'),
    (2, N'Lê Lợi','admin2'),
    (3, N'Trần Hưng Đạo','admin3'),
    (4, N'Quang Trung','admin4')

-- Thêm dữ liệu vào bảng KhoaHoc
INSERT INTO KhoaHoc (IDKhoaHoc, TenKhoaHoc, Description, IDGiangVien)
VALUES
    (1, N'Lập trình C++', N'Khoá học về lập trình C++ căn bản.', 1),
    (2, N'Marketing Digital', N'Khoá học về kỹ thuật tiếp thị trực tuyến.', 2),
    (3, N'Tin học cơ sở', N'Khoá học về tin học căn bản.', 4),
    (4, N'Lập trình Python', N'Khoá học về lập trình Python căn bản.', 4),
    (5, N'Lập trình WEB', N'Khoá học về lập trình WEB.', 3);

-- Thêm dữ liệu vào bảng DangKiKhoaHoc
INSERT INTO DangKiKhoaHoc (IDDangKy, IDHocVien, IDKhoaHoc, NgayDangKy)
VALUES
    (1, N'HV1', 1, '2023-01-15'),
    (2, N'HV2', 1, '2023-02-20'),
    (3, N'HV3', 2, '2023-03-10'),
    (4, N'HV4', 2, '2023-04-05'),
    (5, N'HV5', 3, '2023-05-12'),
    (6, N'HV6', 3, '2023-06-25')

-- Thêm dữ liệu vào bảng LichHoc
INSERT INTO LichHoc (IDLichHoc, IDKhoaHoc, DayOfWeek, ThoiGianBD, ThoiGianKT)
VALUES
    (1, 1,N'HV1', 2, '08:00:00', '10:00:00'),
    (2, 1,N'HV5', 4, '10:30:00', '12:30:00'),
    (3, 2,N'HV2', 1, '09:00:00', '11:00:00'),
    (4, 2,N'HV1', 3, '11:30:00', '13:30:00'),
    (5, 3,N'HV3', 2, '13:00:00', '15:00:00'),
    (6, 3,N'HV4', 4, '15:30:00', '17:30:00'),
    (7, 4,N'HV2', 1, '14:00:00', '16:00:00'),
    (8, 4,N'HV3', 3, '16:30:00', '18:30:00');

-- Thêm dữ liệu vào bảng Diem
INSERT INTO Diem (IDHocVien, IDKhoaHoc, NgayThi, DiemThi)
VALUES
    (N'HV1', 1, '2023-07-01', 8.5),
    (N'HV2', 1, '2023-07-01', 7.5),
    (N'HV3', 2, '2023-07-15', 9.0),
    (N'HV4', 2, '2023-07-15', 8.0),
    (N'HV5', 3, '2023-08-01', 8.7),
    (N'HV6', 3, '2023-08-01', 7.8)

INSERT INTO NguoiDung ( TaiKhoan, MatKhau, TruyCap)
VALUES
    ('admin1', 'admin', 'Admin'),
	('admin2', 'admin', 'Admin'),
	('admin3', 'admin', 'Admin'),
	('admin4', 'admin', 'Admin'),
    ('user1', '123', 'User'),
    ('user2', '123', 'User'),
	('user3', '123', 'User'),
	('user4', '123', 'User'),
	('user5', '123', 'User'),
	('user6', '123', 'User')


select * from HocVien

select * from NguoiDung where TruyCap = 'Admin'
SELECT HocVien.*, KhoaHoc.TenKhoaHoc  
                  FROM HocVien 
                  JOIN KhoaHoc ON HocVien.IdKhoaHoc = KhoaHoc.IdKhoaHoc;


SELECT HocVien.HoTen AS HoTen, HocVien.NgaySinh, HocVien.GioiTinh,  HocVien.Email, HocVien.DienThoai, KhoaHoc.TenKhoaHoc, LichHoc.DayOfWeek,  LichHoc.ThoiGianBD, LichHoc.ThoiGianKT FROM HocVien JOIN KhoaHoc ON HocVien.IDHocVien = KhoaHoc.IDHocVien  JOIN KhoaHoc ON LichHoc.IDKhoaHoc = KhoaHoc.IDKhoaHoc  WHERE HocVien.IDHocVien = IDHocVien;


SELECT HocVien.HoTen, HocVien.NgaySinh, HocVien.GioiTinh, HocVien.Email, HocVien.DienThoai, KhoaHoc.TenKhoaHoc,LichHoc.DayOfWeek,LichHoc.ThoiGianBD,LichHoc.ThoiGianKT FROM HocVien INNER JOIN KhoaHoc ON HocVien.IDKhoaHoc = KhoaHoc.IDKhoaHoc INNER JOIN LichHoc ON HocVien.IDKhoaHoc = LichHoc.IDKhoaHoc;