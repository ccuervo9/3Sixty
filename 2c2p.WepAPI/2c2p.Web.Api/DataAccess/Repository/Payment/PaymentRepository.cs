using DataAccess.Context;
using DataAccess.Interfaces.Payment;
using DataAccess.Model.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;


namespace DataAccess.Repository.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext dbContext)
        {
            _context = dbContext;

        }

        public void Add(PaymentModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PaymentModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(string status , string idTransaction, string idRow)
        {
            try
            {
                var parameters = new SqlParameter[]
                     {
                        new SqlParameter("@Status", status ),
                        new SqlParameter("@CodeTransactionID", idTransaction ),
                         new SqlParameter("@RowId", idTransaction )
                     };
                var command = "exec [dbo].[Usp_UpdateTransactions_2c2p]" +
                    "@ReturnStatus ," +
                    "@Status," +
                    "@RowId";

                var result = _context.Payment.FromSqlRaw(command, parameters).ToList();
                return ValidateResult(result);

            }
            catch (Exception ex)
            {                
                return false;
            }
        }

        private static bool ValidateResult(List<PaymentModel> result)
        {
            if (result.Any())
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertTransactionHeader(PaymentModel paymentInfo )
        {

            try
            {
                var parameters = new SqlParameter[]
                     {
                        new SqlParameter("@SifNo", paymentInfo.pa_SifNo != string.Empty ? paymentInfo.pa_SifNo:  DBNull.Value ),
                        new SqlParameter("@Sector", paymentInfo.pa_Sector != string.Empty  ? paymentInfo.pa_Sector:  DBNull.Value ),
                        new SqlParameter("@OrderNo", paymentInfo.pa_OrderNo != string.Empty? paymentInfo.pa_OrderNo:  DBNull.Value ),

                     };
                var command = "exec Usp_InsertTransactions_2c2p " +
                    "@SifNo ," +
                    "@Sector ," +
                    "@OrderNo";

                var result = _context.Database.ExecuteSqlRaw(command, parameters);


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }          

        }

        List<PaymentModel> IPaymentRepository.GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo)
        {
            try
            {
                var parameters = new SqlParameter[]
                     {
                        new SqlParameter("@xAirlineCode", xAirlineCode != 0 ? xAirlineCode:  DBNull.Value ),
                        new SqlParameter("@xDateFrom", xDateFrom != null ? xAirlineCode:  DBNull.Value ),
                        new SqlParameter("@xDateTo", xDateTo != null? xAirlineCode:  DBNull.Value ),

                     };
                var command = "exec Usp_creditcardstoprocess_2c2p " +
                    "@xAirlineCode ," +
                    "@xDateFrom ," +
                    "@xDateTo";

                var result = _context.Payment.FromSqlRaw(command, parameters).ToList();


                return result;
            }
            catch(Exception ex)
            {
                throw ex;           
            }

        }
    }
}
