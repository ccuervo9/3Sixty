using BussinesLogic.Entities.CommonEntitites.Request;
using BussinesLogic.Entities.Void;
using System;
using System.Collections.Generic;


namespace BussinesLogic.Entities.Refund
{


    public class Checker
    {
        public string username { get; set; }
    }

    public class LocalMakerChecker
    {
        public Maker maker { get; set; }
        public Checker checker { get; set; }
    }

    public class Maker
    {
        public string username { get; set; }
        public string email { get; set; }
    }

    public class PspMakerChecker
    {
        public Maker maker { get; set; }
    }

    public class RefundAmount
    {
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public int decimalPlaces { get; set; }
    }

    public class RefundItem
    {
        public string purchaseItemType { get; set; }
    }

    public class RefundNotificationURLs
    {
        public string confirmationURL { get; set; }
        public string failedURL { get; set; }
        public string cancellationURL { get; set; }
        public string backendURL { get; set; }
    }

    public class RefundToBankAccount
    {
        public string bankCode { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
    }

    public class RefundDTO
    {
       
    }  


}
