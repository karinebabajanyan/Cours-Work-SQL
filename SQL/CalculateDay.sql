USE [BankCrediting]
GO

/****** Object:  StoredProcedure [dbo].[CalculateDay]    Script Date: 16.06.2020 23:14:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CalculateDay] (@credit_id int, @credit_type_id int, @credit_amount bigint, @interest_rate float) 
AS BEGIN 
 DECLARE @start_date datetime; 
 DECLARE @month int; 
 DECLARE @i int;
 DECLARE @next_date datetime; 
 --DECLARE @condition bit; 
 DECLARE @month_next int; 
 DECLARE @day_next int; 
 DECLARE @monthly_all_amount float;
 DECLARE @annual_interest_rate float;
 DECLARE @monthly_mother_amount float;
 DECLARE @monthly_interest_amount float;
 DECLARE @balance_of_mother_amount float;
 SET @annual_interest_rate=@interest_rate/100/12;
 --SET @condition = 1; 
 SET @start_date = (SELECT date_of_issue FROM credits WHERE id = @credit_id); 
 SET @month = (SELECT months FROM types_of_crediting WHERE id = @credit_type_id); 
 SET @i = 0; 
 SET @monthly_all_amount= (SELECT dbo.AnnuityLoanPayment(@credit_amount,@annual_interest_rate,@month));
 SET @monthly_interest_amount=@credit_amount*@annual_interest_rate;
 SET @monthly_mother_amount=@monthly_all_amount-@monthly_interest_amount;
 SET @balance_of_mother_amount=@credit_amount-@monthly_mother_amount;
 WHILE @i<@month 
 BEGIN 
	SET @next_date = (SELECT DATEADD(s,1,DATEADD(mm,1,@start_date))); 
	SET @month_next = (SELECT MONTH(@next_date)); 
	SET @day_next = (SELECT DAY(@next_date)); 
	IF @month_next = 1 
	BEGIN 
		IF @day_next < 8 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,0,DATEADD(dd,7,DATEADD(yy, DATEDIFF(yy, 0, @next_date) + 0, 0)))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date));
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END 
		IF @day_next=28 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END 
	END 
	IF @month_next=3 
	BEGIN 
		IF @day_next=8 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END 
	END 
	IF @month_next=4 
	BEGIN 
		IF @day_next=24 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END 
	END 
	IF @month_next=5 
	BEGIN 
		IF @day_next=1 OR @day_next=9  
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END 
		IF @day_next=28
		BEGIN
			SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date));
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END
	END 
	IF @month_next=7 
	BEGIN 
		IF @day_next=5 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END 
	END 
	IF @month_next=9 
	BEGIN 
		IF @day_next=21 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END 
	END
	IF @month_next=12 
	BEGIN
		IF @day_next=31 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
			IF (SELECT DATEPART(weekday ,@next_date))=6 
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-1,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
			IF (SELECT DATEPART(weekday ,@next_date))=7
			BEGIN
				SET @next_date=(SELECT DATEADD(s,-2,DATEADD(dd,1,@next_date))) 
				SET @month_next = (SELECT MONTH(@next_date)); 
				SET @day_next = (SELECT MONTH(@next_date));
			END
		END
	END
	IF (SELECT DATEPART(weekday,@next_date))= 6 
	BEGIN 
		IF @day_next<=15 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,2,DATEADD(dd,2,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
		END 
		IF @day_next>15 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,-1,DATEDIFF(dd,0,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
		END 
	END 
	IF (SELECT DATEPART(weekday,@next_date))= 7 
	BEGIN 
		IF @day_next<=15 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,1,DATEADD(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
		END 
		IF @day_next>15 
		BEGIN 
			SET @next_date=(SELECT DATEADD(s,-2,DATEDIFF(dd,1,@next_date))) 
			SET @month_next = (SELECT MONTH(@next_date)); 
			SET @day_next = (SELECT MONTH(@next_date)); 
		END 
	END 
	SET @start_date = @next_date ;
	SET @i=@i+1;
	INSERT INTO credit_payment_day (credit_id,payment_day,monthly_mother_amount,monthly_interest_amount,monthly_all_amount,balance_of_mother_amount) VALUES (@credit_id,@next_date,@monthly_mother_amount,@monthly_interest_amount,@monthly_all_amount,@balance_of_mother_amount);
	IF @i!=@month-1
	BEGIN
		SET @monthly_interest_amount=@balance_of_mother_amount*@annual_interest_rate;
		SET @monthly_mother_amount=@monthly_all_amount-@monthly_interest_amount;
		SET @balance_of_mother_amount=@balance_of_mother_amount-@monthly_mother_amount;
	END
	ELSE
	BEGIN
		SET @monthly_interest_amount=@balance_of_mother_amount*@annual_interest_rate;
		SET @monthly_mother_amount=@balance_of_mother_amount;
		SET @monthly_all_amount=@monthly_interest_amount+@monthly_mother_amount;
		SET @balance_of_mother_amount=0;
	END
 END 
END 
GO

