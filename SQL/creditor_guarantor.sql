USE [BankCrediting]
GO

/****** Object:  Table [dbo].[creditor_guarantor]    Script Date: 16.06.2020 23:12:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[creditor_guarantor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[creditor_id] [int] NOT NULL,
	[guarantor_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

