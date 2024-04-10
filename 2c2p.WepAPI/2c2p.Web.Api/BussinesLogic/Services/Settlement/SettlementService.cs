using System.Collections.Generic;
using System;
using BussinesLogic.Interfaces.Settlement;
using BussinesLogic.Entities.Settlement;
using DataAccess.Interfaces.Settlement;

namespace BussinesLogic.Services.Payment
{
    public class SettlementService : ISettlementService
    {

        private readonly ISettlementRepository _Repository;

        public SettlementService(ISettlementRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(SettlementDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettlementDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public SettlementDTO GetProductByParameters(SettlementDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(SettlementDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
