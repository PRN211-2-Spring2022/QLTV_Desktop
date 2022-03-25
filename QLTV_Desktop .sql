USE [master]
GO
/****** Object:  Database [QLTV_Desktop]    Script Date: 24/03/2022 11:59:33 pm ******/
CREATE DATABASE [QLTV_Desktop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLTV_Desktop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLTV_Desktop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLTV_Desktop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\QLTV_Desktop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLTV_Desktop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLTV_Desktop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLTV_Desktop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLTV_Desktop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLTV_Desktop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLTV_Desktop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLTV_Desktop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET RECOVERY FULL 
GO
ALTER DATABASE [QLTV_Desktop] SET  MULTI_USER 
GO
ALTER DATABASE [QLTV_Desktop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLTV_Desktop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLTV_Desktop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLTV_Desktop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLTV_Desktop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLTV_Desktop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLTV_Desktop', N'ON'
GO
ALTER DATABASE [QLTV_Desktop] SET QUERY_STORE = OFF
GO
USE [QLTV_Desktop]
GO
/****** Object:  UserDefinedFunction [dbo].[functiontoSearch]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create FUNCTION [dbo].[functiontoSearch] (@strInput NVARCHAR(4000) )
RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' 
RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136)
DECLARE @UNSIGN_CHARS NCHAR (136) 
SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput))
BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO
/****** Object:  UserDefinedFunction [dbo].[TinhTRangString]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[TinhTRangString](@tinhtrang int)
returns nvarchar(50)
as
begin
  if(@tinhtrang =1) return N'còn sách';
  else if(@tinhtrang =2) return N'đã mượn';
  else if(@tinhtrang =3) return N'đã mất';
  return N'bị hỏng'
end
GO
/****** Object:  UserDefinedFunction [dbo].[USP_PrintPhieuTrasach1]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[USP_PrintPhieuTrasach1](@idSach int)
returns int
as
begin
	IF(exists(select tb_phieuphat.* from tb_sach inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach= tb_sach.maquyensach
		inner join tb_ct_phieuphat on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach
		inner join tb_phieuphat on tb_phieuphat.maphieuphat= tb_ct_phieuphat.maphieuphat
		inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_phieuphat.mabbnhanlai
		where tb_sach.maquyensach =@idSach))
	begin
	  return 1
	end
	
		return 0	
	
end
GO
/****** Object:  Table [dbo].[tb_tacgia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_tacgia](
	[matacgia] [int] IDENTITY(200,2) NOT NULL,
	[tentacgia] [nvarchar](30) NOT NULL,
 CONSTRAINT [pk_tb_tacgia] PRIMARY KEY CLUSTERED 
(
	[matacgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ct_tacgia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ct_tacgia](
	[matacgia] [int] NOT NULL,
	[madausach] [int] NOT NULL,
	[vaitrotacgia] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[matacgia] ASC,
	[madausach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_sach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_sach](
	[maquyensach] [int] IDENTITY(400,2) NOT NULL,
	[madausach] [int] NOT NULL,
	[tinhtrangsach] [int] NOT NULL,
 CONSTRAINT [pk_tb_sach] PRIMARY KEY CLUSTERED 
(
	[maquyensach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_docgia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_docgia](
	[mathedocgia] [int] IDENTITY(500,2) NOT NULL,
	[hoten] [nvarchar](30) NOT NULL,
	[ngaysinh] [date] NOT NULL,
	[ngaylamthe] [date] NOT NULL,
	[diachi] [nvarchar](30) NOT NULL,
	[doituongdocgia] [nvarchar](30) NOT NULL,
 CONSTRAINT [pk_tb_docgia] PRIMARY KEY CLUSTERED 
(
	[mathedocgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_phieubangiaosach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_phieubangiaosach](
	[maphieubangiao] [int] IDENTITY(500,2) NOT NULL,
	[mathedocgia] [int] NOT NULL,
	[manhanvien] [int] NOT NULL,
	[ngaymuon] [date] NOT NULL,
	[ngaydukientra] [date] NOT NULL,
	[tinhtrangkhigiao] [nvarchar](30) NOT NULL,
 CONSTRAINT [pk_tb_phieubangiaosach] PRIMARY KEY CLUSTERED 
(
	[maphieubangiao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ct_phieubangiao]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ct_phieubangiao](
	[maquyensach] [int] NOT NULL,
	[maphieubangiao] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maquyensach] ASC,
	[maphieubangiao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dausach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dausach](
	[madausach] [int] IDENTITY(300,2) NOT NULL,
	[tendausach] [nvarchar](30) NOT NULL,
	[soluong] [int] NOT NULL,
	[sotrang] [int] NOT NULL,
	[tansuat] [int] NULL,
	[manhaxuatban] [int] NOT NULL,
 CONSTRAINT [pk_tb_dausach] PRIMARY KEY CLUSTERED 
(
	[madausach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[Report_muon]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Report_muon](@iddocgia int , @maqsach int)
returns table
return select tb_docgia.mathedocgia, tb_docgia.hoten, tb_docgia.ngaysinh, tb_docgia.doituongdocgia, tb_sach.maquyensach, tb_dausach.tendausach, tb_tacgia.tentacgia, tb_phieubangiaosach.ngaymuon, tb_phieubangiaosach.tinhtrangkhigiao, tb_phieubangiaosach.ngaydukientra 
from tb_docgia inner join tb_phieubangiaosach on tb_docgia.mathedocgia = tb_phieubangiaosach.mathedocgia 
inner join tb_ct_phieubangiao on tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao 
inner join tb_sach on tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
inner join tb_dausach on tb_sach.madausach = tb_dausach.madausach 
inner join tb_ct_tacgia on tb_dausach.madausach = tb_ct_tacgia.madausach 
inner join tb_tacgia on tb_ct_tacgia.matacgia = tb_tacgia.matacgia 
where tb_docgia.mathedocgia = @iddocgia and tb_sach.maquyensach =@maqsach
GO
/****** Object:  Table [dbo].[tb_bb_nhanlaisach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_bb_nhanlaisach](
	[mabbnhanlai] [int] IDENTITY(600,2) NOT NULL,
	[mathedocgia] [int] NOT NULL,
	[manhanvien] [int] NOT NULL,
	[ngaytra] [date] NOT NULL,
 CONSTRAINT [pk_bb_nhanlaisach] PRIMARY KEY CLUSTERED 
(
	[mabbnhanlai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ct_nhanlai]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ct_nhanlai](
	[mabbnhanlai] [int] NOT NULL,
	[maquyensach] [int] NOT NULL,
	[tinhtrangnhanlai] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mabbnhanlai] ASC,
	[maquyensach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[Report_tra]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Report_tra](@iddocgia int , @ngtra date)
returns table
return select tb_docgia.mathedocgia, tb_docgia.hoten, tb_docgia.ngaysinh, tb_docgia.doituongdocgia, tb_sach.maquyensach, tb_dausach.tendausach, tb_tacgia.tentacgia, tb_bb_nhanlaisach.ngaytra, tb_ct_nhanlai.tinhtrangnhanlai 
from tb_docgia inner join tb_bb_nhanlaisach on tb_docgia.mathedocgia = tb_bb_nhanlaisach.mathedocgia 
inner join tb_ct_nhanlai on tb_bb_nhanlaisach.mabbnhanlai = tb_ct_nhanlai.mabbnhanlai 
inner join tb_sach on tb_ct_nhanlai.maquyensach = tb_sach.maquyensach 
inner join tb_dausach on tb_sach.madausach = tb_dausach.madausach 
inner join tb_ct_tacgia on tb_dausach.madausach = tb_ct_tacgia.madausach 
inner join tb_tacgia on tb_ct_tacgia.matacgia = tb_tacgia.matacgia 
where tb_docgia.mathedocgia = @iddocgia and tb_bb_nhanlaisach.ngaytra = @ngtra
GO
/****** Object:  Table [dbo].[tb_NhanVien]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NhanVien](
	[manhanvien] [int] IDENTITY(100,2) NOT NULL,
	[tennhanvien] [nvarchar](30) NOT NULL,
 CONSTRAINT [pk_tb_NhanVien] PRIMARY KEY CLUSTERED 
(
	[manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_Acount]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Acount](
	[Gmail] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[manhanvien] [int] IDENTITY(100,2) NOT NULL,
	[quyen] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[FunC_InformationNV]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[FunC_InformationNV] ()

returns table
as
return select tb_NhanVien.*   from tb_Acount right join tb_NhanVien  on  tb_Acount.manhanVien = tb_NhanVien.manhanvien
GO
/****** Object:  UserDefinedFunction [dbo].[History_borrow]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create  function [dbo].[History_borrow]()
returns table
return select tb_docgia.mathedocgia, tb_docgia.hoten, tb_docgia.ngaysinh, tb_docgia.doituongdocgia, tb_sach.maquyensach, tb_dausach.tendausach, tb_tacgia.tentacgia, tb_phieubangiaosach.ngaymuon, tb_phieubangiaosach.tinhtrangkhigiao, tb_phieubangiaosach.ngaydukientra 
from tb_docgia inner join tb_phieubangiaosach on tb_docgia.mathedocgia = tb_phieubangiaosach.mathedocgia 
inner join tb_ct_phieubangiao on tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao 
inner join tb_sach on tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
inner join tb_dausach on tb_sach.madausach = tb_dausach.madausach 
inner join tb_ct_tacgia on tb_dausach.madausach = tb_ct_tacgia.madausach 
inner join tb_tacgia on tb_ct_tacgia.matacgia = tb_tacgia.matacgia 
GO
/****** Object:  UserDefinedFunction [dbo].[Search_PBG]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  function [dbo].[Search_PBG]()
returns table
return select tb_docgia.mathedocgia, tb_docgia.hoten, tb_docgia.ngaysinh, tb_docgia.doituongdocgia, tb_sach.maquyensach, tb_dausach.tendausach, tb_tacgia.tentacgia, tb_phieubangiaosach.ngaymuon, tb_phieubangiaosach.tinhtrangkhigiao, tb_phieubangiaosach.ngaydukientra 
from tb_docgia inner join tb_phieubangiaosach on tb_docgia.mathedocgia = tb_phieubangiaosach.mathedocgia 
inner join tb_ct_phieubangiao on tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao 
inner join tb_sach on tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
inner join tb_dausach on tb_sach.madausach = tb_dausach.madausach 
inner join tb_ct_tacgia on tb_dausach.madausach = tb_ct_tacgia.madausach 
inner join tb_tacgia on tb_ct_tacgia.matacgia = tb_tacgia.matacgia 
GO
/****** Object:  UserDefinedFunction [dbo].[USP_PrintPhieuBanGiao1]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[USP_PrintPhieuBanGiao1](@idSach int,@mathedocgia int,@manhanvien int,@ngaymuon date,@ngaydukientra date, @tinhtrangkhigiao nvarchar(30))
returns table
as
return
select tb_docgia.*,tb_NhanVien.tennhanvien,tb_sach.maquyensach,tb_dausach.madausach,tb_dausach.tendausach,tb_dausach.soluong,tb_dausach.sotrang,tb_dausach.tansuat,tb_tacgia.tentacgia,@ngaydukientra[ngaydukientra],@ngaymuon[ngaymuon],@tinhtrangkhigiao[tinhtrangkhigiao]
from tb_docgia,tb_NhanVien, tb_dausach inner join tb_sach on tb_dausach.madausach = tb_sach.madausach inner join tb_ct_tacgia on tb_ct_tacgia.madausach = tb_dausach.madausach inner join tb_tacgia on tb_ct_tacgia.matacgia= tb_tacgia.matacgia
where tb_sach.maquyensach = @idSach and tb_docgia.mathedocgia =@mathedocgia and tb_NhanVien.manhanvien=@manhanvien and tb_sach.tinhtrangsach=1
GO
/****** Object:  Table [dbo].[tb_phieuphat]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_phieuphat](
	[maphieuphat] [int] IDENTITY(700,2) NOT NULL,
	[mabbnhanlai] [int] NOT NULL,
	[tongtien] [int] NULL,
 CONSTRAINT [pk_tb_phieuphat] PRIMARY KEY CLUSTERED 
(
	[maphieuphat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ct_phieuphat]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_ct_phieuphat](
	[maphieuphat] [int] NOT NULL,
	[maquyensach] [int] NOT NULL,
	[songayquahan] [int] NOT NULL,
	[tinhtranghong] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maphieuphat] ASC,
	[maquyensach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[Function_PhieuTraBiPhat]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Function_PhieuTraBiPhat](@idSach int)
returns table
as
return select tb_dausach.*,tb_tacgia.tentacgia,tb_docgia.*,tb_ct_phieuphat.*,tb_phieuphat.tongtien,tb_bb_nhanlaisach.ngaytra,tb_ct_nhanlai.tinhtrangnhanlai from tb_sach
		inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach= tb_sach.maquyensach
		inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_ct_nhanlai.mabbnhanlai
		inner join tb_docgia on tb_docgia.mathedocgia = tb_bb_nhanlaisach.mathedocgia
		inner join tb_dausach on tb_dausach.madausach= tb_sach.madausach 
		inner join tb_ct_tacgia on tb_ct_tacgia.madausach = tb_dausach.madausach
		inner join tb_ct_phieuphat on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach
		inner join tb_phieuphat on tb_phieuphat.maphieuphat= tb_ct_phieuphat.maphieuphat
		inner join tb_tacgia on tb_tacgia.matacgia= tb_ct_tacgia.matacgia where tb_sach.maquyensach=@idSach
GO
/****** Object:  UserDefinedFunction [dbo].[Report_muon_nQuyen]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Report_muon_nQuyen](@iddocgia int , @ngmuon date)
returns table
return select tb_docgia.mathedocgia, tb_docgia.hoten, tb_docgia.ngaysinh, tb_docgia.doituongdocgia, tb_sach.maquyensach, tb_dausach.tendausach, tb_tacgia.tentacgia, tb_phieubangiaosach.ngaymuon, tb_phieubangiaosach.tinhtrangkhigiao, tb_phieubangiaosach.ngaydukientra 
from tb_docgia inner join tb_phieubangiaosach on tb_docgia.mathedocgia = tb_phieubangiaosach.mathedocgia 
inner join tb_ct_phieubangiao on tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao 
inner join tb_sach on tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
inner join tb_dausach on tb_sach.madausach = tb_dausach.madausach 
inner join tb_ct_tacgia on tb_dausach.madausach = tb_ct_tacgia.madausach 
inner join tb_tacgia on tb_ct_tacgia.matacgia = tb_tacgia.matacgia 
where tb_docgia.mathedocgia = @iddocgia and tb_phieubangiaosach.ngaymuon = @ngmuon
GO
/****** Object:  UserDefinedFunction [dbo].[Function_PhieuTraNoBiPhat]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Function_PhieuTraNoBiPhat](@idSach int)
returns table
as
return select tb_sach.maquyensach,tb_dausach.*,tb_tacgia.tentacgia,tb_docgia.*,tb_bb_nhanlaisach.ngaytra,tb_ct_nhanlai.tinhtrangnhanlai from tb_sach
		inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach= tb_sach.maquyensach
		inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_ct_nhanlai.mabbnhanlai
		inner join tb_docgia on tb_docgia.mathedocgia = tb_bb_nhanlaisach.mathedocgia
		inner join tb_dausach on tb_dausach.madausach= tb_sach.madausach 
		inner join tb_ct_tacgia on tb_ct_tacgia.madausach = tb_dausach.madausach
		inner join tb_tacgia on tb_tacgia.matacgia= tb_ct_tacgia.matacgia where tb_sach.maquyensach=@idSach
GO
/****** Object:  UserDefinedFunction [dbo].[Report_phat]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[Report_phat] (@iddocgia int , @ngtra date)
returns table
as
return select 
(select sum(tb_phieuphat.tongtien)[tienphat] from tb_docgia inner join tb_bb_nhanlaisach on tb_docgia.mathedocgia = tb_bb_nhanlaisach.mathedocgia 
inner join tb_phieuphat on tb_bb_nhanlaisach.mabbnhanlai = tb_phieuphat.mabbnhanlai 
inner join tb_ct_phieuphat on tb_phieuphat.maphieuphat = tb_ct_phieuphat.maphieuphat 
inner join tb_sach on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach 
inner join tb_dausach on tb_sach.madausach = tb_dausach.madausach 
inner join tb_ct_tacgia on tb_dausach.madausach = tb_ct_tacgia.madausach 
inner join tb_tacgia on tb_ct_tacgia.matacgia = tb_tacgia.matacgia where tb_docgia.mathedocgia = @iddocgia and tb_bb_nhanlaisach.ngaytra = @ngtra )[tienphat] ,
tb_docgia.mathedocgia, tb_bb_nhanlaisach.ngaytra , tb_docgia.hoten, tb_docgia.ngaysinh, tb_docgia.doituongdocgia, tb_sach.maquyensach,tb_dausach.tendausach, tb_tacgia.tentacgia, tb_phieuphat.tongtien, tb_ct_phieuphat.tinhtranghong, tb_ct_phieuphat.songayquahan 
from tb_docgia inner join tb_bb_nhanlaisach on tb_docgia.mathedocgia = tb_bb_nhanlaisach.mathedocgia 
inner join tb_phieuphat on tb_bb_nhanlaisach.mabbnhanlai = tb_phieuphat.mabbnhanlai 
inner join tb_ct_phieuphat on tb_phieuphat.maphieuphat = tb_ct_phieuphat.maphieuphat 
inner join tb_sach on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach 
inner join tb_dausach on tb_sach.madausach = tb_dausach.madausach 
inner join tb_ct_tacgia on tb_dausach.madausach = tb_ct_tacgia.madausach 
inner join tb_tacgia on tb_ct_tacgia.matacgia = tb_tacgia.matacgia 
where tb_docgia.mathedocgia = @iddocgia and tb_bb_nhanlaisach.ngaytra = @ngtra
GO
/****** Object:  UserDefinedFunction [dbo].[Function_Print1DGtuSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[Function_Print1DGtuSach](@idsach int)
returns table 
as
return select tb_docgia.* from tb_docgia inner join tb_phieubangiaosach on tb_phieubangiaosach.mathedocgia = tb_docgia.mathedocgia
inner join tb_ct_phieubangiao on tb_ct_phieubangiao.maphieubangiao = tb_phieubangiaosach.maphieubangiao inner join tb_sach on tb_sach.maquyensach = tb_ct_phieubangiao.maquyensach
where tb_sach.tinhtrangsach =2 AND tb_sach.maquyensach =@idsach
GO
/****** Object:  UserDefinedFunction [dbo].[funcTanSuatTuPBG]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[funcTanSuatTuPBG](@iddausach int)
returns table
as
return select tb_dausach.tendausach,tb_dausach.madausach, count(*)[solan] from tb_dausach inner join tb_sach on tb_sach.madausach = tb_dausach.madausach 
		inner join tb_ct_phieubangiao on tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach where tb_dausach.madausach = @iddausach
	group by tb_dausach.madausach,tb_dausach.tendausach 
GO
/****** Object:  UserDefinedFunction [dbo].[funcTanSuatTuPNL]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[funcTanSuatTuPNL](@iddausach int)
returns table
as
return select tb_dausach.tendausach,tb_dausach.madausach, count(*)[solan] from tb_dausach inner join tb_sach on tb_sach.madausach = tb_dausach.madausach 
				inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach = tb_sach.maquyensach where tb_dausach.madausach=@iddausach
				group by tb_dausach.madausach,tb_dausach.tendausach
GO
/****** Object:  UserDefinedFunction [dbo].[fun_loadAlLDSbyDocGia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[fun_loadAlLDSbyDocGia](@idmadocgia int)
RETURNS TABLE
AS
RETURN
select tb_sach.maquyensach,tb_dausach.tendausach,tb_dausach.sotrang from tb_dausach inner join tb_sach on tb_sach.madausach = tb_dausach.madausach inner join tb_ct_phieubangiao 
on tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach inner join tb_phieubangiaosach on tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao Where tb_phieubangiaosach.mathedocgia=@idmadocgia
GO
/****** Object:  UserDefinedFunction [dbo].[functhongkeTTQS]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[functhongkeTTQS]()
returns table
as
return select dbo.[TinhTRangString](tb_sach.tinhtrangsach)[tinhtrang],count(*)[thongke] from tb_sach group by tb_sach.tinhtrangsach

GO
/****** Object:  UserDefinedFunction [dbo].[function_listSachLOSS]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[function_listSachLOSS]()
returns table
as
return select tb_sach.maquyensach,tb_dausach.*,  tb_docgia.hoten , tb_sach.tinhtrangsach from tb_docgia inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mathedocgia = tb_docgia.mathedocgia inner join tb_phieuphat on tb_phieuphat.mabbnhanlai = tb_bb_nhanlaisach.mabbnhanlai inner join tb_ct_phieuphat on tb_ct_phieuphat.maphieuphat = tb_phieuphat.maphieuphat inner join tb_sach on tb_sach.maquyensach = tb_ct_phieuphat.maquyensach inner join tb_dausach on tb_dausach.madausach = tb_sach.madausach where tb_sach.tinhtrangsach = 3 
GO
/****** Object:  UserDefinedFunction [dbo].[Func_sach1muonDocGia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION  [dbo].[Func_sach1muonDocGia](@iddocgia int)
RETURNS TABLE  
AS
  RETURN (SELECT dbo.tb_sach.* FROM dbo.tb_sach INNER JOIN dbo.tb_ct_phieubangiao ON tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
	INNER JOIN dbo.tb_phieubangiaosach ON tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao
	WHERE dbo.tb_phieubangiaosach.mathedocgia= @iddocgia AND dbo.tb_sach.tinhtrangsach =2)
GO
/****** Object:  UserDefinedFunction [dbo].[FUN_LietKeTrangThai1DauSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[FUN_LietKeTrangThai1DauSach](@iddausach int)
returns table
as
 return select tb_dausach.tendausach, tb_sach.tinhtrangsach,count(*)[thongke] from tb_dausach 
inner join tb_sach on tb_sach.madausach= tb_dausach.madausach where tb_dausach.madausach=@iddausach
group by tb_dausach.tendausach, tb_sach.tinhtrangsach
GO
/****** Object:  UserDefinedFunction [dbo].[List1SACH]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[List1SACH]()
returns table
as
return select tb_dausach.madausach,tb_dausach.tendausach,tb_dausach.soluong,tb_dausach.sotrang,tb_tacgia.tentacgia from tb_dausach inner join tb_ct_tacgia on tb_ct_tacgia.madausach= tb_dausach.madausach inner join tb_tacgia 
on tb_tacgia.matacgia= tb_ct_tacgia.matacgia
GO
/****** Object:  UserDefinedFunction [dbo].[ListALLQS]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[ListALLQS](@iddausach int)
returns table
as 
return select tb_sach.maquyensach,tb_sach.tinhtrangsach from tb_sach where madausach=@iddausach 
GO
/****** Object:  UserDefinedFunction [dbo].[TaiKhoan]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[TaiKhoan](@gmail nvarchar(30) )
returns table
as
return select  tb_Acount.Gmail , tb_Acount.Password , tb_Acount.quyen, tb_NhanVien.* from tb_Acount inner join tb_NhanVien on tb_Acount.manhanvien = tb_NhanVien.manhanvien where  tb_Acount.Gmail = @gmail 
GO
/****** Object:  Table [dbo].[tb_NhaXuatBan]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_NhaXuatBan](
	[manhaxuatban] [int] IDENTITY(100,2) NOT NULL,
	[tennhaxuatban] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tb_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[manhaxuatban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_bb_nhanlaisach] ADD  DEFAULT (getdate()) FOR [ngaytra]
GO
ALTER TABLE [dbo].[tb_dausach] ADD  CONSTRAINT [DF__tb_dausac__soluo__52593CB8]  DEFAULT ('0') FOR [soluong]
GO
ALTER TABLE [dbo].[tb_dausach] ADD  CONSTRAINT [DF_tb_dausach_tansuat]  DEFAULT ((0)) FOR [tansuat]
GO
ALTER TABLE [dbo].[tb_docgia] ADD  DEFAULT (getdate()) FOR [ngaysinh]
GO
ALTER TABLE [dbo].[tb_docgia] ADD  DEFAULT (getdate()) FOR [ngaylamthe]
GO
ALTER TABLE [dbo].[tb_phieubangiaosach] ADD  DEFAULT (getdate()) FOR [ngaymuon]
GO
ALTER TABLE [dbo].[tb_phieubangiaosach] ADD  DEFAULT (getdate()) FOR [ngaydukientra]
GO
ALTER TABLE [dbo].[tb_phieuphat] ADD  DEFAULT ('0') FOR [tongtien]
GO
ALTER TABLE [dbo].[tb_Acount]  WITH CHECK ADD  CONSTRAINT [FK_tb_Acount_tb_NhanVien] FOREIGN KEY([manhanvien])
REFERENCES [dbo].[tb_NhanVien] ([manhanvien])
GO
ALTER TABLE [dbo].[tb_Acount] CHECK CONSTRAINT [FK_tb_Acount_tb_NhanVien]
GO
ALTER TABLE [dbo].[tb_bb_nhanlaisach]  WITH CHECK ADD  CONSTRAINT [fk_tb_docgia_tb_bb_nhanlaisach] FOREIGN KEY([mathedocgia])
REFERENCES [dbo].[tb_docgia] ([mathedocgia])
GO
ALTER TABLE [dbo].[tb_bb_nhanlaisach] CHECK CONSTRAINT [fk_tb_docgia_tb_bb_nhanlaisach]
GO
ALTER TABLE [dbo].[tb_bb_nhanlaisach]  WITH CHECK ADD  CONSTRAINT [fk_tb_nhanvien_tb_bb_nhanlaisach] FOREIGN KEY([manhanvien])
REFERENCES [dbo].[tb_NhanVien] ([manhanvien])
GO
ALTER TABLE [dbo].[tb_bb_nhanlaisach] CHECK CONSTRAINT [fk_tb_nhanvien_tb_bb_nhanlaisach]
GO
ALTER TABLE [dbo].[tb_ct_nhanlai]  WITH CHECK ADD  CONSTRAINT [fk_tb_bb_nhanlaisach_tb_ct_nhanlai] FOREIGN KEY([mabbnhanlai])
REFERENCES [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai])
GO
ALTER TABLE [dbo].[tb_ct_nhanlai] CHECK CONSTRAINT [fk_tb_bb_nhanlaisach_tb_ct_nhanlai]
GO
ALTER TABLE [dbo].[tb_ct_nhanlai]  WITH CHECK ADD  CONSTRAINT [fk_tb_sach_tb_ct_nhalai] FOREIGN KEY([maquyensach])
REFERENCES [dbo].[tb_sach] ([maquyensach])
GO
ALTER TABLE [dbo].[tb_ct_nhanlai] CHECK CONSTRAINT [fk_tb_sach_tb_ct_nhalai]
GO
ALTER TABLE [dbo].[tb_ct_phieubangiao]  WITH CHECK ADD  CONSTRAINT [fk_tb_phieubangiaosach_tb_ct_phieubangiao] FOREIGN KEY([maphieubangiao])
REFERENCES [dbo].[tb_phieubangiaosach] ([maphieubangiao])
GO
ALTER TABLE [dbo].[tb_ct_phieubangiao] CHECK CONSTRAINT [fk_tb_phieubangiaosach_tb_ct_phieubangiao]
GO
ALTER TABLE [dbo].[tb_ct_phieubangiao]  WITH CHECK ADD  CONSTRAINT [fk_tb_sach_tb_ct_phieubangiao] FOREIGN KEY([maquyensach])
REFERENCES [dbo].[tb_sach] ([maquyensach])
GO
ALTER TABLE [dbo].[tb_ct_phieubangiao] CHECK CONSTRAINT [fk_tb_sach_tb_ct_phieubangiao]
GO
ALTER TABLE [dbo].[tb_ct_phieuphat]  WITH CHECK ADD  CONSTRAINT [fk_tb_phieuphat_tb_ct_phieuphat] FOREIGN KEY([maphieuphat])
REFERENCES [dbo].[tb_phieuphat] ([maphieuphat])
GO
ALTER TABLE [dbo].[tb_ct_phieuphat] CHECK CONSTRAINT [fk_tb_phieuphat_tb_ct_phieuphat]
GO
ALTER TABLE [dbo].[tb_ct_phieuphat]  WITH CHECK ADD  CONSTRAINT [fk_tb_sach_tb_ct_phieuphat] FOREIGN KEY([maquyensach])
REFERENCES [dbo].[tb_sach] ([maquyensach])
GO
ALTER TABLE [dbo].[tb_ct_phieuphat] CHECK CONSTRAINT [fk_tb_sach_tb_ct_phieuphat]
GO
ALTER TABLE [dbo].[tb_ct_tacgia]  WITH CHECK ADD  CONSTRAINT [fk_tb_dausach_tb_ct_tacgia] FOREIGN KEY([madausach])
REFERENCES [dbo].[tb_dausach] ([madausach])
GO
ALTER TABLE [dbo].[tb_ct_tacgia] CHECK CONSTRAINT [fk_tb_dausach_tb_ct_tacgia]
GO
ALTER TABLE [dbo].[tb_ct_tacgia]  WITH CHECK ADD  CONSTRAINT [fk_tb_tacgia_tb_ct_tacgia] FOREIGN KEY([matacgia])
REFERENCES [dbo].[tb_tacgia] ([matacgia])
GO
ALTER TABLE [dbo].[tb_ct_tacgia] CHECK CONSTRAINT [fk_tb_tacgia_tb_ct_tacgia]
GO
ALTER TABLE [dbo].[tb_dausach]  WITH CHECK ADD  CONSTRAINT [FK_tb_dausach_tb_NhaXuatBan] FOREIGN KEY([manhaxuatban])
REFERENCES [dbo].[tb_NhaXuatBan] ([manhaxuatban])
GO
ALTER TABLE [dbo].[tb_dausach] CHECK CONSTRAINT [FK_tb_dausach_tb_NhaXuatBan]
GO
ALTER TABLE [dbo].[tb_phieubangiaosach]  WITH CHECK ADD  CONSTRAINT [fk_tb_ct_chomuon_tb_phieubangiaosach] FOREIGN KEY([manhanvien])
REFERENCES [dbo].[tb_NhanVien] ([manhanvien])
GO
ALTER TABLE [dbo].[tb_phieubangiaosach] CHECK CONSTRAINT [fk_tb_ct_chomuon_tb_phieubangiaosach]
GO
ALTER TABLE [dbo].[tb_phieubangiaosach]  WITH CHECK ADD  CONSTRAINT [fk_tb_ct_phieubangiao_tb_phieubangiaosach] FOREIGN KEY([mathedocgia])
REFERENCES [dbo].[tb_docgia] ([mathedocgia])
GO
ALTER TABLE [dbo].[tb_phieubangiaosach] CHECK CONSTRAINT [fk_tb_ct_phieubangiao_tb_phieubangiaosach]
GO
ALTER TABLE [dbo].[tb_phieuphat]  WITH CHECK ADD  CONSTRAINT [fk_tb_bb_nhanlaisach_tb_phieuphat] FOREIGN KEY([mabbnhanlai])
REFERENCES [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai])
GO
ALTER TABLE [dbo].[tb_phieuphat] CHECK CONSTRAINT [fk_tb_bb_nhanlaisach_tb_phieuphat]
GO
ALTER TABLE [dbo].[tb_sach]  WITH CHECK ADD  CONSTRAINT [fk_tb_dausach_tb_sach] FOREIGN KEY([madausach])
REFERENCES [dbo].[tb_dausach] ([madausach])
GO
ALTER TABLE [dbo].[tb_sach] CHECK CONSTRAINT [fk_tb_dausach_tb_sach]
GO
/****** Object:  StoredProcedure [dbo].[Delete_DocGia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Delete_DocGia] (@iddocgia int )
as 
begin
    declare @tinhtrangsach int
	set @tinhtrangsach = 0
	select @tinhtrangsach = tb_sach.tinhtrangsach from tb_sach inner join tb_ct_phieubangiao on tb_sach.maquyensach = tb_ct_phieubangiao.maquyensach
	                                                           inner join tb_phieubangiaosach on tb_ct_phieubangiao.maphieubangiao = tb_phieubangiaosach.maphieubangiao
															   inner join tb_docgia on tb_phieubangiaosach.mathedocgia = @iddocgia
	IF( @tinhtrangsach = 2 )
	begin 
	   print 'Sách đã được mượn'
	   end
	ELSE IF (@tinhtrangsach = 0)
	begin 
	   delete dbo.tb_phieubangiaosach from tb_phieubangiaosach where tb_phieubangiaosach.mathedocgia =@iddocgia
	   delete dbo.tb_ct_phieuphat from tb_ct_phieuphat inner join tb_phieuphat on tb_ct_phieuphat.maphieuphat= tb_phieuphat.maphieuphat inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai= tb_phieuphat.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia=@iddocgia
	   delete dbo.tb_phieuphat from tb_phieuphat inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai= tb_phieuphat.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia=@iddocgia
	   delete dbo.tb_ct_nhanlai from tb_ct_nhanlai inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_ct_nhanlai.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia =@iddocgia
	   delete dbo.tb_bb_nhanlaisach from tb_bb_nhanlaisach where tb_bb_nhanlaisach.mathedocgia=@iddocgia
	   delete dbo.tb_docgia from tb_docgia where tb_docgia.mathedocgia = @iddocgia

	end
end
GO
/****** Object:  StoredProcedure [dbo].[Delete_DocGia_]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Delete_DocGia_] (@iddocgia int )
as 
begin
    declare @tinhtrangsach int
	set @tinhtrangsach = 0
	select @tinhtrangsach = tb_sach.tinhtrangsach from tb_sach inner join tb_ct_phieubangiao on tb_sach.maquyensach = tb_ct_phieubangiao.maquyensach
	                                                           inner join tb_phieubangiaosach on tb_ct_phieubangiao.maphieubangiao = tb_phieubangiaosach.maphieubangiao
															   inner join tb_docgia on tb_phieubangiaosach.mathedocgia = @iddocgia
	IF( @tinhtrangsach = 2 )
	begin 
	   print 'Sách đã được mượn'
	   end
	ELSE IF (@tinhtrangsach = 0)
	begin 
	   delete dbo.tb_phieubangiaosach from tb_phieubangiaosach where tb_phieubangiaosach.mathedocgia =@iddocgia
	   delete dbo.tb_ct_phieuphat from tb_ct_phieuphat inner join tb_phieuphat on tb_ct_phieuphat.maphieuphat= tb_phieuphat.maphieuphat inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai= tb_phieuphat.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia=@iddocgia
	   delete dbo.tb_phieuphat from tb_phieuphat inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai= tb_phieuphat.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia=@iddocgia
	   delete dbo.tb_ct_nhanlai from tb_ct_nhanlai inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_ct_nhanlai.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia =@iddocgia
	   delete dbo.tb_bb_nhanlaisach from tb_bb_nhanlaisach where tb_bb_nhanlaisach.mathedocgia=@iddocgia
	   delete dbo.tb_docgia from tb_docgia where tb_docgia.mathedocgia = @iddocgia

	end
end
GO
/****** Object:  StoredProcedure [dbo].[DKTaiKhoan]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DKTaiKhoan](@mail nvarchar(30) , @pass nvarchar(30) , @name nvarchar(30) , @quyen int )
as 
begin
 insert into tb_NhanVien (tennhanvien) values (@name)
 declare @manv int
 select @manv= tb_NhanVien.manhanvien from tb_NhanVien where tb_NhanVien.tennhanvien = @name
 SET IDENTITY_INSERT tb_Acount ON
 insert into tb_Acount ( manhanvien, Gmail , Password , quyen) values (@manv , @mail , @pass , @quyen)
 SET IDENTITY_INSERT tb_Acount OFF 
end
GO
/****** Object:  StoredProcedure [dbo].[Insert_Acount]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Insert_Acount] @Gmail nvarchar(30) , @Password nvarchar(30) ,@Quyen varchar(30) , @ten nvarchar(30)

as 
begin
  Insert into dbo.tb_Acount ( Gmail , Password , quyen ) values (@Gmail , @Password , @Quyen )
  Insert into dbo.tb_NhanVien(tennhanvien) values (@ten)
end
GO
/****** Object:  StoredProcedure [dbo].[Repair]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Repair](@iddocgia int , @name nvarchar(30) , @ngsinh Date , @nglamthe date  , @dchi nvarchar(30) , @doituongdocgia nvarchar(30) )
as 
begin 
  declare @tinhtrang int 
  set @tinhtrang = 0
  select @tinhtrang= tb_sach.tinhtrangsach from tb_sach inner join tb_ct_phieubangiao on tb_sach.maquyensach = tb_ct_phieubangiao.maquyensach
	                                                           inner join tb_phieubangiaosach on tb_ct_phieubangiao.maphieubangiao = tb_phieubangiaosach.maphieubangiao
															   inner join tb_docgia on tb_phieubangiaosach.mathedocgia = @iddocgia
  if(@tinhtrang = 2)
  begin 
   --select @tinhtrang as result
   print'khong muon duoc'
  end
  else if(@tinhtrang = 0)
  begin 
   --select @tinhtrang as result
   update tb_docgia set hoten = @name , ngaysinh = @ngsinh , ngaylamthe = @nglamthe , diachi = @dchi ,doituongdocgia = @doituongdocgia where mathedocgia=@iddocgia
    --select @tinhtrang as result
  end
   select @tinhtrang as rs_RS
end
GO
/****** Object:  StoredProcedure [dbo].[USP_delete1DauSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_delete1DauSach]
@iddausach int
as
begin
DECLARE @masach int
DECLARE @soluong int
select @soluong = soluong from tb_dausach where madausach= @iddausach
if exists(select tb_sach.maquyensach from tb_sach inner join tb_dausach on tb_sach.madausach=tb_dausach.madausach where tb_sach.tinhtrangsach=2 AND tb_dausach.madausach=@iddausach)
  begin
    print N'không được phép xóa có người mượn'
  end
else
  begin
	 DECLARE @count int
    set @count = 1
     while @count <= @soluong
	   begin
	   DECLARE @idquyensach int =0
	   	SELECT @idquyensach =maquyensach FROM  dbo.tb_sach  WHERE maquyensach = (SELECT MAX(maquyensach)  FROM dbo.tb_sach where madausach =@iddausach) AND madausach =@iddausach
		exec USP_Delete1QuyenSach @idsach = @idquyensach 
		set @count= @count+1
       end
	Delete tb_ct_tacgia Where madausach =@iddausach
	Delete tb_dausach Where madausach =@iddausach
  end  
end
GO
/****** Object:  StoredProcedure [dbo].[USP_Delete1QuyenSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_Delete1QuyenSach]
@idsach int
AS
BEGIN
DECLARE @soluong int 
DECLARE @idmadausach1 int 
DECLARE @trangthai int
SELECT @trangthai =tinhtrangsach FROM dbo.tb_sach WHERE maquyensach=@idsach
IF(@trangthai=1 or @trangthai=3)
  BEGIN
    SELECT @soluong = soluong FROM dbo.tb_sach INNER JOIN dbo.tb_dausach ON tb_dausach.madausach = tb_sach.madausach WHERE maquyensach =@idsach
	SELECT @idmadausach1 = tb_dausach.madausach FROM dbo.tb_sach INNER JOIN dbo.tb_dausach ON tb_dausach.madausach = tb_sach.madausach WHERE maquyensach =@idsach
  
    
   DELETE dbo.tb_ct_phieubangiao from tb_ct_phieubangiao inner join tb_sach on tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach where tb_sach.maquyensach= @idsach
   DELETE dbo.tb_ct_phieuphat from tb_ct_phieuphat inner join tb_sach on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach where tb_sach.maquyensach= @idsach
   DELETE dbo.tb_ct_nhanlai from tb_ct_nhanlai inner join tb_sach on tb_ct_nhanlai.maquyensach = tb_sach.maquyensach where tb_sach.maquyensach= @idsach
   UPDATE dbo.tb_dausach SET soluong =@soluong-1 FROM dbo.tb_dausach INNER JOIN dbo.tb_sach ON tb_sach.madausach = tb_dausach.madausach WHERE maquyensach =@idsach 
   DELETE dbo.tb_sach FROM dbo.tb_sach WHERE maquyensach=@idsach	

 END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_DELETEBOOKLOSS]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_DELETEBOOKLOSS]
as
begin
DECLARE maQuyensachcursor cursor for select tb_sach.maquyensach from dbo.tb_sach where tinhtrangsach=3
declare @maquyensach int
OPEN maQuyensachcursor
FETCH NEXT FROM maQuyensachcursor INTO @maquyensach
while @@FETCH_STATUS =0
begin
  exec USP_Delete1QuyenSach @idsach = @maquyensach
  FETCH NEXT FROM maQuyensachcursor INTO @maquyensach
end 
close maQuyensachcursor 
DEALLOCATE maQuyensachcursor
end
GO
/****** Object:  StoredProcedure [dbo].[USP_DocGiaBiPhat]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_DocGiaBiPhat] 
@madocgia int
as
begin
declare @rs int =0
declare @solanbiphat int
select @solanbiphat =count(*) from tb_phieuphat inner join tb_bb_nhanlaisach on tb_phieuphat.mabbnhanlai = tb_bb_nhanlaisach.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia= @madocgia
if @solanbiphat > 3
  begin
    print'khóa tài khoản do bị phạt nhiều'
	set @rs = 1
  end
  select @rs
end
GO
/****** Object:  StoredProcedure [dbo].[USP_insert1quyenSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[USP_insert1quyenSach]
@tentacgia nvarchar(30),@tendausach nvarchar(30),@soluong int,@sotrang int 
AS
BEGIN
INSERT dbo.tb_dausach(tendausach,soluong,sotrang)VALUES(@tendausach,@soluong,@sotrang)
INSERT dbo.tb_tacgia(tentacgia)VALUES(@tentacgia)
DECLARE @idtacgia INT
DECLARE @iddausach INT
SELECT @iddausach =madausach FROM  dbo.tb_dausach WHERE madausach = (SELECT MAX(madausach)  FROM dbo.tb_dausach)
SELECT @idtacgia =matacgia FROM  dbo.tb_tacgia WHERE matacgia = (SELECT MAX(matacgia)  FROM dbo.tb_tacgia)
INSERT dbo.tb_ct_tacgia(matacgia,madausach,vaitrotacgia)VALUES(@idtacgia,@iddausach,N'Chủ biên')
-- so luong ==> sach sẽ tự động tăng id
DECLARE @count INT;
SET @count = 1;    
WHILE @count<= @soluong
BEGIN
   INSERT dbo.tb_sach(madausach,tinhtrangsach)VALUES(@iddausach, 1)
   SET @count = @count + 1;
END;
END
GO
/****** Object:  StoredProcedure [dbo].[USP_insertPhieuBanGiao]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_insertPhieuBanGiao]
@idSach int,@mathedocgia int,@manhanvien int,@ngaymuon date,@ngaydukientra date, @tinhtrangkhigiao nvarchar(30)
AS
BEGIN
DECLARE @tinhtrang int
SELECT @tinhtrang=tinhtrangsach FROM dbo.tb_sach WHERE maquyensach =@idSach

 IF (@tinhtrang=1 AND exists(select * from tb_sach where maquyensach= @idSach) AND exists(select * from tb_docgia where mathedocgia= @mathedocgia) AND exists(select * from tb_NhanVien where manhanvien= @manhanvien))
	BEGIN
	INSERT INTO dbo.tb_phieubangiaosach(mathedocgia,manhanvien,ngaymuon,ngaydukientra,tinhtrangkhigiao)VALUES(@mathedocgia,@manhanvien,@ngaymuon,@ngaydukientra ,@tinhtrangkhigiao)
	DECLARE @idphieubangiao INT
	SELECT @idphieubangiao =maphieubangiao FROM  dbo.tb_phieubangiaosach WHERE maphieubangiao = (SELECT MAX(maphieubangiao)  FROM dbo.tb_phieubangiaosach)
	INSERT INTO dbo.tb_ct_phieubangiao(maquyensach,maphieubangiao)VALUES(@idSach,@idphieubangiao)
	UPDATE dbo.tb_sach SET tinhtrangsach=2 WHERE maquyensach= @idSach
	DECLARE @soluong INT
	SELECT @soluong = soluong FROM dbo.tb_dausach INNER JOIN dbo.tb_sach 
	ON tb_sach.madausach = tb_dausach.madausach WHERE dbo.tb_sach.maquyensach =@idSach
	UPDATE dbo.tb_dausach SET soluong = @soluong -1 FROM dbo.tb_dausach INNER JOIN dbo.tb_sach 
	ON tb_sach.madausach = tb_dausach.madausach WHERE dbo.tb_sach.maquyensach =@idSach    
    END
END
GO
/****** Object:  StoredProcedure [dbo].[USP_LietkeTT1DS]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_LietkeTT1DS]
@idsach int
as
begin
select * from FUN_LietKeTrangThai1DauSach(@idsach)
end
GO
/****** Object:  StoredProcedure [dbo].[USP_matsach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_matsach]
@ngaytra date , @mathedocgia int ,@manhanvien int , @idSach int, @sotienphat int
AS
BEGIN
DECLARE @hantra DATE
DECLARE @soluong INT
DECLARE @tinhtrang INT
DECLARE @songay INT
SELECT @hantra= dbo.tb_phieubangiaosach.ngaydukientra FROM dbo.tb_sach INNER JOIN dbo.tb_ct_phieubangiao ON tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
	INNER JOIN dbo.tb_phieubangiaosach ON tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao
	WHERE dbo.tb_phieubangiaosach.mathedocgia= @mathedocgia AND dbo.tb_sach.tinhtrangsach =2 AND dbo.tb_sach.maquyensach=@idSach

if (exists(select * from tb_sach where maquyensach= @idSach) AND exists(select * from tb_docgia where mathedocgia= @mathedocgia) AND exists(select * from tb_NhanVien where manhanvien= @manhanvien) AND exists(select *from tb_sach where maquyensach=@idSach and tinhtrangsach=2))
begin
SELECT @songay = DATEDIFF(day,@hantra, @ngaytra)
	 IF(@songay <=0)
	  set @songay =0
	 IF EXISTS(SELECT * FROM Func_sach1muonDocGia(@mathedocgia))
	 begin
	 DECLARE @idbbnhanlai1 INT
			DECLARE @idphieuphat INT
			INSERT dbo.tb_bb_nhanlaisach(mathedocgia,manhanvien,ngaytra)VALUES(@mathedocgia,@manhanvien,@ngaytra)
			SELECT @idbbnhanlai1 =mabbnhanlai FROM  dbo.tb_bb_nhanlaisach WHERE mabbnhanlai = (SELECT MAX(mabbnhanlai)  FROM dbo.tb_bb_nhanlaisach)
			INSERT dbo.tb_phieuphat(mabbnhanlai,tongtien)VALUES(@idbbnhanlai1,@sotienphat+2000*@songay)
			SELECT @idphieuphat =maphieuphat FROM  dbo.tb_phieuphat WHERE maphieuphat = (SELECT MAX(maphieuphat)  FROM dbo.tb_phieuphat)
			select @soluong = tb_dausach.soluong from tb_dausach inner join tb_sach on tb_sach.madausach= tb_dausach.madausach where maquyensach=@idSach			
			INSERT dbo.tb_ct_phieuphat(maphieuphat,maquyensach,songayquahan,tinhtranghong)VALUES(@idphieuphat,@idSach,@songay ,N'mất sách')
			INSERT dbo.tb_ct_nhanlai(mabbnhanlai,maquyensach,tinhtrangnhanlai)VALUES(@idbbnhanlai1,@idSach,N'mất sách')
			UPDATE dbo.tb_sach SET tinhtrangsach=3 WHERE maquyensach =@idSach
			UPDATE tb_dausach set soluong = @soluong+1 from tb_dausach inner join tb_sach on tb_sach.madausach= tb_dausach.madausach where maquyensach=@idSach
	 end 
end
END
GO
/****** Object:  StoredProcedure [dbo].[USP_MoKhoaTheDocGia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_MoKhoaTheDocGia]
@idmathedocgia int
as
begin
	delete tb_ct_phieuphat from tb_ct_phieuphat inner join tb_phieuphat on tb_ct_phieuphat.maphieuphat = tb_phieuphat.maphieuphat inner join tb_bb_nhanlaisach 
	on tb_bb_nhanlaisach.mabbnhanlai = tb_phieuphat.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia =@idmathedocgia
	delete tb_phieuphat from tb_phieuphat inner join tb_bb_nhanlaisach 
	on tb_bb_nhanlaisach.mabbnhanlai = tb_phieuphat.mabbnhanlai where tb_bb_nhanlaisach.mathedocgia =@idmathedocgia     
end
GO
/****** Object:  StoredProcedure [dbo].[USP_PrintPhieuBanGiao]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_PrintPhieuBanGiao]
@idSach int,@mathedocgia int,@manhanvien int,@ngaymuon date,@ngaydukientra date, @tinhtrangkhigiao nvarchar(30)
as
begin
select tb_docgia.*,tb_NhanVien.tennhanvien,tb_sach.maquyensach,tb_dausach.*,tb_tacgia.tentacgia,@ngaydukientra[ngaydukientra],@ngaymuon[ngaymuon],@tinhtrangkhigiao[tinhtrangkhigiao]
from tb_docgia,tb_NhanVien, tb_dausach inner join tb_sach on tb_dausach.madausach = tb_sach.madausach inner join tb_ct_tacgia on tb_ct_tacgia.madausach = tb_dausach.madausach inner join tb_tacgia on tb_ct_tacgia.matacgia= tb_tacgia.matacgia
where tb_sach.maquyensach = @idSach and tb_docgia.mathedocgia =@mathedocgia and tb_NhanVien.manhanvien=@manhanvien and tb_sach.tinhtrangsach=2
end
GO
/****** Object:  StoredProcedure [dbo].[USP_PrintPhieuTrasach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_PrintPhieuTrasach]
@idSach int
as
begin
	IF(exists(select tb_phieuphat.* from tb_sach inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach= tb_sach.maquyensach
		inner join tb_ct_phieuphat on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach
		inner join tb_phieuphat on tb_phieuphat.maphieuphat= tb_ct_phieuphat.maphieuphat
		inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_phieuphat.mabbnhanlai
		where tb_sach.maquyensach =@idSach))
	begin
	
		select tb_sach.maquyensach,tb_dausach.*,tb_tacgia.tentacgia,tb_docgia.*,tb_ct_phieuphat.*,tb_phieuphat.tongtien from tb_sach
		inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach= tb_sach.maquyensach
		inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_ct_nhanlai.mabbnhanlai
		inner join tb_docgia on tb_docgia.mathedocgia = tb_bb_nhanlaisach.mathedocgia
		inner join tb_dausach on tb_dausach.madausach= tb_sach.madausach 
		inner join tb_ct_tacgia on tb_ct_tacgia.madausach = tb_dausach.madausach
		inner join tb_ct_phieuphat on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach
		inner join tb_phieuphat on tb_phieuphat.maphieuphat= tb_ct_phieuphat.maphieuphat
		inner join tb_tacgia on tb_tacgia.matacgia= tb_ct_tacgia.matacgia where tb_sach.maquyensach=@idSach
	end
	else
	begin
		select tb_sach.maquyensach,tb_dausach.*,tb_tacgia.tentacgia,tb_docgia.* from tb_sach
		inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach= tb_sach.maquyensach
		inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_ct_nhanlai.mabbnhanlai
		inner join tb_docgia on tb_docgia.mathedocgia = tb_bb_nhanlaisach.mathedocgia
		inner join tb_dausach on tb_dausach.madausach= tb_sach.madausach 
		inner join tb_ct_tacgia on tb_ct_tacgia.madausach = tb_dausach.madausach
		inner join tb_tacgia on tb_tacgia.matacgia= tb_ct_tacgia.matacgia where tb_sach.maquyensach=@idSach
	end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_PrintPhieuTrasachtest1]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_PrintPhieuTrasachtest1]
@idSach int
as
begin
DECLARE @UserStatus INT 
IF(exists(select tb_phieuphat.* from tb_sach inner join tb_ct_nhanlai on tb_ct_nhanlai.maquyensach= tb_sach.maquyensach
		inner join tb_ct_phieuphat on tb_ct_phieuphat.maquyensach = tb_sach.maquyensach
		inner join tb_phieuphat on tb_phieuphat.maphieuphat= tb_ct_phieuphat.maphieuphat
		inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mabbnhanlai = tb_phieuphat.mabbnhanlai
		where tb_sach.maquyensach =@idSach))
	begin
		set @UserStatus = 1 
		SELECT @UserStatus
	end
else
	begin
	set @UserStatus = 0 
	SELECT @UserStatus 
	end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_sachmuon1DocGia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_sachmuon1DocGia]
@iddocgia int
AS
BEGIN
SELECT dbo.tb_sach.*,dbo.tb_dausach.tendausach FROM dbo.tb_sach INNER JOIN tb_dausach on tb_sach.madausach=tb_dausach.madausach  INNER JOIN dbo.tb_ct_phieubangiao ON tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
INNER JOIN dbo.tb_phieubangiaosach ON tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao
WHERE dbo.tb_phieubangiaosach.mathedocgia= @iddocgia AND dbo.tb_sach.tinhtrangsach =2
END 
GO
/****** Object:  StoredProcedure [dbo].[USP_searchDauSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_searchDauSach]
@name nvarchar(40)
as
begin
SELECT * FROM List1SACH() WHERE dbo.[functiontoSearch](tendausach)  LIKE  N'%'+dbo.[functiontoSearch](@name)+'%' or dbo.[functiontoSearch](tentacgia)  LIKE  N'%'+dbo.[functiontoSearch](@name)+'%'
or dbo.[functiontoSearch](CONVERT(varchar(5),madausach))  LIKE  N'%'+dbo.[functiontoSearch](@name)+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[USP_them1QS]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_them1QS]
@idmadausach int
as
begin
DECLARE @soluong INT;
insert dbo.tb_sach(madausach,tinhtrangsach)VALUES(@idmadausach,1)
Update tb_dausach set soluong= soluong+1 FROM dbo.tb_dausach WHERE madausach=@idmadausach
end
GO
/****** Object:  StoredProcedure [dbo].[USP_THONGKE_TS]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_THONGKE_TS]
as
begin
 declare @idds int
 while @@FETCH_STATUS =0
   begin
     select @idds=madausach from tb_dausach
	 exec USPTanSuatmuoncua1quyenSach @idmasach=@idds 
   end
end
GO
/****** Object:  StoredProcedure [dbo].[USP_traSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_traSach]
@ngaytra date , @mathedocgia int ,@manhanvien int , @idSach int 
AS
BEGIN
DECLARE @tinhtrang INT
if (exists(select * from tb_sach where maquyensach= @idSach) AND exists(select * from tb_docgia where mathedocgia= @mathedocgia) AND exists(select * from tb_NhanVien where manhanvien= @manhanvien) AND exists(select *from tb_sach where maquyensach=@idSach and tinhtrangsach=2))
begin
DECLARE @hantra DATE
DECLARE @songay INT
DECLARE @soluong INT

SELECT @hantra= dbo.tb_phieubangiaosach.ngaydukientra FROM dbo.tb_sach INNER JOIN dbo.tb_ct_phieubangiao ON tb_ct_phieubangiao.maquyensach = tb_sach.maquyensach 
	INNER JOIN dbo.tb_phieubangiaosach ON tb_phieubangiaosach.maphieubangiao = tb_ct_phieubangiao.maphieubangiao
	WHERE dbo.tb_phieubangiaosach.mathedocgia= @mathedocgia AND dbo.tb_sach.tinhtrangsach =2 AND dbo.tb_sach.maquyensach=@idSach
SELECT @songay = DATEDIFF(day,@hantra, @ngaytra)
    IF EXISTS(SELECT * FROM Func_sach1muonDocGia(@mathedocgia)) 
		BEGIN
		-- chỉ cho phép quá hạn 3 ngày
		 IF(@songay<=3)
			BEGIN
			-- trả sách không bị phạt
			INSERT dbo.tb_bb_nhanlaisach(mathedocgia,manhanvien,ngaytra)VALUES(@mathedocgia,@manhanvien,@ngaytra)
			DECLARE @idbbnhanlai INT 
			SELECT @idbbnhanlai =mabbnhanlai FROM  dbo.tb_bb_nhanlaisach WHERE mabbnhanlai = (SELECT MAX(mabbnhanlai)  FROM dbo.tb_bb_nhanlaisach)
			select @soluong = tb_dausach.soluong from tb_dausach inner join tb_sach on tb_sach.madausach= tb_dausach.madausach where maquyensach=@idSach
			INSERT dbo.tb_ct_nhanlai(mabbnhanlai,maquyensach,tinhtrangnhanlai)VALUES(@idbbnhanlai,@idSach,N'Nguyên vẹn')
			UPDATE dbo.tb_sach SET tinhtrangsach=1 WHERE maquyensach =@idSach
			UPDATE tb_dausach set soluong = @soluong+1 from tb_dausach inner join tb_sach on tb_sach.madausach= tb_dausach.madausach where maquyensach=@idSach
			END
		ELSE
		    -- phạt trả sách vì quá hạn
			BEGIN
			DECLARE @idbbnhanlai1 INT
			DECLARE @idphieuphat INT
			INSERT dbo.tb_bb_nhanlaisach(mathedocgia,manhanvien,ngaytra)VALUES(@mathedocgia,@manhanvien,@ngaytra)
			SELECT @idbbnhanlai1 =mabbnhanlai FROM  dbo.tb_bb_nhanlaisach WHERE mabbnhanlai = (SELECT MAX(mabbnhanlai)  FROM dbo.tb_bb_nhanlaisach)
			INSERT dbo.tb_phieuphat(mabbnhanlai,tongtien)VALUES(@idbbnhanlai1,2000*@songay)
			SELECT @idphieuphat =maphieuphat FROM  dbo.tb_phieuphat WHERE maphieuphat = (SELECT MAX(maphieuphat)  FROM dbo.tb_phieuphat)
			select @soluong = tb_dausach.soluong from tb_dausach inner join tb_sach on tb_sach.madausach= tb_dausach.madausach where maquyensach=@idSach			
			INSERT dbo.tb_ct_phieuphat(maphieuphat,maquyensach,songayquahan,tinhtranghong)VALUES(@idphieuphat,@idSach,@songay ,N'quá hạn')
			INSERT dbo.tb_ct_nhanlai(mabbnhanlai,maquyensach,tinhtrangnhanlai)VALUES(@idbbnhanlai1,@idSach,N'Nguyên vẹn')
			UPDATE dbo.tb_sach SET tinhtrangsach=1 WHERE maquyensach =@idSach
			UPDATE tb_dausach set soluong = @soluong+1 from tb_dausach inner join tb_sach on tb_sach.madausach= tb_dausach.madausach where maquyensach=@idSach
			END
		 END
	END 	
END
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateDauSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_UpdateDauSach]
@iddausach int ,@tendausach nvarchar(30), @tentacgia nvarchar(30),@soluong int , @sotrang int
as
begin
declare @soluong_pre int 
select @soluong_pre = soluong from tb_dausach where madausach= @iddausach
update tb_dausach set tendausach=@tendausach,soluong=@soluong,sotrang=@sotrang where madausach=@iddausach
update tb_tacgia set tentacgia =@tentacgia from tb_tacgia 
		inner join tb_ct_tacgia on tb_tacgia.matacgia = tb_ct_tacgia.matacgia
		inner join tb_dausach on tb_ct_tacgia.madausach= tb_dausach.madausach where tb_dausach.madausach =@iddausach
 if @soluong > @soluong_pre
	begin
	declare @countSL int
	declare @count int
	set @count=1
	set @countSL = @soluong - @soluong_pre
	--insert 
	  while @count <= @countSL
	    begin
		  INSERT dbo.tb_sach(madausach,tinhtrangsach)VALUES(@iddausach,1)
		  SET @count = @count + 1;
		end
	end
else if @soluong < @soluong_pre
	begin
		declare @countSL1 int
		declare @count1 int
		set @count=1
		set @countSL1 = @soluong_pre-@soluong
		while @count1 <= @countSL1
		  begin
		    DECLARE @idsach INT
			SELECT @idsach =maquyensach FROM  dbo.tb_sach WHERE maquyensach = (SELECT MIN(maquyensach)  FROM dbo.tb_sach) AND tinhtrangsach=1
		    delete tb_sach where maquyensach=@idsach
		  end
	end
end
GO
/****** Object:  StoredProcedure [dbo].[USPsearch]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USPsearch]
@name nvarchar(4000)
as
begin
SELECT tb_sach.maquyensach,tb_dausach.tendausach FROM dbo.tb_dausach inner join tb_sach on tb_sach.madausach=tb_dausach.madausach
WHERE (dbo.[functiontoSearch](tendausach) LIKE  N'%'+dbo.[functiontoSearch](@name)+'%' or 
dbo.[functiontoSearch](CONVERT(varchar(5),maquyensach))  LIKE  N'%'+dbo.[functiontoSearch](@name)+'%')  and tb_sach.tinhtrangsach=1
end
GO
/****** Object:  StoredProcedure [dbo].[USPsearch_DGMuon]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USPsearch_DGMuon]
@name nvarchar(4000)
as
begin
SELECT * FROM Search_PBG() WHERE dbo.[functiontoSearch](hoten) LIKE  N'%'+dbo.[functiontoSearch](@name)+'%'
or dbo.[functiontoSearch](CONVERT(varchar(5),mathedocgia))  LIKE  N'%'+dbo.[functiontoSearch](@name)+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[USPsearch_sach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USPsearch_sach]
@name nvarchar(4000)
as
begin
SELECT tb_sach.maquyensach,tb_sach.tinhtrangsach ,tb_dausach.tendausach from dbo.tb_dausach inner join tb_sach on tb_sach.madausach=tb_dausach.madausach
WHERE dbo.[functiontoSearch](tendausach) LIKE  N'%'+dbo.[functiontoSearch](@name)+'%' and tb_sach.tinhtrangsach=1
end
GO
/****** Object:  StoredProcedure [dbo].[USPsearch_tenDocGia]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USPsearch_tenDocGia]
@name nvarchar(4000)
as
begin
SELECT * FROM dbo.tb_docgia WHERE dbo.[functiontoSearch](hoten) LIKE  N'%'+dbo.[functiontoSearch](@name)+'%'
or dbo.[functiontoSearch](CONVERT(varchar(5),mathedocgia))  LIKE  N'%'+dbo.[functiontoSearch](@name)+'%'
end
GO
/****** Object:  StoredProcedure [dbo].[USPTanSuatmuoncua1quyenSach]    Script Date: 24/03/2022 11:59:33 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USPTanSuatmuoncua1quyenSach]
@idmasach int
as
begin
  declare @solan1 int =0
  declare @solan2 int =0
	
	select @solan1 = solan from funcTanSuatTuPBG(@idmasach)	
	select @solan2=solan from funcTanSuatTuPNL(@idmasach)

	select *,(@solan1+@solan2)[solan] from tb_dausach where tb_dausach.madausach =@idmasach
end
GO
USE [master]
GO
ALTER DATABASE [QLTV_Desktop] SET  READ_WRITE 
GO
