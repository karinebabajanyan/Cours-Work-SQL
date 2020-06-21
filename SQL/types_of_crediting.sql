USE [BankCrediting]
GO

/****** Object:  Table [dbo].[types_of_crediting]    Script Date: 16.06.2020 23:14:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[types_of_crediting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[terms_of_receipt] [text] NOT NULL,
	[interest_rate] [float] NOT NULL,
	[months] [int] NOT NULL,
	[minimum_amount] [bigint] NULL,
	[maximum_amount] [bigint] NULL,
	[unic_name] [varchar](255) NOT NULL,
	[percentage_of_fines_for_each_day_mother_amount] [float] NOT NULL,
	[percentage_of_fines_for_each_day_interest_amount] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

