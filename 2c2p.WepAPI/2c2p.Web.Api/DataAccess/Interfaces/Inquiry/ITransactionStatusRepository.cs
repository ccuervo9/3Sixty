
using DataAccess.Model.Inquiry;
using System.Collections.Generic;


namespace DataAccess.Interfaces.Inquiry
{
    public interface ITransactionStatusRepository
    {
        IEnumerable<TransactionStatusModel> GetAll();
        TransactionStatusModel GetById(int id);
        void Add(TransactionStatusModel entity);
        void Update(TransactionStatusModel entity);
        void Delete(TransactionStatusModel entity);
    }

}
