using System.Collections.Generic;
using System;
using BussinesLogic.Interfaces.PaymentAPM;
using BussinesLogic.Entities.PaymentAPM;
using DataAccess.Interfaces.PaymentAPM;

namespace BussinesLogic.Services.PaymentAPM
{
    public class PaymentAPMService : IPaymentAPMService
    {
        private readonly IPaymentAPMRepository _Repository;

        public PaymentAPMService(IPaymentAPMRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(PaymentAPMDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentAPMDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public PaymentAPMDTO GetProductByParameters(PaymentAPMDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(PaymentAPMDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
