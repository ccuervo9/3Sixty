
using System.Collections.Generic;
using System.Text.Json.Serialization;



namespace BussinesLogic.Entities.Payment.Request
{

    public class ApiRequest
    {
        public string requestMessageID { get; set; }
        public string requestDateTime { get; set; }
    }

    public class CreditCardDetails
    {
        public string cardNumber { get; set; }
        public string cardExpiryMMYY { get; set; }
        public string cvvCode { get; set; }
        public string payerName { get; set; }
        public string issuerBankCountry { get; set; }
        public string issuerBankName { get; set; }
    }

    public class GeneralPayerDetails
    {
        public string personType { get; set; }
        public string personName { get; set; }
        public string seqNo { get; set; }
    }

    public class InstallmentPaymentDetails
    {
        public string ippFlag { get; set; }
    }

    public class NotificationURLs
    {
        public string confirmationURL { get; set; }
        public string failedURL { get; set; }
        public string cancellationURL { get; set; }
        public string backendURL { get; set; }
    }

    public class OriginalTransactionAmount
    {
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public int decimalPlaces { get; set; }
        public decimal amount { get; set; }
    }

    public class PurchaseItemize
    {
        public string purchaseItemType { get; set; }
        public string referenceNo { get; set; }
    }

    public class RecurringPaymentDetails
    {
        public string rppFlag { get; set; }
    }

    public class PaymentDTO
    {
        public ApiRequest apiRequest { get; set; }
        public string paymentType { get; set; }
        public string request3dsFlag { get; set; }  
        public CreditCardDetails creditCardDetails { get; set; }
        public StoreCardDetails storeCardDetails { get; set; }
        public InstallmentPaymentDetails installmentPaymentDetails { get; set; }
        public RecurringPaymentDetails recurringPaymentDetails { get; set; }
        public TransactionAmount transactionAmount { get; set; }
        public OriginalTransactionAmount originalTransactionAmount { get; set; }
        public NotificationURLs notificationURLs { get; set; }
        public GeneralPayerDetails generalPayerDetails { get; set; }
        public string officeId { get; set; }
        public string orderNo { get; set; }
        public string productDescription { get; set; }
        public string mcpFlag { get; set; }
        public List<PurchaseItemize> purchaseItemize { get; set; }

        [JsonIgnore]
        public string pa_Sector { get; set; }

        [JsonIgnore]
        public string pa_SifNo { get; set; }
        [JsonIgnore]
        public string pa_OrderNo { get; set; }

        [JsonIgnore]
         public string RecordNo { get; set; }
        [JsonIgnore]
         public string SifNo { get; set; }
        [JsonIgnore]
         public string Sector { get; set; }
        [JsonIgnore]
         public string FlightNo { get; set; }
        [JsonIgnore]
         public string PA_LineNo { get; set; }





    }

    public class StoreCardDetails
    {
        public string storeCardFlag { get; set; }
    }

    public class TransactionAmount
    {
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public int decimalPlaces { get; set; }
        public decimal amount { get; set; }
    }




}
