
using DataAccess.Model.Refund;
using DataAccess.Model.Settlement;
using System;
using System.Collections.Generic;


namespace DataAccess.Interfaces.Settlement
{
    public interface ISettlementRepository
    {
        IEnumerable<SettlementModel> GetAll();
        SettlementModel GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo);
        void Add(SettlementModel entity);
        void Update(SettlementModel entity);
        void Delete(SettlementModel entity);
    }

}
