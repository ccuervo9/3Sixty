
using BussinesLogic.Entities.Payment;
using BussinesLogic.Entities.Void;
using System.Collections.Generic;


namespace BussinesLogic.Interfaces.Void
{
    public interface IVoidService
    {
        IEnumerable<VoidDTO> GetAllProducts();
        VoidDTO GetProductByParameters(VoidDTO payment);
        void AddProduct(VoidDTO payment);
        void UpdateProduct(VoidDTO payment);
        void DeleteProduct(int id);
    }

}
