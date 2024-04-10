using AutoMapper;
using DataAccess.Model.Payment;
using System.Collections.Generic;
using BussinesLogic.Entities.CommonEntitites;
using BussinesLogic.Entities.Payment.Request;

namespace BussinesLogic.AutoMapper
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<PaymentModel, PaymentDTO>()
           .ForMember(dest => dest.paymentType, opt => opt.MapFrom(src => src.paymentType))
           .ForMember(dest => dest.creditCardDetails, opt => opt.MapFrom(src => new CreditCardDetails
           {
               cardNumber = src.cardNumber,
               cardExpiryMMYY = null,
               cvvCode = null,
               payerName = null,
               issuerBankCountry = null,
               issuerBankName = null
           }))
           .ForMember(dest => dest.storeCardDetails, opt => opt.MapFrom(src => new StoreCardDetails
           {
               storeCardFlag = src.storeCardFlag.ToString()
           }))
           .ForMember(dest => dest.installmentPaymentDetails, opt => opt.MapFrom(src => new InstallmentPaymentDetails
           {
               ippFlag = src.ippFlag.ToString()
           }))
           .ForMember(dest => dest.recurringPaymentDetails, opt => opt.MapFrom(src => new RecurringPaymentDetails
           {
               rppFlag = src.rppFlag.ToString()
           }))
           .ForMember(dest => dest.transactionAmount, opt => opt.MapFrom(src => new TransactionAmount
           {
               amountText =  src.amountText.ToString(),
               currencyCode = src.currencyCode,
               decimalPlaces = src.decimalPlaces
           }))
           .ForMember(dest => dest.originalTransactionAmount, opt => opt.MapFrom(src => new TransactionAmount()))
           .ForMember(dest => dest.notificationURLs, opt => opt.MapFrom(src => new NotificationURLs
           {
               confirmationURL = src.confirmationURL,
               failedURL = src.failedURL,
               cancellationURL = src.cancellationURL,
               backendURL = src.backendURL
           }))
           .ForMember(dest => dest.generalPayerDetails, opt => opt.MapFrom(src => new GeneralPayerDetails
           {
               personType = src.personType,
               personName = null,
               seqNo = "0"
           }))
           
           .ForMember(dest => dest.officeId, opt => opt.MapFrom(src => src.officeId))
           .ForMember(dest => dest.productDescription, opt => opt.MapFrom(src => src.productDescription.ToString()))
           .ForMember(dest => dest.mcpFlag, opt => opt.MapFrom(src => src.mcpFlag.ToString()))
           ;
        }
    }

}
