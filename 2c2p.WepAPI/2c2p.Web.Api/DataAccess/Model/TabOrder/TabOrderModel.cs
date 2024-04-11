using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model.TabOrder
{
    [Table("Tab_OrderHeader")]
    public class TabOrderModel
    {
        public string OH_SifNo { get; set; }
        public Int16 OH_Sector { get; set; }
        public int OH_OrderNo { get; set; }
        public decimal OH_Total { get; set; }
        public bool OH_Voided { get; set; }
        public string OH_CrewSale_CrewId { get; set; }
        public bool OH_Credit { get; set; }
        public Int16 OH_OriginalSector { get; set; }
        public string OH_Seat { get; set; }
        public string OH_Type { get; set; }
        public Int16 OH_DeviceId { get; set; }
        public int OH_DeviceSyncKey { get; set; }
        public string OH_Passport { get; set; }
        public string OH_Service { get; set; }
        public string OH_PaxName { get; set; }
        public string OH_PointCardNo { get; set; }
        public string OH_PointCardHolderName { get; set; }
        public DateTime OH_PointCardExpireDate { get; set; }
        public string OH_PointCardType { get; set; }
        public string OH_PointCardStatus { get; set; }
        public Int32 OH_PointCardPoints { get; set; }
        public Int32 OH_PointCardVoucherPoints { get; set; }
        public string OH_PaxClass { get; set; }
        public string OH_ContactName { get; set; }
        public string OH_ContactPhone { get; set; }
        public string OH_ContactEmail { get; set; }
        public string OH_ContactUnitNumber { get; set; }
        public string OH_ContactAddress { get; set; }
        public string OH_ContactPostCode { get; set; }
        public string OH_Status { get; set; }

    }
}
