using System.Collections.Generic;
using System;
using BussinesLogic.Interfaces.Payment;
using BussinesLogic.Entities.PaymentAPM;
using DataAccess.Interfaces.PaymentAPM;

namespace BussinesLogic.Services.Payment
{
    public class PrePaymentUIAPMService : IPrePaymentUIAPMService
    {

        private readonly IPrePaymentUIAPMRepository _Repository;

        public PrePaymentUIAPMService(IPrePaymentUIAPMRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(PrePaymentUIAPMDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrePaymentUIAPMDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public PrePaymentUIAPMDTO GetProductByParameters(PrePaymentUIAPMDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(PrePaymentUIAPMDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
