--USE MASTER
--GO
IF DB_ID('QLTPCO') IS NOT NULL
	DROP DATABASE QLTPCO
GO
CREATE DATABASE QLTPCO
GO
USE QLTPCO
GO

--CREATE TABLE
CREATE TABLE NGUOIDUNG(
	TenDangNhap nvarchar(100) PRIMARY KEY,
	MatKhau nvarchar(1000) not null default N'123456',
	Loai nvarchar(20)
	)
CREATE TABLE CAOOC(
	MaCaoOc int identity,
	TenCaoOc NVARCHAR(100),
	DiaChiCaoOc NVARCHAR(100),
	TongDTSuDung FLOAT,
	MoTaDD NVARCHAR(100),
	PRIMARY KEY(MaCaoOc)
	)
CREATE TABLE PHONG(
	MaPhong int identity,
	DTSuDung FLOAT,
	GiaCoBan FLOAT,
	Tang INT,
	SoChoLamViec INT,
	MaCaoOc int,
	TinhTrang NVARCHAR(20),
	PRIMARY KEY(MaPhong)
	)
CREATE TABLE KHACHHANG(
	MaKH int identity,
	TenKH NVARCHAR(100),
	SDTKH nvarchar(10),
	NgaySinhKH DATETIME,
	GioiTinhKH NVARCHAR(6)
	PRIMARY KEY(MaKH)
	)
CREATE TABLE HOPDONGTP(
	MaHDTP int identity,
	NgayHieuLucHD DATETIME,
	NgayTTDauTien DATETIME,
	MaKH int,
	--MaPB int,
	--MaBP int
	PRIMARY KEY(MaHDTP)
	)
CREATE TABLE HOPDONGGH(
	MaHDGH int identity,
	NgayKyGiaHan DATETIME,
	MaKH int,
	--MaPB int,
	--MaBP int,
	PRIMARY KEY(MaHDGH)
	)
CREATE TABLE CT_HOPDONGTP(
	MaCTHDTP int identity,
	ThoiGianTP INT,
	GiaTP FLOAT,
	MaPhong int,
	MaHDTP int,
	NgayHetHanTP DATETIME
	PRIMARY KEY (MaCTHDTP)
	)
CREATE TABLE CT_HOPDONGGH(
	MaCTHDGH int identity,
	ThoiGianGH INT,
	GiaGH FLOAT,
	MaPhong int,
	MaHDGH int
	PRIMARY KEY (MaCTHDGH)
	)
--CREATE TABLE BOPHAN(
--	MaBP int identity,
--	TenBP NVARCHAR(100),
--	PRIMARY KEY (MaBP)
--	)
--CREATE TABLE PHONGBAN(
--	MaPB int,
--	TenPB NVARCHAR(100),
--	PRIMARY KEY(MaPB)
--	)
CREATE TABLE HOADON(
	MaHoaDon int identity,
	NgayTT DATETIME,
	LyDoTT NVARCHAR(100),
	TongTienThanhToan FLOAT,
	--TienDaDong FLOAT,
	--TienConThieu FLOAT,
	MaKH int
	PRIMARY KEY (MaHoaDon)
	)
CREATE TABLE CT_HOADON(
	MaCTHoaDon int identity,
	MaHoaDon int,
	MaHDTP int,
	MaHDGH int
	PRIMARY KEY (MaCTHoaDon)
	)
--CREATE TABLE THANHTOAN(
--	MaPB int,
--	MaKH int
--	PRIMARY KEY (MaPB,MaKH)
	--)
--CREATE TABLE THAMKHAO(
--	MaKH int,
--	MaBP int,
--	MaPHONG int,
--	PRIMARY KEY(MaKH,MaBP,MaPHONG)
--	)

--ALTER TABLE
ALTER TABLE PHONG
ADD
	CONSTRAINT FK_PHONG_CAOOC
	FOREIGN KEY(MaCaoOc)
	REFERENCES CAOOC
ALTER TABLE HOPDONGTP
ADD
	CONSTRAINT FK_HOPDONGTP_KHACHHANG
	FOREIGN KEY(MaKH)
	REFERENCES KHACHHANG
	--CONSTRAINT FK_HOPDONGTP_BOPHAN
	--FOREIGN KEY(MaBP)
	--REFERENCES BOPHAN,
	--CONSTRAINT FK_HOPDONGTP_PHONGBAN
	--FOREIGN KEY(MaPB)
	--REFERENCES PHONGBAN
ALTER TABLE HOPDONGGH
ADD
	CONSTRAINT FK_HOPDONGGH_KHACHHANG
	FOREIGN KEY(MaKH)
	REFERENCES KHACHHANG
	--CONSTRAINT FK_HOPDONGGH_BOPHAN
	--FOREIGN KEY(MaBP)
	--REFERENCES BOPHAN,
	--CONSTRAINT FK_HOPDONGGH_PHONGBAN
	--FOREIGN KEY(MaPB)
	--REFERENCES PHONGBAN
ALTER TABLE CT_HOPDONGTP
ADD
	CONSTRAINT FK_CT_HOPDONGTP_HOPDONGTP
	FOREIGN KEY(MaHDTP)
	REFERENCES HOPDONGTP,
	CONSTRAINT FK_CT_HOPDONGTP_PHONG
	FOREIGN KEY(MaPHONG)
	REFERENCES PHONG
ALTER TABLE CT_HOPDONGGH
ADD
	CONSTRAINT FK_CT_HOPDONGGH_HOPDONGGH
	FOREIGN KEY(MaHDGH)
	REFERENCES HOPDONGGH,
	CONSTRAINT FK_CT_HOPDONGGH_PHONG
	FOREIGN KEY(MaPHONG)
	REFERENCES PHONG
ALTER TABLE HOADON
ADD
	CONSTRAINT FK_HOADON_KHACHHANG
	FOREIGN KEY(MaKH)
	REFERENCES KHACHHANG
ALTER TABLE CT_HOADON
ADD
	CONSTRAINT FK_CT_HOADON_HOADON
	FOREIGN KEY (MaHoaDon)
	REFERENCES HOADON,
	CONSTRAINT FK_CT_HOADON_HOPDONGTP
	FOREIGN KEY (MaHDTP)
	REFERENCES HOPDONGTP,
	CONSTRAINT FK_CT_HOADON_HOPDONGGH
	FOREIGN KEY (MaHDGH)
	REFERENCES HOPDONGGH
--ALTER TABLE THANHTOAN
--ADD
--	CONSTRAINT FK_THANHTOAN_PHONGBAN
--	FOREIGN KEY(MaPB)
--	REFERENCES PHONGBAN,
--	CONSTRAINT FK_THANHTOAN_KHACHHANG
--	FOREIGN KEY(MaKH)
--	REFERENCES KHACHHANG
--ALTER TABLE THAMKHAO
--ADD
--	CONSTRAINT FK_THAMKHAO_KHACHHANG
--	FOREIGN KEY(MaKH)
--	REFERENCES KHACHHANG,
--	CONSTRAINT FK_THAMKHAO_BOPHAN
--	FOREIGN KEY(MaBP)
--	REFERENCES BOPHAN,
--	CONSTRAINT FK_THAMKHAO_PHONG
--	FOREIGN KEY(MaPHONG)
--	REFERENCES PHONG

--INSERT
INSERT INTO NGUOIDUNG
VALUES(N'admin',N'admin',N'Admin'),
(N'user',N'user',N'Receptionist')
go

SET IDENTITY_INSERT CAOOC ON
GO
INSERT INTO CAOOC (MaCaoOc, TenCaoOc, DiaChiCaoOc, TongDTSuDung, MoTaDD)
VALUES
(1, N'Vincom', N'772 Điện Biên Phủ, Phường 1, Bình Thạnh, TP. Hồ Chí Minh', 141000, N'Gồm 81 tầng'),
(2, N'Bitexco', N'Số 02 Hải Triều, Bến Nghé, Quận 1, TP. Hồ Chí Minh', 61000, N'Là công trình cao thứ 5 Việt Nam')
GO
SET IDENTITY_INSERT CAOOC OFF
GO

SET IDENTITY_INSERT PHONG ON
GO
INSERT INTO PHONG (MaPhong, DTSuDunG, GiaCoBan, Tang, SoChoLamVieC, MaCaoOc, TinhTrang)
VALUES 
(1, 50, 5000000, 1, 12, 1, N'Trống'),
(2, 70, 5050000, 1, 14, 1, N'Trống'),
(3, 40, 4050000, 1, 10, 2, N'Trống'),--Đã có hợp đồng
(4, 50, 5000000, 1, 12, 1, N'Trống'),
(5, 70, 5050000, 1, 14, 1, N'Trống'),
(6, 50, 5000000, 1, 12, 1, N'Trống'),
(7, 70, 5050000, 1, 14, 1, N'Trống'),--Đã có hợp đồng
(8, 40, 4050000, 1, 10, 2, N'Trống'),
(9, 50, 5000000, 1, 12, 1, N'Trống'),
(10, 70, 5050000, 1, 14, 1, N'Trống'),
(11, 50, 5000000, 1, 12, 1, N'Trống'),
(12, 70, 5050000, 1, 14, 1, N'Trống'),
(13, 40, 4050000, 1, 10, 2, N'Trống'),
(14, 50, 5000000, 1, 12, 1, N'Trống'),
(15, 70, 5050000, 1, 14, 1, N'Trống'),
(16, 50, 5000000, 1, 12, 1, N'Trống'),
(17, 70, 5050000, 1, 14, 1, N'Trống'),
(18, 40, 4050000, 1, 10, 2, N'Trống'),
(19, 50, 5000000, 1, 12, 1, N'Trống'),
(20, 70, 5050000, 1, 14, 1, N'Trống'),
(21, 50, 5000000, 1, 12, 1, N'Trống'),
(22, 70, 5050000, 1, 14, 1, N'Trống'),
(23, 40, 4050000, 1, 10, 2, N'Trống'),
(24, 50, 5000000, 1, 12, 1, N'Trống'),
(25, 70, 5050000, 1, 14, 1, N'Trống'),
(26, 40, 4050000, 2, 10, 2, N'Trống'),
(27, 50, 5000000, 2, 12, 1, N'Trống'),
(28, 70, 5050000, 2, 14, 1, N'Trống'),
(29, 40, 4050000, 2, 10, 1, N'Trống'),
(30, 50, 5000000, 2, 12, 1, N'Trống'),
(31, 70, 5050000, 3, 14, 1, N'Trống'),
(32, 40, 4050000, 3, 10, 2, N'Trống'),
(33, 50, 5000000, 3, 12, 1, N'Trống'),
(34, 70, 5050000, 3, 14, 1, N'Trống'),
(35, 40, 4050000, 3, 10, 2, N'Trống'),
(36, 50, 5000000, 3, 12, 1, N'Trống'),
(37, 70, 5050000, 4, 14, 1, N'Trống'),
(38, 40, 4050000, 4, 10, 2, N'Trống'),
(39, 50, 5000000, 4, 12, 1, N'Trống'),
(40, 70, 5050000, 4, 14, 1, N'Trống'),
(41, 40, 4050000, 4, 10, 2, N'Trống'),
(42, 50, 5000000, 5, 12, 1, N'Trống'),
(43, 70, 5050000, 5, 14, 2, N'Trống'),
(44, 40, 4050000, 5, 10, 2, N'Trống'),
(45, 50, 5000000, 5, 12, 1, N'Trống'),
(46, 70, 5050000, 5, 14, 1, N'Trống'),
(47, 40, 4050000, 5, 10, 2, N'Trống')
GO
SET IDENTITY_INSERT PHONG OFF
GO
--Store Procedure
CREATE PROC USP_LOGIN -- HẠN CHẾ LỖI SQL Injection
@username nvarchar(100),@passwork nvarchar(100)
as
begin
	SELECT * FROM DBO.NGUOIDUNG WHERE tendangnhap=@username AND matkhau=@passwork
end
go
CREATE PROC USP_LAYDANHSACHPHONG 
AS
BEGIN
	SELECT * FROM PHONG
END
go
CREATE PROC USP_SUAMATKHAU
@username nvarchar(100),@passwork nvarchar(100),@newpasswork nvarchar(100)
as
begin
	declare @IsRigthPass int=0
	select @IsRigthPass = count(*) from dbo.NGUOIDUNG where tendangnhap=@username and matkhau=@passwork
	if(@IsRigthPass =1)
	begin
		if(@newpasswork <> NULL or @newpasswork <> '')
		begin
			UPDATE dbo.NGUOIDUNG set matkhau=@newpasswork where TenDangNhap = @username
		end
	end
end
go
--Function
CREATE FUNCTION [dbo].[GetUnsignString](@strInput NVARCHAR(4000))  --Chuyển ký tự có dấu về không dấu
RETURNS NVARCHAR(4000)
AS
BEGIN     
    IF @strInput IS NULL RETURN @strInput
    IF @strInput = '' RETURN @strInput
    DECLARE @RT NVARCHAR(4000)
    DECLARE @SIGN_CHARS NCHAR(136)
    DECLARE @UNSIGN_CHARS NCHAR (136)

    SET @SIGN_CHARS       = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'+NCHAR(272)+ NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'

    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
    SET @COUNTER = 1
 
    WHILE (@COUNTER <=LEN(@strInput))
    BEGIN   
      SET @COUNTER1 = 1
      --Tim trong chuoi mau
       WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1)
       BEGIN
     IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
     BEGIN           
          IF @COUNTER=1
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                   
          ELSE
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER)    
              BREAK         
               END
             SET @COUNTER1 = @COUNTER1 +1
       END
      --Tim tiep
       SET @COUNTER = @COUNTER +1
    END
    RETURN @strInput
END
GO
--Trigger 
create TRIGGER UTG_THEMCTHOPDONGTP --trigger sửa lại trạng thái của phòng
ON CT_HOPDONGTP FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @maphong int
	select @maphong =MaPhong from inserted
	update PHONG set TinhTrang =N'Có Người' where MaPhong=@maphong
END
go
create TRIGGER UTG_CAPNHATTINHTRANGPHONG --trigger sửa lại trạng thái của phòng khi hết hạn
ON CT_HOPDONGTP FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @maphong int
	select @maphong =MaPhong from inserted
	DECLARE @THOIGIAN DateTime = (SELECT NgayHetHanTP FROM inserted)
	update PHONG set TinhTrang =N'Trống' where MaPhong=@maphong and @THOIGIAN < getdate()
END
go
create TRIGGER UTG_THEMCTHOPDONGGH --trigger cập nhật thời gian thuê phòng nếu khách hàng gia hạn
ON CT_HOPDONGGH FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @MAPHONG INT
	SELECT @MAPHONG= MaPhong from inserted i
	DECLARE @THOIGIAN INT = (SELECT THOIGIANGH FROM inserted)
	update CT_HOPDONGTP set NgayHetHanTP=(SELECT DATEADD(MONTH,@THOIGIAN,NgayHetHanTP)) where @MAPHONG= MaPhong
END
GO
SELECT * FROM CAOOC
SELECT * FROM KHACHHANG
SELECT * FROM PHONG
select * from HOADON
select * from CT_HOADON
select * from HOPDONGGH
select * from CT_HOPDONGGH
select * from HOPDONGTP
select * from CT_HOPDONGTP
select * from NGUOIDUNG
select * from CT_HOPDONGTP cthdtp join HOPDONGTP hdtp on cthdtp.MaHDTP=hdtp.MaHDTP join KHACHHANG kh on hdtp.MaKH = kh.MaKH where kh.MaKH=1 
select max(maHDTP) from HOPDONGTP
select * from phong p join CT_HOPDONGTP ct on p.MaPhong=ct.MaPhong  where TinhTrang = N'Có Người' and DATEADD(month,-1,ct.NgayHetHanTP) <= Getdate()
