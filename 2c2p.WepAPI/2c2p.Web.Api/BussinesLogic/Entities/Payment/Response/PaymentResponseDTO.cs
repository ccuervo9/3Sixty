using BussinesLogic.Entities.CommonEntitites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BussinesLogic.Entities.Payment.Response
{

    public class PaymentResponseDTO
    {
        public Data data { get; set; }
        public string version { get; set; }
        public ApiResponse apiResponse { get; set; }
    }
    public class ApiResponse
    {
        public string responseMessageId { get; set; }
        public string responseToRequestMessageId { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public DateTime responseDateTime { get; set; }
        public int responseTime { get; set; }
        public string acquirerResponseCode { get; set; }
        public string acquirerResponseDescription { get; set; }
        public string eciValue { get; set; }
        public string marketingDescription { get; set; }
    }

    public class CreditCardAuthenticatedDetails
    {
        public string cardNumber { get; set; }
        public object localScheme { get; set; }
        public string cardExpiryMMYY { get; set; }
        public object issuerCode { get; set; }
        public string payerName { get; set; }
        public string cardHolderName { get; set; }
        public string authenticationStatus { get; set; }
        public object authenticationStatusReason { get; set; }
        public string eciValue { get; set; }
        public object xidValue { get; set; }
        public string issuerBankCountry { get; set; }
    }

    public class Data
    {
        public PaymentResult paymentResult { get; set; }
        public int autoRedirectDelayTimer { get; set; }
    }

    public class PaymentResult
    {
        public object surchargeAmount { get; set; }
        public CreditCardAuthenticatedDetails creditCardAuthenticatedDetails { get; set; }
        public string approvalCode { get; set; }
        public string pspName { get; set; }
        public string pspMerchantId { get; set; }
        public object failedReason { get; set; }
        public PspResponse pspResponse { get; set; }
        public DateTime paymentExpiryDateTime { get; set; }
        public object payslipURL { get; set; }
        public object storedCardUniqueID { get; set; }
        public object installmentPaymentResults { get; set; }
        public object airlineDate { get; set; }
        public DateTime transactionDateTime { get; set; }
        public string orderNo { get; set; }
        public string productDescription { get; set; }
        public string invoiceNo2C2P { get; set; }
        public string pspReferenceNo { get; set; }
        public string controllerInternalID { get; set; }
        public PaymentStatusInfo paymentStatusInfo { get; set; }
        public string paymentType { get; set; }
        public object channelCode { get; set; }
        public object agentCode { get; set; }
        public string mcpFlag { get; set; }
        public TransactionAmountResponse transactionAmount { get; set; }
        public object settlementAmount { get; set; }
        public object customFieldList { get; set; }
        public string clientIp { get; set; }
        public string officeId { get; set; }
        public object ddcId { get; set; }
    }

    public class PaymentStatusInfo
    {
        public string paymentStatus { get; set; }
        public string paymentStep { get; set; }
        public DateTime lastUpdatedDateTime { get; set; }
    }

    public class PspResponse
    {
        public string responseMessageID { get; set; }
        public object responseToRequestMessageID { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
        public DateTime responseDateTime { get; set; }
        public int responseTime { get; set; }
        public string approvalCode { get; set; }
        public string pspReferenceNo { get; set; }
        public object response63 { get; set; }
    }



    public class TransactionAmountResponse
    {
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public int decimalPlaces { get; set; }
        public double amount { get; set; }
    }
}
