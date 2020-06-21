USE [BankCrediting]
GO

/****** Object:  Table [dbo].[customers]    Script Date: 16.06.2020 23:13:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[type_of_property] [varchar](255) NULL,
	[costumer_address] [varchar](255) NOT NULL,
	[phone] [varchar](255) NOT NULL,
	[passport_series] [varchar](255) NOT NULL,
	[social_card_number] [varchar](255) NOT NULL,
	[workplace] [varchar](255) NULL,
	[is_guarantor] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

