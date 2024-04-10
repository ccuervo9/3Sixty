using DataAccess.Model.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.Payment
{
    public interface IPrePaymentUIRepository
    {
        IEnumerable<PrePaymentUIModel> GetAll();
        PrePaymentUIModel GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo);
        void Add(PrePaymentUIModel entity);
        void Update(PrePaymentUIModel entity);
        void Delete(PrePaymentUIModel entity);
    }
}
