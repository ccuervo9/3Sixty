﻿
using System.Collections.Generic;
using BussinesLogic.Entities.Payment.Request;
using BussinesLogic.Entities.Payment.Response;
using DataAccess.Model.Payment;


namespace BussinesLogic.Interfaces.Payment
{
    public interface IPaymentService
    {
        IEnumerable<PaymentDTO> GetAllProducts();
        List<PaymentDTO> GetProductByParameters(PaymentDTO payment, string enviroment);
        void AddProduct(PaymentDTO payment);
        public bool UpdateStatusTransaction(PaymentResponseDTO paymentResponseDTO, PaymentDTO paymentDto);
        void DeleteProduct(int id);
        public bool InsertTransactionHeader(PaymentDTO paymentInfo);
    }

}
