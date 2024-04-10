using DataAccess.Model.Refund;
using System;
using System.Collections.Generic;


namespace DataAccess.Interfaces.Refund
{
    public interface IRefundRepository
    {
        IEnumerable<RefundModel> GetAll();
        RefundModel GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo);
        void Add(RefundModel entity);
        void Update(RefundModel entity);
        void Delete(RefundModel entity);
    }

}
