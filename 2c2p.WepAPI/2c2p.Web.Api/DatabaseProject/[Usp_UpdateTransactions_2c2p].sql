USE [IRS_BO_AirMacau]
go
/****** Object:  StoredProcedure [dbo].[Usp_UpdateTransactions_2c2p]    Script Date: 3/12/2024 9:30:33 AM ******/
SET ansi_nulls ON
go
SET quoted_identifier ON
go
/* =============================================
 Author:  Cristian Cuervo
 alter date:  03/12/2024
 Description:	SP integration for  2c2p.com/reference/pay to Insert  [[Tab_CreditCardTransDetails]]  and [Tab_PaymentLine]
 ===================Versioning==========================
 User			Date					Change 
 _______________________________________________________
 c.cuervo		4-11-2024				SP Creation
 _______________________________________________________
 */
create or alter procedure [dbo].[Usp_UpdateTransactions_2c2p]
(
    @Status nvarchar(2),
    @ReturnStatus nvarchar(2),
    @RecordNo nvarchar(max),
    @SifNo nvarchar(max),
    @Sector nvarchar(max),
    @FlightNo nvarchar(max),
    @OrderNo nvarchar(max),
    @LineNo nvarchar(max)
)
AS
SET nocount ON;
BEGIN

    declare @PA_SifNo nvarchar(max)

    --- select * 
    --- from [dbo].[Tab_CreditCardTransDetails]
    update [dbo].[Tab_CreditCardTransDetails]
    set CTD_ReturnStatus = @ReturnStatus,
        CTD_Status = @Status,
        CTD_ResponseCode = ' '
    where CTD_RecordNo = @RecordNo
          and CTD_SifNo = @SifNo
          and CTD_Sector = @Sector
          and CTD_FlightNo = @FlightNo

    ---
    --- select * from [dbo].[Tab_PaymentLine]

    update [dbo].[Tab_PaymentLine]
    set PA_ProcessStatus = @Status
    where PA_SifNo = @SifNo
          and PA_Sector = @Sector
          and PA_OrderNo = @OrderNo
          and PA_LineNo = @LineNo


--delete card if it is aprove it 'A'
--ctd_cardNoBx



--select top 6 * from Tab_OrderHeader 
--   SELECT TOP 2 * FROM [IRS_BO_AirMacau].[dbo].[Tab_PaymentLine]
--   select top 2  *   from [dbo].[Tab_CreditCardTransDetails]
--   select  top 2*     from Tab_TransCreditCardTrans

end