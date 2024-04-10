using DataAccess.Context;
using DataAccess.Interfaces.Payment;
using DataAccess.Model.Payment;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Repository.Payment
{
    public class PrePaymentUIRepository : IPrePaymentUIRepository
    {
        private readonly AppDbContext _context;

        public void Add(PrePaymentUIModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PrePaymentUIModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PrePaymentUIModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PrePaymentUIModel GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo)
        {
            throw new NotImplementedException();
        }

        public void Update(PrePaymentUIModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
