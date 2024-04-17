
using System;
using System.Collections.Generic;
using DataAccess.Model.Payment;


namespace DataAccess.Interfaces.Payment
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentModel> GetAll();
        List<PaymentModel> GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo);
        void Add(PaymentModel entity);
        public bool Update(string status,
            string returnStatus,
            string RecordNo,
            string SifNo,
            string Sector,
            string FlightNo,
            string OrderNo,
            string LineNo);
        void Delete(PaymentModel entity);
        public bool InsertTransactionHeader(PaymentModel paymentInfo);
    }

}
