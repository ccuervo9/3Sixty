USE [IRS_BO_AirMacau]
go
/****** Object:  StoredProcedure [dbo].[Usp_UpdateTransactions_2c2p]    Script Date: 3/12/2024 9:30:33 AM ******/
SET ansi_nulls ON
go
SET quoted_identifier ON
go

create or alter procedure [dbo].[Usp_InsertTransactions_2c2p]
(
    @SifNo nvarchar(max),
   @Sector nvarchar(max),
   @OrderNo nvarchar(max)
 
)
AS
SET nocount ON;
BEGIN
INSERT INTO [dbo].[Tab_OrderHeader]
           ([OH_SifNo]
           ,[OH_Sector]
           ,[OH_OrderNo]
           ,[OH_Total]
           ,[OH_Voided]
           ,[OH_CrewSale_CrewId]
           ,[OH_OrderTime]
           ,[OH_Credit]
           ,[OH_OriginalSector]
           ,[OH_Seat]
           ,[OH_Type]
           ,[OH_DeviceId]
           ,[OH_DeviceSyncKey]
           ,[OH_Passport]
           ,[OH_Service]
           ,[OH_PaxName]
           ,[OH_PointCardNo]
           ,[OH_PointCardHolderName]
           ,[OH_PointCardExpireDate]
           ,[OH_PointCardType]
           ,[OH_PointCardStatus]
           ,[OH_PointCardPoints]
           ,[OH_PointCardVoucherPoints]
           ,[OH_PaxClass]
           ,[OH_ContactName]
           ,[OH_ContactPhone]
           ,[OH_ContactEmail]
           ,[OH_ContactUnitNumber]
           ,[OH_ContactAddress]
           ,[OH_ContactPostCode]
           ,[OH_Status])
     
     select 
		   pa_SifNo, 
          pa_Sector, 
          pa_OrderNo,
          PA_Amount, 
          0, 
          null, 
          getdate(),
          0, 
          pa_OriginalSector,
         null pa_Seat, 
          null pa_Type, 
          pa_DeviceId, 
          pa_DeviceSyncKey,
          null pa_Passport, 
          null pa_Service, 
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
			where PA_SifNo = @SifNo and  
			pa_Sector =@Sector and  
			pa_OrderNo =@OrderNo


		   
end
GO


-- select top 100 * from [dbo].[Tab_OrderHeader] where OH_SifNo = 'MFM 700119' order by  OH_SifNo 
-- select * from [dbo].[tab_paymentline] where pa_SifNo = 'MFM 700119'
   
