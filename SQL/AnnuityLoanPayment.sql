USE [BankCrediting]
GO

/****** Object:  UserDefinedFunction [dbo].[AnnuityLoanPayment]    Script Date: 16.06.2020 23:15:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--SELECT POWER(4,2)
CREATE FUNCTION [dbo].[AnnuityLoanPayment] (@credit_amount bigint, @annual_interest_rate float, @month int)
RETURNS float
AS BEGIN
    DECLARE @annuity float;
    DECLARE @annual_interest_rate1 float;
    SET @annual_interest_rate1=1+@annual_interest_rate;
	SET @annuity=@credit_amount*(@annual_interest_rate+(@annual_interest_rate/(POWER(@annual_interest_rate1,@month)-1)));
    RETURN @annuity
END
GO

