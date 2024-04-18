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

        public bool Update(string status,
            string returnStatus,
            string RecordNo,
            string SifNo,
            string Sector,
            string FlightNo,
            string OrderNo,
            string LineNo)
        {
            try
            {
                var parameters = new SqlParameter[]
                     {
                        new SqlParameter("@Status"          ,status),
                        new SqlParameter("@ReturnStatus"    ,returnStatus  != string.Empty ? returnStatus:  DBNull.Value),
                        new SqlParameter("@RecordNo"        ,RecordNo != string.Empty ? returnStatus:  DBNull.Value),
                        new SqlParameter("@SifNo"           ,SifNo),
                        new SqlParameter("@Sector"          ,Sector),
                        new SqlParameter("@FlightNo"        ,FlightNo),
                        new SqlParameter("@OrderNo"         ,OrderNo),
                        new SqlParameter("@LineNo"          ,LineNo),
                     };
                var command = "exec [dbo].[Usp_UpdateTransactions_2c2p] " +
                    " @Status," +
                    " @ReturnStatus," +
                    " @RecordNo," +
                    " @SifNo," +
                    " @Sector," +
                    " @FlightNo," +
                    " @OrderNo," +
                    " @LineNo";

                var result = _context.Payment.FromSqlRaw(command, parameters).ToList();
                return ValidateResult(result);

            }
            catch (Exception)
            {
                return false;   
                throw;
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

        public bool InsertTransactionHeader(PaymentModel paymentInfo)
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
            catch (Exception)
            {
                throw;
            }

        }

        List<PaymentModel> IPaymentRepository.GetById(int xAirlineCode, DateTime xDateFrom, DateTime xDateTo)
        {
            try
            {
                var parameters = new SqlParameter[]
                     {
                        new SqlParameter("@xAirlineCode", xAirlineCode != 0 ? xAirlineCode:  DBNull.Value ),
                        new SqlParameter("@xDateFrom", xDateFrom.ToString() != null ? xAirlineCode:  DBNull.Value ),
                        new SqlParameter("@xDateTo", xDateTo.ToString() != null? xAirlineCode:  DBNull.Value ),

                     };
                var command = "exec Usp_creditcardstoprocess_2c2p " +
                    "@xAirlineCode ," +
                    "@xDateFrom ," +
                    "@xDateTo";

                var result = _context.Payment.FromSqlRaw(command, parameters).ToList();


                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
