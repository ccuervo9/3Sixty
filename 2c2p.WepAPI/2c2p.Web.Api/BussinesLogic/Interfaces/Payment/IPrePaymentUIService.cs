using BussinesLogic.Entities.Payment.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Interfaces.Payment
{
    public interface IPrePaymentUIService
    {
        IEnumerable<PrePaymentUIDTO> GetAllProducts();
        PrePaymentUIDTO GetProductByParameters(PrePaymentUIDTO payment);
        void AddProduct(PrePaymentUIDTO payment);
        void UpdateProduct(PrePaymentUIDTO payment);
        void DeleteProduct(int id);
    }
}
