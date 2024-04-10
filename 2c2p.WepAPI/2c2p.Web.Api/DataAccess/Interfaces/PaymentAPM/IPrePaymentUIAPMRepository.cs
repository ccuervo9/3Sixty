using DataAccess.Model.Payment;
using System;
using System.Collections.Generic;


namespace DataAccess.Interfaces.PaymentAPM
{
    public interface IPrePaymentUIAPMRepository
    {
        IEnumerable<PrePaymentUIAPMModel> GetAll();
        PrePaymentUIAPMModel GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo);
        void Add(PrePaymentUIAPMModel entity);
        void Update(PrePaymentUIAPMModel entity);
        void Delete(PrePaymentUIAPMModel entity);
    }
}
