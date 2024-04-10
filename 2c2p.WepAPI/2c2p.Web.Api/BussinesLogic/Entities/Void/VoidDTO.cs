using BussinesLogic.Entities.CommonEntitites.Request;
using System.Collections.Generic;


namespace BussinesLogic.Entities.Void
{




    public class VoidDTO
    {
      
    }

    public class VoidAmount
    {
        public string amountText { get; set; }
        public string currencyCode { get; set; }
        public int decimalPlaces { get; set; }
    }

    public class VoidItem
    {
        public string purchaseItemType { get; set; }
    }


}
