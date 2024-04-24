USE [IRS_BO_AirMacau]
go
/****** Object:  StoredProcedure [dbo].[Usp_InsertTransactions_2c2p]    Script Date: 3/12/2024 9:30:33 AM ******/
SET ansi_nulls ON
go
SET quoted_identifier ON
go
/* =============================================
 Author:  Cristian Cuervo
 alter date:  03/12/2024
 Description:	SP integration for  2c2p.com/reference/pay to Insert  [Tab_CreditCardTransDetails] and [Tab_OrderHeader]
				data 
 ===================Versioning==========================
 User			Date					Change 
 _______________________________________________________
 c.cuervo		4-11-2024				SP Creation
 _______________________________________________________
 */

create or alter procedure [dbo].[Usp_InsertTransactions_2c2p]
(
    @SifNo nvarchar(max),
    @Sector nvarchar(max),
    @OrderNo nvarchar(max)
)

--- exec [dbo].[Usp_InsertTransactions_2c2p] 'MFM 717851' , '1' , '1'

AS
SET nocount ON;
BEGIN


    declare @OH_OrderNo int = 0

    select @OH_OrderNo = max(OH_OrderNo)
    from [dbo].[Tab_OrderHeader]
    where oh_SifNo = @SifNo
          and oh_Sector = @Sector


    INSERT INTO [dbo].[Tab_OrderHeader]
    (
        [OH_SifNo],
        [OH_Sector],
        [OH_OrderNo],
        [OH_Total],
        [OH_Voided],
        [OH_CrewSale_CrewId],
        [OH_OrderTime],
        [OH_Credit],
        [OH_OriginalSector],
        [OH_Seat],
        [OH_Type],
        [OH_DeviceId],
        [OH_DeviceSyncKey],
        [OH_Passport],
        [OH_Service],
        [OH_PaxName],
        [OH_PointCardNo],
        [OH_PointCardHolderName],
        [OH_PointCardExpireDate],
        [OH_PointCardType],
        [OH_PointCardStatus],
        [OH_PointCardPoints],
        [OH_PointCardVoucherPoints],
        [OH_PaxClass],
        [OH_ContactName],
        [OH_ContactPhone],
        [OH_ContactEmail],
        [OH_ContactUnitNumber],
        [OH_ContactAddress],
        [OH_ContactPostCode],
        [OH_Status]
    )
    select pa_SifNo,
           pa_Sector,
           @OH_OrderNo + 1,
           PA_Amount,
           0,
           ' ',
           getdate(),
           0,
           pa_OriginalSector,
           null pa_Seat,
           'S' pa_Type,
           pa_DeviceId,
           pa_DeviceSyncKey,
           null pa_Passport,
           'MA' pa_Service,
           null pa_PaxName,
           null pa_PointCardNo,
           null pa_PointCardHolderName,
           null pa_PointCardExpireDate,
           null pa_PointCardType,
           null pa_PointCardStatus,
           null pa_PointCardPoints,
           null pa_PointCardVoucherPoints,
           null pa_PaxClass,
           null pa_ContactName,
           null pa_ContactPhone,
           null pa_ContactEmail,
           null pa_ContactUnitNumber,
           null pa_ContactAddress,
           null pa_ContactPostCode,
           null pa_Status
    from [dbo].[tab_paymentline]
    where PA_SifNo = @SifNo
          and pa_Sector = @Sector
          and pa_OrderNo = @OrderNo
		    and pa_processstatus = ''

declare @maxRecordNo  int 
select @maxRecordNo = max ([CTD_RecordNo]) from [Tab_CreditCardTransDetails] 

    INSERT INTO [dbo].[Tab_CreditCardTransDetails]
    (
        [CTD_RecordNo],
        [CTD_SifNo],
        [CTD_Sector],
        [CTD_FlightNo],
        [CTD_DeptDate],
        [CTD_FlightFrom],
        [CTD_FlightTo],
        [CTD_OrderNumber],
        [CTD_CardRefNo],
        [CTD_CardHolderName],
        [CTD_CardNo],
        [CTD_CardExpiry],
        [CTD_CardAmount],
        [CTD_ReturnCode],
        [CTD_ResponseCode],
        [CTD_ReturnStatus],
        [CTD_Status],
        [CTD_ProcessRefNo],
        [CTD_TransDate],
        [CTD_TransID],
        [CTD_CardNoBX],
        [CTD_ExpiryDateBX],
        [CTD_RecID],
        [CTD_MaskedCardNo],
        [CTD_CardType],
        [CTD_KeyCode],
        [CTD_ResubReturnStatus],
        [CTD_MagTrack1],
        [CTD_AirlineCode]
    )
    select top 1  
			 @maxRecordNo +1 ,
           pa_SifNo,
           pa_Sector,
           FR_FlightNo,
           getdate() pa_DeptDate,
           FR_From pa_FlightFrom,
           FR_To pa_FlightTo,
           OH_OrderNo pa_OrderNumber,
           0  pa_CardRefNo, -- TO DO 
           PA_CardHolderName pa_CardHolderName,
           pa_CardNo,
           PA_ExpiryDate pa_CardExpiry,
           PA_AmountBase pa_CardAmount,
           '' pa_ReturnCode,
           '' pa_ResponseCode,
           '' pa_ReturnStatus,
           '' pa_Status,
           PA_RefNo pa_ProcessRefNo,
           getdate() pa_TransDate,
           'AUTO' pa_TransID,
           pa_CardNoBX,
           pa_ExpiryDateBX,
           null pa_RecID,
           0 pa_MaskedCardNo, -- TO DO 
           'VI' pa_CardType,
           'RAS_WCF_public_key' pa_KeyCode,
           '' pa_ResubReturnStatus,
           pa_MagTrack1,
           FR_AirlineCode pa_AirlineCode
    FROM tab_flightrecorded FR
        INNER JOIN tab_orderheader OH
            ON FR.fr_sifno = OH.oh_sifno
               AND FR.fr_sector = OH.oh_sector
        INNER JOIN tab_paymentline PL
            ON OH.oh_sifno = PL.pa_sifno
    where PA_SifNo =   @SifNo
          and pa_Sector = @Sector
          and pa_OrderNo = @OrderNo  
		  and    PL.pa_processstatus = ''
		  order by pa_OrderNumber desc 
end
GO
