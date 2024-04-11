
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Model.Payment
{
    public class PaymentModel
    {

        public string requestMessageID { get; set; }
        public DateTime requestDateTime { get; set; }
        public string officeId { get; set; }
        public string orderNo { get; set; }
        public Int16 productDescription { get; set; }
        public string paymentType { get; set; }
        public string cardNumber { get; set; }
        public string storeCardFlag { get; set; }
        public string ippFlag { get; set; }
        public string rppFlag { get; set; }
        public string mcpFlag { get; set; }
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public decimal pa_amount { get; set; }
        public int decimalPlaces { get; set; }
        public string confirmationURL { get; set; }
        public string failedURL { get; set; }
        public string cancellationURL { get; set; }
        public string backendURL { get; set; }
        public string personType { get; set; }
        public string pa_SifNo { get; set; }
        public string pa_Sector { get; set; }
        public string pa_OrderNo { get; set; }

    }
}
