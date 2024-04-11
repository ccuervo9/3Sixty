USE [IRS_BO_AirMacau]
go
/****** Object:  StoredProcedure [dbo].[Usp_UpdateTransactions_2c2p]    Script Date: 3/12/2024 9:30:33 AM ******/
SET ansi_nulls ON
go
SET quoted_identifier ON
go

create or alter procedure [dbo].[Usp_UpdateTransactions_2c2p]
(
    @ReturnStatus nvarchar(2),
    @Status nvarchar(2),
    @RowId nvarchar(max),
	@CTD_ResponseCode nvarchar(10) 
)
AS
SET nocount ON;
BEGIN

    declare @PA_SifNo nvarchar(max)

    SELECT top 1
        @PA_SifNo = PA_SifNo
    FROM [IRS_BO_AirMacau].[dbo].[tab_paymentline]
    where  PA_HandheldMergeRowId= @RowId 
	--PA_ProcessStatus 

    update [dbo].[Tab_CreditCardTransDetails]
    set CTD_ReturnStatus = @ReturnStatus,
        CTD_Status = @Status,
		CTD_ResponseCode =@CTD_ResponseCode 

		where CTD_ProcessRefNo = @RowId


	update [dbo].[Tab_PaymentLine]
	set PA_ProcessStatus = @Status
	where 
	PA_SifNo = @PA_SifNo and
	 PA_HandheldMergeRowId= @RowId 
 

 --delete card if it is aprove it 'A'
 --ctd_cardNoBx



	--select top 6 * from Tab_OrderHeader 
 --   SELECT TOP 2 * FROM [IRS_BO_AirMacau].[dbo].[Tab_PaymentLine]
 --   select top 2  *   from [dbo].[Tab_CreditCardTransDetails]
 --   select  top 2*     from Tab_TransCreditCardTrans
		   
end