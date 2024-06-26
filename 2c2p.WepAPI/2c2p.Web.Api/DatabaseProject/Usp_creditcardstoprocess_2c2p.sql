USE [IRS_BO_AirMacau]
go
/****** Object:  StoredProcedure [dbo].[usp_CreditCardsToProcess]    Script Date: 3/12/2024 9:30:33 AM ******/
SET ansi_nulls ON
go
SET quoted_identifier ON
go

/* =============================================
 Author:  Cristian Cuervo
 alter date:  03/12/2024
 Description:	Description: SP integration for  2c2p.com/reference/pay to get the data to send to external API
				 
 ===================Versioning==========================
 User			Date					Change 
 _______________________________________________________
 c.cuervo		4-11-2024				SP Creation
 _______________________________________________________
 */

CREATE or ALTER PROCEDURE [dbo].[usp_CreditCardstoProcess_2c2p]
(
    @xAirlineCode SMALLINT,
    @xDateFrom DATETIME,
    @xDateTo DATETIME
)
AS
--    exec  [dbo].[Usp_creditcardstoprocess_2c2p] null , null , null

BEGIN

    SET nocount ON;
    SELECT null as requestMessageID,
           getdate() as requestDateTime,
           '00-00 ' officeId,
           cast(PA_HandheldMergeRowId as nvarchar) orderNo,
           oh.OH_OrderNo productDescription,
           oh.OH_PointCardType paymentType,
           pa_cardno cardNumber,
           'N' storeCardFlag,
           'N' ippFlag,
           'N' rppFlag,
           'N' mcpFlag,
           replace(convert(varchar, FORMAT(PL.pa_amount, '0000000000.00')), '.', '') amountText,
           PL.pa_amount,
           PL.pa_currency currencyCode,
           LEN(SUBSTRING(cast(PL.pa_amount as varchar), CHARINDEX('.', PL.pa_amount) + 1, 1000)) decimalPlaces,
           '-' confirmationURL,
           '-' failedURL,
           '-' cancellationURL,
           '-' backendURL,
           'General' personType,
           cast(pl.pa_SifNo as nvarchar) pa_SifNo,
           cast(pl.pa_Sector as nvarchar) pa_Sector,
           cast(pl.pa_OrderNo as nvarchar) pa_OrderNo,
           cast(CTD_ProcessRefNo as nvarchar)  ProcessRefNo,
           cast(CTD_RecordNo as nvarchar) RecordNo,
           cast(oh_SifNo as nvarchar) SifNo,
          cast(oh_Sector as nvarchar) Sector,
          cast(FR_FlightNo as nvarchar) FlightNo,
          cast(PA_LineNo as nvarchar)  PA_LineNo
		  ,CTD_Status , OH_Status , PA_ProcessStatus

    --FR.fr_airlinecode,
    --              FR.fr_sifno,
    --              FR.fr_sector,
    --              FR.fr_flightcode,
    --              FR.fr_flightno,
    --              FR.fr_from,
    --              FR.fr_to,
    --              FR.fr_departuredate,
    --              OH.oh_voided,
    --              PL.pa_orderno,
    --              PL.pa_lineno,
    --              PL.pa_tendertype,
    --              PL.pa_tendersubtype,


    --              PL.pa_amountbase,
    --              Replace(Replace( Replace( Replace( Replace(pa_cardholdername, '!', '' ), '#', '' ), '$', '' ), '&', '' ), '/', '') AS PA_CardHolderName,
    --              pa_cardnobx,
    --              pa_expirydatebx,
    --              '' AS PA_MagTrack2,
    --              PL.pa_processstatus,
    --              PL.pa_handheldmergerowid,
    --              pl.pa_magtrack1
    -- select *  
    FROM tab_flightrecorded FR
        INNER JOIN tab_orderheader OH
            ON FR.fr_sifno = OH.oh_sifno
               AND FR.fr_sector = OH.oh_sector
        left join [Tab_CreditCardTransDetails] cctf
            on cctf.CTD_SifNo = oh.OH_SifNo
               and cctf.CTD_Sector = oh.OH_Sector
               and OH.oh_sector = cctf.CTD_Sector
               AND OH.oh_orderno = cctf.CTD_OrderNumber
        INNER JOIN tab_paymentline PL
            ON OH.oh_sifno = PL.pa_sifno
               AND OH.oh_sector = PL.pa_sector
               AND OH.oh_orderno = PL.pa_orderno
               AND PL.pa_tendertype = 'CC'
               AND OH.oh_voided = 0
               AND fr_sifno NOT LIKE 'ZZZ %'
               AND PL.pa_processstatus = '' --- **
               --And YEAR(FR.FR_DepartureDate)=2023
               --And Month(FR.FR_DepartureDate)in (2,3,4)
               AND FR.fr_departuredate >= '01-JAN-2024'
               AND PL.pa_amountbase >= 0
               AND fr_hide = 0
               AND OH.oh_type = 'S'
END