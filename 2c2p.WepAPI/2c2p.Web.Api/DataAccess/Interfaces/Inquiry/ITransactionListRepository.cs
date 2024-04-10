using DataAccess.Model.Inquiry;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.Inquiry
{
    public interface ITransactionListRepository
    {
        IEnumerable<TransactionListModel> GetAll();
        TransactionListModel GetById(int id);
        void Add(TransactionListModel entity);
        void Update(TransactionListModel entity);
        void Delete(TransactionListModel entity);
    }
}
