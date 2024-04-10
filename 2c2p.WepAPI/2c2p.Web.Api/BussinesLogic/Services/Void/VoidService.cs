using System.Collections.Generic;
using System;
using BussinesLogic.Interfaces.Void;
using BussinesLogic.Entities.Void;
using DataAccess.Interfaces.Void;


namespace BussinesLogic.Services.Void
{
    public class VoidService : IVoidService
    {

        private readonly IVoidRepository  _Repository;    

        public VoidService(IVoidRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(VoidDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VoidDTO> GetAllProducts()
        {
            var result = _Repository.GetAll();
            throw new NotImplementedException();
        }

        public VoidDTO GetProductByParameters(VoidDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(VoidDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
