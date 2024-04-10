using System.Collections.Generic;
using System;
using DataAccess.Interfaces.Refund;
using BussinesLogic.Interfaces.Refund;
using BussinesLogic.Entities.Refund;

namespace BussinesLogic.Services.Payment
{
    public class RefundService : IRefundService
    {
        private readonly IRefundRepository _Repository;

        public RefundService(IRefundRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(RefundDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RefundDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public RefundDTO GetProductByParameters(RefundDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(RefundDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
