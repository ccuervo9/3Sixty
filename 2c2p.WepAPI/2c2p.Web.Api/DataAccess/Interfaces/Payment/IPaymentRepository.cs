
using System;
using System.Collections.Generic;
using DataAccess.Model.Payment;


namespace DataAccess.Interfaces.Payment
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentModel> GetAll();
        List<PaymentModel> GetById(int xAirlineCode , DateTime xDateFrom, DateTime xDateTo);
        void Add(PaymentModel entity);
        public bool Update(string status, string idTransaction , string idRow);
        void Delete(PaymentModel entity);
    }

}
