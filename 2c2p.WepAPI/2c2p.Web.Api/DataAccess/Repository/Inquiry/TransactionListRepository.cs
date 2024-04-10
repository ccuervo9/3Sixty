using DataAccess.Context;
using DataAccess.Interfaces.Inquiry;
using DataAccess.Model.Inquiry;
using DataAccess.Repository.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.Inquiry
{
    public class TransactionListRepository : ITransactionListRepository
    {
        private readonly AppDbContext _context;

        //public TransactionListRepository(AppDbContext context)
        //{
        //    _context = context;
        //}

        public void Add(TransactionListModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TransactionListModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionListModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransactionListModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TransactionListModel entity)
        {
            throw new NotImplementedException();
        }

       
    }

   
}
