USE [IRS_BO_AirMacau]
go
/****** Object:  StoredProcedure [dbo].[usp_CreditCardsToProcess]    Script Date: 3/12/2024 9:30:33 AM ******/
SET ansi_nulls ON
go
SET quoted_identifier ON
go
-- =============================================
-- Author:  Cristian Cuervo
-- alter date:  03/12/2024
-- Description: SP integration for  2c2p.com/reference/pay
-- =============================================
CREATE or ALTER PROCEDURE [dbo].[Usp_creditcardstoprocess_2c2p] ( @xAirlineCode SMALLINT,
@xDateFrom                                                            DATETIME,
@xDateTo                                                              DATETIME )
AS
  BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET nocount ON;
    SELECT     
	--apirequest
	'GUID e98900-0090990-9000' as requestMessageID,
	getdate() as requestDateTime,
	'00-00 'officeId ,  --  ??? 
	oh.OH_OrderNo orderNo,
	'productDescription' productDescription , -- ??? 
	oh.OH_PointCardType paymentType ,
	 pa_cardno  cardNumber ,  
	 1  storeCardFlag , 
	 1  ippFlag ,  -- Y or N. Indicate whether the transaction is Insallment Payment Plan (IPP) or not. ippFlag and rppFlag is mutually exclusive and cannot activated at the same time.   
	 1 rppFlag  ,   --- Y or N. Indicate whether the transaction is Recurring Payment Plan (RPP) or not. ippFlag and rppFlag is mutually exclusive and cannot activated at the same time.
	1 mcpFlag ,  -- ??? 
	PL.pa_amount amountText , 
			     PL.pa_currency currencyCode  , 

		LEN(SUBSTRING(cast( PL.pa_amount as varchar), CHARINDEX('.', PL.pa_amount ) + 1, 1000)) decimalPlaces, 
	'configTableUrl'confirmationURL	  ,
	'configTableUrl' failedURL		  ,
	'configTableUrl' cancellationURL  ,
	'configTableUrl' backendURL		  ,
	'passenger/guesst' personType , 
	0, 
	FR.fr_airlinecode,
               FR.fr_sifno,
               FR.fr_sector,
               FR.fr_flightcode,
               FR.fr_flightno,
               FR.fr_from,
               FR.fr_to,
               FR.fr_departuredate,
               OH.oh_voided,
               PL.pa_orderno,
               PL.pa_lineno,
               PL.pa_tendertype,
               PL.pa_tendersubtype,
            
     
               PL.pa_amountbase,
               Replace(Replace( Replace( Replace( Replace(pa_cardholdername, '!', '' ), '#', '' ), '$', '' ), '&', '' ), '/', '') AS PA_CardHolderName,
               pa_cardnobx,
               pa_expirydatebx,
               '' AS PA_MagTrack2,
               PL.pa_processstatus,
               PL.pa_handheldmergerowid,
               pl.pa_magtrack1
         
    FROM       tab_flightrecorded FR
    INNER JOIN tab_orderheader OH
    ON         FR.fr_sifno = OH.oh_sifno
    AND        FR.fr_sector = OH.oh_sector
	--inner join Tab_SetupProductDescription 
    INNER JOIN tab_paymentline PL
    ON         OH.oh_sifno = PL.pa_sifno
    AND        OH.oh_sector = PL.pa_sector
    AND        OH.oh_orderno = PL.pa_orderno
    AND        PL.pa_tendertype = 'CC'
    AND        OH.oh_voided=0
    AND        fr_sifno NOT LIKE 'ZZZ %'
    AND        PL.pa_processstatus=''
               --And YEAR(FR.FR_DepartureDate)=2023
               ----And Month(FR.FR_DepartureDate)in (2,3,4)
    AND        FR.fr_departuredate>='01-JAN-2023'
    AND        [fr_airlinecode]=@xAirlineCode
    AND        PL.pa_amountbase>=0
    AND        fr_hide=0
    AND        OH.oh_type ='S'
  END