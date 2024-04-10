using System.Collections.Generic;
using System;
using BussinesLogic.Interfaces.Payment;
using DataAccess.Interfaces.PaymentAPM;
using BussinesLogic.Entities.Payment.Request;

namespace BussinesLogic.Services.Payment
{
    public class PrePaymentUIService : IPrePaymentUIService
    {

        private readonly IPrePaymentUIAPMRepository _Repository;

        public PrePaymentUIService(IPrePaymentUIAPMRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(PrePaymentUIDTO payment)
        {
            
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrePaymentUIDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public PrePaymentUIDTO GetProductByParameters(PrePaymentUIDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(PrePaymentUIDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
