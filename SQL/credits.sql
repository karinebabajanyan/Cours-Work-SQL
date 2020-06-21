USE [BankCrediting]
GO

/****** Object:  Table [dbo].[credits]    Script Date: 16.06.2020 23:13:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[credits](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[client_id] [int] NOT NULL,
	[date_of_issue] [datetime] NOT NULL,
	[fully_repaid] [bit] NOT NULL,
	[credit_type_id] [int] NOT NULL,
	[mother_amount] [bigint] NOT NULL,
	[account] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

