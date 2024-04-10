using DataAccess.Model.Void;
using System;
using System.Collections.Generic;


namespace DataAccess.Interfaces.Void
{
    public interface IVoidRepository
    {
        IEnumerable<VoidModel> GetAll();
        VoidModel GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo);
        void Add(VoidModel entity);
        void Update(VoidModel entity);
        void Delete(VoidModel entity);
    }

}
