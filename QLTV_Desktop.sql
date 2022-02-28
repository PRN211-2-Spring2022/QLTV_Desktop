USE [master]
GO
/****** Object:  Database [QLTV_Desktop] ******/
CREATE DATABASE [QLTV_Desktop]
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
/****** Object:  UserDefinedFunction [dbo].[functiontoSearch]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[TinhTRangString]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[USP_PrintPhieuTrasach1]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_tacgia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_dausach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
 CONSTRAINT [pk_tb_dausach] PRIMARY KEY CLUSTERED 
(
	[madausach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_ct_tacgia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_sach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_docgia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_phieubangiaosach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_ct_phieubangiao]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Report_muon]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_bb_nhanlaisach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_ct_nhanlai]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Report_tra]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_NhanVien]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_Acount]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[FunC_InformationNV]    Script Date: 5/31/2021 7:07:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[FunC_InformationNV] ()

returns table
as
return select tb_NhanVien.*   from tb_Acount right join tb_NhanVien  on  tb_Acount.manhanVien = tb_NhanVien.manhanvien
GO
/****** Object:  UserDefinedFunction [dbo].[History_borrow]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Search_PBG]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[USP_PrintPhieuBanGiao1]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_phieuphat]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Table [dbo].[tb_ct_phieuphat]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Function_PhieuTraBiPhat]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Report_muon_nQuyen]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Function_PhieuTraNoBiPhat]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Report_phat]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[Function_Print1DGtuSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[funcTanSuatTuPBG]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[funcTanSuatTuPNL]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[fun_loadAlLDSbyDocGia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[functhongkeTTQS]    Script Date: 5/31/2021 7:07:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[functhongkeTTQS]()
returns table
as
return select dbo.[TinhTRangString](tb_sach.tinhtrangsach)[tinhtrang],count(*)[thongke] from tb_sach group by tb_sach.tinhtrangsach

GO
/****** Object:  UserDefinedFunction [dbo].[function_listSachLOSS]    Script Date: 5/31/2021 7:07:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[function_listSachLOSS]()
returns table
as
return select tb_sach.maquyensach,tb_dausach.*,  tb_docgia.hoten , tb_sach.tinhtrangsach from tb_docgia inner join tb_bb_nhanlaisach on tb_bb_nhanlaisach.mathedocgia = tb_docgia.mathedocgia inner join tb_phieuphat on tb_phieuphat.mabbnhanlai = tb_bb_nhanlaisach.mabbnhanlai inner join tb_ct_phieuphat on tb_ct_phieuphat.maphieuphat = tb_phieuphat.maphieuphat inner join tb_sach on tb_sach.maquyensach = tb_ct_phieuphat.maquyensach inner join tb_dausach on tb_dausach.madausach = tb_sach.madausach where tb_sach.tinhtrangsach = 3 
GO
/****** Object:  UserDefinedFunction [dbo].[Func_sach1muonDocGia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[FUN_LietKeTrangThai1DauSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[List1SACH]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[ListALLQS]    Script Date: 5/31/2021 7:07:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[ListALLQS](@iddausach int)
returns table
as 
return select tb_sach.maquyensach,tb_sach.tinhtrangsach from tb_sach where madausach=@iddausach 
GO
/****** Object:  UserDefinedFunction [dbo].[TaiKhoan]    Script Date: 5/31/2021 7:07:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[TaiKhoan](@gmail nvarchar(30) )
returns table
as
return select  tb_Acount.Gmail , tb_Acount.Password , tb_Acount.quyen, tb_NhanVien.* from tb_Acount inner join tb_NhanVien on tb_Acount.manhanvien = tb_NhanVien.manhanvien where  tb_Acount.Gmail = @gmail 
GO
SET IDENTITY_INSERT [dbo].[tb_Acount] ON 

INSERT [dbo].[tb_Acount] ([Gmail], [Password], [manhanvien], [quyen]) VALUES (N'LongRong', N'123456', 112, 0)
INSERT [dbo].[tb_Acount] ([Gmail], [Password], [manhanvien], [quyen]) VALUES (N'LongRong', N'123456', 114, 0)
INSERT [dbo].[tb_Acount] ([Gmail], [Password], [manhanvien], [quyen]) VALUES (N'XuanDuc', N'123456', 116, 1)
INSERT [dbo].[tb_Acount] ([Gmail], [Password], [manhanvien], [quyen]) VALUES (N'CongLien', N'123456', 100, 1)
INSERT [dbo].[tb_Acount] ([Gmail], [Password], [manhanvien], [quyen]) VALUES (N'LienCong', N'123456', 106, 0)
SET IDENTITY_INSERT [dbo].[tb_Acount] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_bb_nhanlaisach] ON 

INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (600, 508, 100, CAST(N'2021-05-12' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (602, 508, 100, CAST(N'2021-11-18' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (604, 512, 100, CAST(N'2021-06-01' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (606, 512, 100, CAST(N'2021-06-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (608, 512, 100, CAST(N'2021-06-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (610, 508, 100, CAST(N'2021-11-18' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (612, 508, 100, CAST(N'2021-11-18' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (614, 508, 100, CAST(N'2021-05-14' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (616, 508, 100, CAST(N'2021-06-16' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (618, 508, 100, CAST(N'2021-07-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (620, 512, 100, CAST(N'2021-06-19' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (622, 512, 100, CAST(N'2021-06-19' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (624, 508, 100, CAST(N'2021-05-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (626, 540, 100, CAST(N'2021-06-23' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (628, 540, 100, CAST(N'2021-06-23' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (630, 540, 100, CAST(N'2021-06-23' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (632, 540, 100, CAST(N'2021-06-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (634, 508, 100, CAST(N'2021-05-28' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (636, 508, 100, CAST(N'2021-05-29' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (638, 508, 100, CAST(N'2021-05-18' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (640, 512, 100, CAST(N'2021-05-15' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (642, 512, 100, CAST(N'2021-09-15' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (644, 512, 100, CAST(N'2021-09-15' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (646, 512, 100, CAST(N'2021-09-15' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (648, 508, 100, CAST(N'2021-10-27' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (650, 508, 100, CAST(N'2021-07-28' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (652, 508, 100, CAST(N'2021-07-28' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (654, 512, 100, CAST(N'2021-06-26' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (656, 512, 100, CAST(N'2021-12-25' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (658, 512, 100, CAST(N'2021-12-25' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (660, 514, 100, CAST(N'2021-09-24' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (662, 518, 100, CAST(N'2021-05-29' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (664, 520, 100, CAST(N'2021-05-26' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (666, 522, 100, CAST(N'2021-05-18' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (668, 538, 100, CAST(N'2021-07-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (670, 532, 100, CAST(N'2021-08-13' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (672, 534, 100, CAST(N'2021-05-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (674, 536, 100, CAST(N'2021-08-26' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (676, 540, 100, CAST(N'2021-05-28' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (678, 516, 100, CAST(N'2021-05-27' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (680, 520, 100, CAST(N'2021-06-23' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (682, 514, 100, CAST(N'2021-05-24' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (684, 530, 100, CAST(N'2021-07-22' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (686, 530, 100, CAST(N'2021-05-24' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (688, 530, 100, CAST(N'2021-10-18' AS Date))
INSERT [dbo].[tb_bb_nhanlaisach] ([mabbnhanlai], [mathedocgia], [manhanvien], [ngaytra]) VALUES (690, 522, 100, CAST(N'2021-05-29' AS Date))
SET IDENTITY_INSERT [dbo].[tb_bb_nhanlaisach] OFF
GO
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (612, 472, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (634, 428, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (636, 472, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (640, 464, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (648, 426, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (654, 1006, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (664, 642, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (666, 420, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (670, 450, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (672, 420, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (676, 1128, N'mất sách')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (680, 474, N'mất sách')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (682, 444, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (684, 534, N'Nguyên vẹn')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (686, 546, N'mất sách')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (688, 566, N'mất sách')
INSERT [dbo].[tb_ct_nhanlai] ([mabbnhanlai], [maquyensach], [tinhtrangnhanlai]) VALUES (690, 436, N'Nguyên vẹn')
GO
INSERT [dbo].[tb_ct_phieubangiao] ([maquyensach], [maphieubangiao]) VALUES (420, 640)
INSERT [dbo].[tb_ct_phieubangiao] ([maquyensach], [maphieubangiao]) VALUES (446, 644)
INSERT [dbo].[tb_ct_phieubangiao] ([maquyensach], [maphieubangiao]) VALUES (624, 638)
INSERT [dbo].[tb_ct_phieubangiao] ([maquyensach], [maphieubangiao]) VALUES (630, 636)
GO
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (704, 472, 175, N'quá hạn')
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (730, 426, 72, N'quá hạn')
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (746, 450, 44, N'quá hạn')
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (750, 1128, 6, N'mất sách')
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (754, 474, 0, N'mất sách')
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (756, 534, 27, N'quá hạn')
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (758, 546, 0, N'mất sách')
INSERT [dbo].[tb_ct_phieuphat] ([maphieuphat], [maquyensach], [songayquahan], [tinhtranghong]) VALUES (760, 566, 115, N'mất sách')
GO
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (244, 302, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (246, 304, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (248, 306, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (250, 308, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (252, 310, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (254, 312, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (256, 314, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (258, 316, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (260, 318, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (262, 320, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (264, 322, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (266, 324, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (268, 326, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (270, 328, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (272, 330, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (274, 332, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (276, 334, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (278, 336, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (280, 338, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (282, 340, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (284, 342, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (286, 344, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (288, 346, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (290, 348, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (292, 350, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (294, 352, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (296, 354, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (298, 356, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (300, 358, N'Chủ biên')
INSERT [dbo].[tb_ct_tacgia] ([matacgia], [madausach], [vaitrotacgia]) VALUES (308, 366, N'Chủ biên')
GO
SET IDENTITY_INSERT [dbo].[tb_dausach] ON 

INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (302, N'Cơ Sở Dữ Liêu', 8, 300, 6)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (304, N'Machine learning', 6, 500, 3)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (306, N'Bảo đảm an toàn thông tin', 5, 400, 1)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (308, N'Lý thuyết cơ sở dữ liệu', 12, 400, 3)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (310, N'Cơ sở dữ liệu', 14, 350, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (312, N'Lập trình hướng đối tượng', 10, 200, 1)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (314, N'Toán rời rạc', 7, 250, 1)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (316, N'Machine learning 2', 6, 800, 1)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (318, N'Toán chuyên đề', 10, 240, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (320, N'Lý thuyết xác suất thống kê', 15, 100, 1)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (322, N'Giải tích 2', 15, 150, 2)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (324, N'Đại số tuyến tính', 20, 180, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (326, N'Giải tích 1', 11, 260, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (328, N'Lý thuyết hệ điều hành', 9, 360, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (330, N'Mạng máy tính', 9, 456, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (332, N'Công nghệ web', 9, 584, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (334, N'Nhà nước pháp luật', 17, 220, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (336, N'Kinh tế chính trị', 19, 550, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (338, N'Tư tưởng Hồ Chí Minh', 10, 500, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (340, N'Công tác Đảng, công tác chính ', 10, 650, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (342, N'Đạo đức học', 10, 80, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (344, N'Phân tích mã độc', 6, 800, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (346, N'Bài tập toán chuyên đề', 9, 240, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (348, N'Xác suất, thống kê', 17, 100, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (350, N'Bài tập Giải tích 2', 15, 150, 1)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (352, N'Bài tập Đại số tuyến tính', 17, 180, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (354, N'Bài tập Giải tích 1', 12, 252, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (356, N'Công nghệ người máy', 10, 360, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (358, N'An ninh thông tin', 10, 456, 0)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (360, N'Hệ tống thông tin', 9, 584, 1)
INSERT [dbo].[tb_dausach] ([madausach], [tendausach], [soluong], [sotrang], [tansuat]) VALUES (366, N'Lập Trình Web', 9, 400, 0)
SET IDENTITY_INSERT [dbo].[tb_dausach] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_docgia] ON 

INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (508, N'Trần Xuân Công', CAST(N'2000-08-27' AS Date), CAST(N'2020-10-11' AS Date), N'Hưng Yên', N'Học Viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (512, N'Nguyễn Thị Liên', CAST(N'2000-11-11' AS Date), CAST(N'2020-05-07' AS Date), N'Ninh BÌnh', N'Học Viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (514, N'Phạm Duy Hưng', CAST(N'2000-12-03' AS Date), CAST(N'2020-05-14' AS Date), N'Phú Thọ', N'Học Viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (516, N'Bùi Tuấn Hưng', CAST(N'2000-03-30' AS Date), CAST(N'2020-02-11' AS Date), N'Thái Bình', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (518, N'Nguyễn Thị Hằng', CAST(N'2000-08-24' AS Date), CAST(N'2020-03-11' AS Date), N'Hà Tĩnh', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (520, N'Nguyễn Thị Huyền Trang', CAST(N'2000-03-06' AS Date), CAST(N'2020-02-10' AS Date), N'Nghệ An', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (522, N'Lê Thị Minh Châu', CAST(N'2000-11-05' AS Date), CAST(N'2020-05-03' AS Date), N'Bình Phước', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (524, N'Đinh Đức Hoàn', CAST(N'2000-11-02' AS Date), CAST(N'2020-03-30' AS Date), N'Nghệ An', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (528, N'Nguyễn Vĩnh Trọng', CAST(N'2000-08-11' AS Date), CAST(N'2020-01-05' AS Date), N'Nghệ An', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (530, N'Lê Hữu Dũng', CAST(N'2000-09-26' AS Date), CAST(N'2020-02-11' AS Date), N'Ninh Bình', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (532, N'Hoàng Trọng Hùng', CAST(N'2000-05-14' AS Date), CAST(N'2020-02-23' AS Date), N'Gia Lai', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (534, N'Hoàng Anh Quý', CAST(N'2000-08-11' AS Date), CAST(N'2020-06-01' AS Date), N'Hà Nội', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (536, N'Nguyễn Văn Văn', CAST(N'2000-07-01' AS Date), CAST(N'2020-02-11' AS Date), N'Bắc Ninh', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (538, N'Dương Ngọc Minh', CAST(N'2000-05-02' AS Date), CAST(N'2020-05-02' AS Date), N'Bắc Giang', N'Học viên')
INSERT [dbo].[tb_docgia] ([mathedocgia], [hoten], [ngaysinh], [ngaylamthe], [diachi], [doituongdocgia]) VALUES (540, N'Phạm Tuấn Dũng', CAST(N'2000-05-18' AS Date), CAST(N'2020-06-24' AS Date), N'Thái Bình', N'Học Viên')
SET IDENTITY_INSERT [dbo].[tb_docgia] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_NhanVien] ON 

INSERT [dbo].[tb_NhanVien] ([manhanvien], [tennhanvien]) VALUES (100, N'Trần Xuân Công')
INSERT [dbo].[tb_NhanVien] ([manhanvien], [tennhanvien]) VALUES (106, N'Nguyễn Thị Liên')
INSERT [dbo].[tb_NhanVien] ([manhanvien], [tennhanvien]) VALUES (112, N'Vương Văn Rồng')
INSERT [dbo].[tb_NhanVien] ([manhanvien], [tennhanvien]) VALUES (114, N'Vương Văn Rồng')
INSERT [dbo].[tb_NhanVien] ([manhanvien], [tennhanvien]) VALUES (116, N'Trần Xuân Đức')
SET IDENTITY_INSERT [dbo].[tb_NhanVien] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_phieubangiaosach] ON 

INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (560, 508, 100, CAST(N'2021-05-17' AS Date), CAST(N'2021-07-21' AS Date), N'Nguyên Vẹn ')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (562, 508, 100, CAST(N'2021-05-17' AS Date), CAST(N'2021-08-25' AS Date), N'Nguyên Vẹn ')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (564, 508, 100, CAST(N'2021-05-17' AS Date), CAST(N'2021-06-23' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (566, 508, 100, CAST(N'2021-05-17' AS Date), CAST(N'2021-07-21' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (568, 508, 100, CAST(N'2021-05-19' AS Date), CAST(N'2021-08-16' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (570, 512, 100, CAST(N'2021-05-02' AS Date), CAST(N'2021-09-14' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (572, 508, 100, CAST(N'2021-05-18' AS Date), CAST(N'2021-09-30' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (574, 512, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-10-12' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (576, 512, 100, CAST(N'2021-05-17' AS Date), CAST(N'2021-11-18' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (578, 512, 100, CAST(N'2021-06-15' AS Date), CAST(N'2021-11-15' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (580, 512, 100, CAST(N'2021-06-15' AS Date), CAST(N'2021-10-11' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (582, 512, 100, CAST(N'2021-06-15' AS Date), CAST(N'2021-09-13' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (584, 512, 100, CAST(N'2021-06-25' AS Date), CAST(N'2021-09-18' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (586, 540, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-29' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (588, 540, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-06-21' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (590, 540, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-06-13' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (592, 540, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-06-14' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (596, 518, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-27' AS Date), N'Nguyên vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (598, 520, 100, CAST(N'2021-05-26' AS Date), CAST(N'2021-05-28' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (610, 514, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-29' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (612, 522, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-31' AS Date), N'ok')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (614, 538, 100, CAST(N'2021-05-20' AS Date), CAST(N'2021-06-24' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (616, 536, 100, CAST(N'2021-05-20' AS Date), CAST(N'2021-07-14' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (618, 534, 100, CAST(N'2021-05-20' AS Date), CAST(N'2021-07-30' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (620, 532, 100, CAST(N'2021-05-20' AS Date), CAST(N'2021-06-30' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (622, 540, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-22' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (624, 516, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-29' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (626, 522, 100, CAST(N'2021-05-14' AS Date), CAST(N'2021-05-26' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (628, 520, 100, CAST(N'2021-05-14' AS Date), CAST(N'2021-06-25' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (630, 530, 100, CAST(N'2021-06-01' AS Date), CAST(N'2021-06-25' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (632, 530, 100, CAST(N'2021-06-01' AS Date), CAST(N'2021-06-25' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (634, 530, 100, CAST(N'2021-06-01' AS Date), CAST(N'2021-06-25' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (636, 540, 100, CAST(N'2021-07-21' AS Date), CAST(N'2021-08-18' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (638, 536, 100, CAST(N'2021-05-09' AS Date), CAST(N'2021-09-22' AS Date), N'Nguyên Vẹn')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (640, 524, 100, CAST(N'2021-05-11' AS Date), CAST(N'2021-06-24' AS Date), N'Nguyên V?n')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (642, 514, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-28' AS Date), N'Nguyên Vẹn ')
INSERT [dbo].[tb_phieubangiaosach] ([maphieubangiao], [mathedocgia], [manhanvien], [ngaymuon], [ngaydukientra], [tinhtrangkhigiao]) VALUES (644, 534, 100, CAST(N'2021-05-12' AS Date), CAST(N'2021-05-29' AS Date), N'Nguyên Vẹn')
SET IDENTITY_INSERT [dbo].[tb_phieubangiaosach] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_phieuphat] ON 

INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (700, 600, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (702, 602, 844000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (704, 612, 350000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (706, 614, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (708, 616, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (710, 618, 608000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (712, 620, 504000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (714, 622, 508000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (724, 642, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (726, 644, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (728, 646, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (730, 648, 144000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (732, 650, 570000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (734, 652, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (736, 656, 696000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (738, 658, 706000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (740, 660, 736000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (742, 662, 504000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (744, 668, 556000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (746, 670, 88000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (748, 674, 86000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (750, 676, 512000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (752, 678, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (754, 680, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (756, 684, 54000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (758, 686, 500000)
INSERT [dbo].[tb_phieuphat] ([maphieuphat], [mabbnhanlai], [tongtien]) VALUES (760, 688, 730000)
SET IDENTITY_INSERT [dbo].[tb_phieuphat] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_sach] ON 

INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (420, 302, 2)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (422, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (424, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (426, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (428, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (430, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (432, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (436, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (438, 302, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (444, 304, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (446, 304, 2)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (448, 304, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (450, 304, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (452, 304, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (454, 304, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (456, 304, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (460, 306, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (462, 306, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (464, 306, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (466, 306, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (468, 306, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (470, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (472, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (474, 308, 3)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (476, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (478, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (480, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (482, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (484, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (486, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (488, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (490, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (492, 308, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (494, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (496, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (498, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (500, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (502, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (504, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (506, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (508, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (510, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (512, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (514, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (516, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (518, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (520, 310, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (522, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (524, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (526, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (528, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (530, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (532, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (534, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (536, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (538, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (540, 312, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (542, 314, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (544, 314, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (546, 314, 3)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (548, 314, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (550, 314, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (554, 314, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (556, 314, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (558, 316, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (560, 316, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (562, 316, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (564, 316, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (566, 316, 3)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (568, 316, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (570, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (572, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (574, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (576, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (578, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (580, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (582, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (584, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (586, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (588, 318, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (592, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (594, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (596, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (598, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (600, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (602, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (604, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (606, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (608, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (610, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (612, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (614, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (616, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (618, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (622, 320, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (624, 320, 2)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (626, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (628, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (630, 322, 2)
GO
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (632, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (634, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (636, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (638, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (640, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (642, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (644, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (646, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (648, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (650, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (652, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (654, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (656, 322, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (658, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (660, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (662, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (664, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (666, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (668, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (670, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (672, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (674, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (676, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (678, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (680, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (682, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (684, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (686, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (688, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (690, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (692, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (694, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (696, 324, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (698, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (700, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (702, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (704, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (706, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (708, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (710, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (714, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (716, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (718, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (720, 326, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (724, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (726, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (728, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (730, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (732, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (734, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (736, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (738, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (740, 328, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (742, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (744, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (746, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (748, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (750, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (754, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (756, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (758, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (760, 330, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (762, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (764, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (766, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (768, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (770, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (772, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (774, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (776, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (778, 332, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (780, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (782, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (784, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (786, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (788, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (790, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (792, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (794, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (796, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (798, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (800, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (802, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (804, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (806, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (808, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (810, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (812, 334, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (814, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (816, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (818, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (820, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (822, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (824, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (826, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (828, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (830, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (832, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (834, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (836, 336, 1)
GO
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (840, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (842, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (844, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (846, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (848, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (850, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (852, 336, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (854, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (856, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (858, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (860, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (862, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (864, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (866, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (868, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (870, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (872, 338, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (874, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (876, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (878, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (880, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (882, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (884, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (886, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (888, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (890, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (892, 340, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (894, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (896, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (898, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (900, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (902, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (904, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (906, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (908, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (910, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (912, 342, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (914, 344, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (916, 344, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (918, 344, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (920, 344, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (922, 344, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (924, 344, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (926, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (928, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (930, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (932, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (934, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (936, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (940, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (942, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (944, 346, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (946, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (948, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (950, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (952, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (954, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (956, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (958, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (960, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (962, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (964, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (966, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (968, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (970, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (972, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (976, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (978, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (980, 348, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (982, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (984, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (986, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (988, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (990, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (992, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (994, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (996, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (998, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1000, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1002, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1004, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1006, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1008, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1010, 350, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1014, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1018, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1020, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1022, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1024, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1026, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1028, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1030, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1034, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1036, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1038, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1040, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1042, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1044, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1046, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1048, 352, 1)
GO
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1052, 352, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1054, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1056, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1058, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1060, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1062, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1064, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1066, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1068, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1070, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1072, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1074, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1076, 354, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1078, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1080, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1082, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1084, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1086, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1088, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1090, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1092, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1094, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1096, 356, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1098, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1100, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1102, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1104, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1106, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1108, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1110, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1112, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1114, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1116, 358, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1118, 360, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1120, 360, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1122, 360, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1124, 360, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1126, 360, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1128, 360, 3)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1130, 360, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1132, 360, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1242, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1244, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1246, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1248, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1250, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1252, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1254, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1256, 366, 1)
INSERT [dbo].[tb_sach] ([maquyensach], [madausach], [tinhtrangsach]) VALUES (1258, 366, 1)
SET IDENTITY_INSERT [dbo].[tb_sach] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_tacgia] ON 

INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (200, N'Nguyễn Quang Uy')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (202, N'Nguyễn Quang Uy')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (204, N'Nguyễn Việt Hùng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (206, N'Tạ Minh Thanh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (208, N'Hà Chí Trung')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (210, N'Hy Đức Mạnh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (212, N'Bùi Văn Định')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (214, N'Nguyễn Văn Hồng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (216, N'Phạm Thế Anh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (218, N'Chu Thị Hường')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (220, N'Đỗ Thị Mai Hường')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (222, N'Nguyễn Văn An')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (224, N'Ngô Thành Long')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (226, N'Phạm Tuấn Anh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (228, N'Tô Hiến Thà')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (230, N'Nguyễn Văn Như')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (232, N'Vũ Văn Tuấn')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (234, N'Đặng Quốc Thành')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (236, N'Phạm Thị Bích Vân')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (238, N'Phan Thị Hải Hồng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (240, N'Vũ Anh Mỹ')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (242, N'Nguyễn Quang Uy')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (244, N'Chu Thị Hường')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (246, N'Nguyễn Quang Uy')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (248, N'Nguyễn Việt Hùng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (250, N'Chu Thị Hường')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (252, N'Đỗ Thị Mai Hường')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (254, N'Phạm Thị Bích Vân')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (256, N'Phan Thị Hải Hồng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (258, N'Nguyễn Văn An')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (260, N'Nguyễn Văn Hồng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (262, N'Phạm Thế Anh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (264, N'Vũ Anh Mỹ')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (266, N'Hy Đức Mạnh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (268, N'Bùi Văn Định')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (270, N'Hà Chí Trung')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (272, N'Tạ Minh Thanh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (274, N'Ngô Thành Long')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (276, N'Phạm Tuấn Anh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (278, N'Tô Hiến Thà')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (280, N'Vũ Văn Tuấn')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (282, N'Đặng Quốc Thành')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (284, N'Nguyễn Văn Như')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (286, N'Nguyễn Văn An')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (288, N'Nguyễn Văn Hồng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (290, N'Phạm Thế Anh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (292, N'Vũ Anh Mỹ')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (294, N'Hy Đức Mạnh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (296, N'Bùi Văn Định')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (298, N'Hà Chí Trung')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (300, N'Tạ Minh Thanh')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (302, N'Ngô Thành Long')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (304, N'Đàm Trọng Tùng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (306, N'Đàm Trọng Tùng')
INSERT [dbo].[tb_tacgia] ([matacgia], [tentacgia]) VALUES (308, N'Hoàng Trọng Bình')
SET IDENTITY_INSERT [dbo].[tb_tacgia] OFF
GO
ALTER TABLE [dbo].[tb_bb_nhanlaisach] ADD  DEFAULT (getdate()) FOR [ngaytra]
GO
ALTER TABLE [dbo].[tb_dausach] ADD  DEFAULT ('0') FOR [soluong]
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
ALTER TABLE [dbo].[tb_Acount]  WITH CHECK ADD FOREIGN KEY([manhanvien])
REFERENCES [dbo].[tb_NhanVien] ([manhanvien])
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
/****** Object:  StoredProcedure [dbo].[Delete_DocGia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_DocGia_]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[DKTaiKhoan]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Insert_Acount]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Repair]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_delete1DauSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_Delete1QuyenSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_DELETEBOOKLOSS]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_DocGiaBiPhat]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_insert1quyenSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_insertPhieuBanGiao]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_LietkeTT1DS]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_matsach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_MoKhoaTheDocGia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_PrintPhieuBanGiao]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_PrintPhieuTrasach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_PrintPhieuTrasachtest1]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_sachmuon1DocGia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_searchDauSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_them1QS]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_THONGKE_TS]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_traSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USP_UpdateDauSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USPsearch]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USPsearch_DGMuon]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USPsearch_sach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USPsearch_tenDocGia]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  StoredProcedure [dbo].[USPTanSuatmuoncua1quyenSach]    Script Date: 5/31/2021 7:07:54 PM ******/
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
/****** Object:  Trigger [dbo].[TRC_InsertPhieuBienBanNhanLaiSach]    Script Date: 5/31/2021 7:07:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE trigger [dbo].[TRC_InsertPhieuBienBanNhanLaiSach] on [dbo].[tb_ct_nhanlai] for insert
as
begin
	declare @sach int
	select @sach=maquyensach from inserted 
	declare @maphieubangiao int
	select @maphieubangiao = maphieubangiao from tb_ct_phieubangiao where maquyensach = @sach
	delete tb_ct_phieubangiao from tb_ct_phieubangiao where maquyensach =@sach
	--delete tb_phieubangiaosach from tb_phieubangiaosach where maphieubangiao= @maphieubangiao
	print N'đã xóa phiếu bàn giao khi trả sách'
end
GO
ALTER TABLE [dbo].[tb_ct_nhanlai] ENABLE TRIGGER [TRC_InsertPhieuBienBanNhanLaiSach]
GO
/****** Object:  Trigger [dbo].[TRC_DeleteDauSach]    Script Date: 5/31/2021 7:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TRC_DeleteDauSach] on [dbo].[tb_dausach] for delete 
as
begin 
	declare @idmads int 
	select @idmads = deleted.madausach from deleted

	if(exists(select tb_sach.tinhtrangsach from deleted inner join tb_sach on tb_sach.madausach= deleted.madausach where tb_sach.tinhtrangsach=2)) 
	begin
	print 'ko được xóa'
	rollback Tran -- huy bo phan cap nhat bang
	end
end
GO
ALTER TABLE [dbo].[tb_dausach] ENABLE TRIGGER [TRC_DeleteDauSach]
GO
/****** Object:  Trigger [dbo].[TRC_TanSuatMuon1QS]    Script Date: 5/31/2021 7:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TRC_TanSuatMuon1QS] on [dbo].[tb_dausach] for update,delete
as
begin
DECLARE dausach cursor for select tb_dausach.madausach from dbo.tb_dausach 
OPEN dausach
declare @madausach int
declare @solan1 int
declare @solan2 int
FETCH NEXT FROM dausach INTO @madausach
while @@FETCH_STATUS =0
begin
	select @solan1 = solan from funcTanSuatTuPBG(@madausach)
	select @solan2 = solan from funcTanSuatTuPNL(@madausach)
	update tb_dausach set tansuat = @solan1 +@solan2 where madausach= @madausach
	FETCH NEXT FROM dausach INTO @madausach
	set @solan1 = 0 
	set @solan2 = 0
end 
close dausach 
DEALLOCATE dausach
end
GO
ALTER TABLE [dbo].[tb_dausach] ENABLE TRIGGER [TRC_TanSuatMuon1QS]
GO
/****** Object:  Trigger [dbo].[TRC_InsertPhieuBanGiao]    Script Date: 5/31/2021 7:07:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TRC_InsertPhieuBanGiao] on [dbo].[tb_phieubangiaosach] for insert 
as
begin
   declare @ngay int 
   select @ngay= DATEDIFF(day,inserted.ngaymuon, inserted.ngaydukientra) from inserted

   if(@ngay<=0)
   begin
	print 'ngay muon trả không hợp lí'
    rollback Tran
   end

end
GO
ALTER TABLE [dbo].[tb_phieubangiaosach] ENABLE TRIGGER [TRC_InsertPhieuBanGiao]
GO
USE [master]
GO
ALTER DATABASE [QLTV_Desktop] SET  READ_WRITE 
GO
