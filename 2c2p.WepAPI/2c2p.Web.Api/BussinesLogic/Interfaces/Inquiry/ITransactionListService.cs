using BussinesLogic.Entities.Inquiry;
using System.Collections.Generic;

namespace BussinesLogic.Interfaces.Inquiry
{
    public interface ITransactionListService
    {
        IEnumerable<TransactionListDTO> GetAllProducts();
        TransactionListDTO GetProductByParameters(TransactionListDTO payment);
        void AddProduct(TransactionListDTO payment);
        void UpdateProduct(TransactionListDTO payment);
        void DeleteProduct(int id);
    }
}
