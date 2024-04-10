using BussinesLogic.Entities.Authorize;
using BussinesLogic.Interfaces.Authorize;
using DataAccess.Interfaces.Authorize;
using DataAccess.Model.Authorize;
using System;
using System.Collections.Generic;

namespace BussinesLogic.Services.Authorize
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _Repository;

        public UserService(IUserRepository Repository)
        {
            _Repository = Repository;
        }

        public void AddProduct(UserDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetProductByParameters(UserDTO payment)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(UserDTO payment)
        {
            throw new NotImplementedException();
        }
    }
}
