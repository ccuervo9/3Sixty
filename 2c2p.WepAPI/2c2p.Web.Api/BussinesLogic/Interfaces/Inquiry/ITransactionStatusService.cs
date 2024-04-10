
using BussinesLogic.Entities.Inquiry;
using BussinesLogic.Entities.Payment;
using System.Collections.Generic;


namespace BussinesLogic.Interfaces.Inquiry
{
    public interface ITransactionStatusService
    {
        IEnumerable<TransactionStatusDTO> GetAllProducts();
        TransactionStatusDTO GetProductByParameters(TransactionStatusDTO payment);
        void AddProduct(TransactionStatusDTO payment);
        void UpdateProduct(TransactionStatusDTO payment);
        void DeleteProduct(int id);
    }

}
