using DataAccess.Model.PaymentAPM;
using System;
using System.Collections.Generic;


namespace DataAccess.Interfaces.PaymentAPM
{
    public interface IPaymentAPMRepository
    {
        IEnumerable<PaymentAPMModel> GetAll();
        PaymentAPMModel GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo);
        void Add(PaymentAPMModel entity);
        void Update(PaymentAPMModel entity);
        void Delete(PaymentAPMModel entity);
    }

}
