USE [BankCrediting]
GO

/****** Object:  Table [dbo].[credit_payment_day]    Script Date: 16.06.2020 23:12:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[credit_payment_day](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[credit_id] [int] NOT NULL,
	[payment_day] [datetime] NOT NULL,
	[monthly_mother_amount] [float] NOT NULL,
	[monthly_interest_amount] [float] NOT NULL,
	[monthly_all_amount] [float] NOT NULL,
	[balance_of_mother_amount] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

