using BussinesLogic.Entities.Payment;
using BussinesLogic.Entities.PaymentAPM;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Interfaces.Payment
{
    public interface IPrePaymentUIAPMService
    {
        IEnumerable<PrePaymentUIAPMDTO> GetAllProducts();
        PrePaymentUIAPMDTO GetProductByParameters(PrePaymentUIAPMDTO payment);
        void AddProduct(PrePaymentUIAPMDTO payment);
        void UpdateProduct(PrePaymentUIAPMDTO payment);
        void DeleteProduct(int id);
    }
}
