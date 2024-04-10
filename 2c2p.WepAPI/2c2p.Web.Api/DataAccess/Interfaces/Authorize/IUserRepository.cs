using DataAccess.Model.Authorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces.Authorize
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        void Add(UserModel entity);
        void Update(UserModel entity);
        void Delete(UserModel entity);
    }
}
