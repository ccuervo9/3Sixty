using System.Collections.Generic;
using System;
using BussinesLogic.Interfaces.Inquiry;
using BussinesLogic.Entities.Inquiry;
using DataAccess.Interfaces.Inquiry;

namespace BussinesLogic.Services.Payment
{
    public class TransactionStatusService : ITransactionStatusService
    { 
        private readonly ITransactionStatusRepository _Repository;

        public TransactionStatusService(ITransactionStatusRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(TransactionStatusDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionStatusDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public TransactionStatusDTO GetProductByParameters(TransactionStatusDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(TransactionStatusDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
