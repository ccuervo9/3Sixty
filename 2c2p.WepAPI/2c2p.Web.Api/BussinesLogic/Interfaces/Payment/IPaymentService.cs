
using System.Collections.Generic;
using BussinesLogic.Entities.Payment.Request;
using BussinesLogic.Entities.Payment.Response;


namespace BussinesLogic.Interfaces.Payment
{
    public interface IPaymentService
    {
        IEnumerable<PaymentDTO> GetAllProducts();
        List<PaymentDTO> GetProductByParameters(PaymentDTO payment, string enviroment);
        void AddProduct(PaymentDTO payment);
        bool UpdateStatusTransaction(PaymentResponseDTO payment);
        void DeleteProduct(int id);
    }

}
