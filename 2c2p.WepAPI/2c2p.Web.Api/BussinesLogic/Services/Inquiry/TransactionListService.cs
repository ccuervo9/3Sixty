using System.Collections.Generic;
using System;


using BussinesLogic.Interfaces.Inquiry;
using BussinesLogic.Entities.Inquiry;
using DataAccess.Interfaces.Inquiry;

namespace BussinesLogic.Services.Payment
{
    public class TransactionListService : ITransactionListService
    {
        private readonly ITransactionListRepository _Repository;

        public TransactionListService(ITransactionListRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(TransactionListDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionListDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public TransactionListDTO GetProductByParameters(TransactionListDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(TransactionListDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
