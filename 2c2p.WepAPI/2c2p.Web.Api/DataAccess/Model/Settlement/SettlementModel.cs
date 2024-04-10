
using System;
using System.Collections.Generic;


namespace DataAccess.Model.Settlement
{
    public class SettlementModel
    {
        public string requestMessageID { get; set; }
        public DateTime requestDateTime { get; set; }
        public string officeId { get; set; }
        public string orderNo { get; set; }

        public string paymentType { get; set; }
        public string cardNumber { get; set; }
        public bool storeCardFlag { get; set; }
        public bool ippFlag { get; set; }
        public bool rppFlag { get; set; }
        public bool mcpFlag { get; set; }
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public string decimalPlaces { get; set; }
        public string confirmationURL { get; set; }
        public string failedURL { get; set; }
        public string cancellationURL { get; set; }
        public string backendURL { get; set; }
        public string personType { get; set; }
        public string fr_airlinecode { get; set; }
        public string fr_sifno { get; set; }
        public string fr_sector { get; set; }
        public string fr_flightcode { get; set; }
        public string fr_flightno { get; set; }
        public string fr_from { get; set; }
        public string fr_to { get; set; }
        public string fr_departuredate { get; set; }
        public string oh_voided { get; set; }
        public string pa_orderno { get; set; }
        public string pa_lineno { get; set; }
        public string pa_tendertype { get; set; }
        public string pa_tendersubtype { get; set; }
        public string pa_amountbase { get; set; }
        public string PA_CardHolderName { get; set; }
        public string pa_cardnobx { get; set; }
        public string pa_expirydatebx { get; set; }
        public string PA_MagTrack2 { get; set; }
        public string pa_processstatus { get; set; }
        public string pa_handheldmergerowid { get; set; }
        public string pa_magtrack1 { get; set; }
    }

}
