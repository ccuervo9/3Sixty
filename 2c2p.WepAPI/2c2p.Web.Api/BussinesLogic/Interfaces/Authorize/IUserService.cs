using BussinesLogic.Entities.Authorize;
using BussinesLogic.Entities.Payment;
using System.Collections.Generic;

namespace BussinesLogic.Interfaces.Authorize
{
    public interface IUserService 
    {
        IEnumerable<UserDTO> GetAllProducts();
        UserDTO GetProductByParameters(UserDTO payment);
        void AddProduct(UserDTO payment);
        void UpdateProduct(UserDTO payment);
        void DeleteProduct(int id);
    }
}
