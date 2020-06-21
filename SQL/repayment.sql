USE [BankCrediting]
GO

/****** Object:  Table [dbo].[repayment]    Script Date: 16.06.2020 23:13:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[repayment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[credit_id] [int] NOT NULL,
	[date_of_repayment] [date] NOT NULL,
	[sum_of_repayment] [int] NOT NULL,
	[surcharge] [bigint] NOT NULL,
	[pay_mother_amounth] [bigint] NOT NULL,
	[pay_interest_amounth] [bigint] NOT NULL,
	[paid] [bit] NOT NULL,
	[client_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

