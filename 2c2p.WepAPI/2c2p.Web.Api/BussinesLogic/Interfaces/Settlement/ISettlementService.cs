
using BussinesLogic.Entities.Payment;
using BussinesLogic.Entities.Settlement;
using System.Collections.Generic;


namespace BussinesLogic.Interfaces.Settlement
{
    public interface ISettlementService
    {
        IEnumerable<SettlementDTO> GetAllProducts();
        SettlementDTO GetProductByParameters(SettlementDTO payment);
        void AddProduct(SettlementDTO payment);
        void UpdateProduct(SettlementDTO payment);
        void DeleteProduct(int id);
    }

}
