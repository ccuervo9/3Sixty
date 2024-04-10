
using BussinesLogic.Entities.Payment;
using BussinesLogic.Entities.PaymentAPM;
using System.Collections.Generic;


namespace BussinesLogic.Interfaces.PaymentAPM
{
    public interface IPaymentAPMService 
    {

        IEnumerable<PaymentAPMDTO> GetAllProducts();
        PaymentAPMDTO GetProductByParameters(PaymentAPMDTO payment);
        void AddProduct(PaymentAPMDTO payment);
        void UpdateProduct(PaymentAPMDTO payment);
        void DeleteProduct(int id);
    }

}
