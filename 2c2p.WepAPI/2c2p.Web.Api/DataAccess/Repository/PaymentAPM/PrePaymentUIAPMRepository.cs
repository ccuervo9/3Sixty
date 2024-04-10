using DataAccess.Interfaces.PaymentAPM;
using DataAccess.Model.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Payment
{
    public class PrePaymentUIAPMRepository : IPrePaymentUIAPMRepository
    {
        public void Add(PrePaymentUIAPMModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PrePaymentUIAPMModel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(PrePaymentUIAPMModel entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PrePaymentUIAPMModel> IPrePaymentUIAPMRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        PrePaymentUIAPMModel IPrePaymentUIAPMRepository.GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo)
        {
            throw new NotImplementedException();
        }
    }
}
