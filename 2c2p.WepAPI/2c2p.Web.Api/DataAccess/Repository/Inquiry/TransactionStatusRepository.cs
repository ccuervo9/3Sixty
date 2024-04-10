
using DataAccess.Context;
using DataAccess.Interfaces.Inquiry;
using DataAccess.Model.Inquiry;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Repository.Inquiry
{
    public class TransactionStatusRepository : ITransactionStatusRepository
    {
        private readonly AppDbContext _context;

        //public TransactionStatusRepository(AppDbContext context)
        //{
        //    _context = context;
        //}

        public IEnumerable<TransactionStatusModel > GetAll()
        {
            return _context.Set<TransactionStatusModel>().ToList();
        }

        public TransactionStatusModel GetById(int id)
        {
            return _context.Set<TransactionStatusModel>().Find(id);
        }

        public void Add(TransactionStatusModel entity)
        {
            _context.Set<TransactionStatusModel>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TransactionStatusModel entity)
        {
            _context.Set<TransactionStatusModel>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TransactionStatusModel entity)
        {
            _context.Set<TransactionStatusModel>().Remove(entity);
            _context.SaveChanges();
        }     
    }

}
