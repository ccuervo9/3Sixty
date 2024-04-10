
using BussinesLogic.Entities.Refund;
using System.Collections.Generic;


namespace BussinesLogic.Interfaces.Refund
{
    public interface IRefundService
    {
        IEnumerable<RefundDTO> GetAllProducts();
        RefundDTO GetProductByParameters(RefundDTO payment);
        void AddProduct(RefundDTO payment);
        void UpdateProduct(RefundDTO payment);
        void DeleteProduct(int id);
    }

}
