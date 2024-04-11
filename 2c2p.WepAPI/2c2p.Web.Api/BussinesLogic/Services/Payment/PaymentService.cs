using DataAccess.Interfaces.Payment;
using System.Collections.Generic;
using System;
using BussinesLogic.Interfaces.Payment;
using DataAccess.Model.Payment;
using AutoMapper;
using BussinesLogic.Entities.Payment.Request;
using BussinesLogic.Entities.Payment.Response;
using BussinesLogic.Helpers;



namespace BussinesLogic.Services.Payment
{
    public class PaymentService : IPaymentService
    {

        private readonly IMapper _mapper;
        private readonly IPaymentRepository _Repository;

        public PaymentService(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _Repository = paymentRepository;
        }

        public void AddProduct(PaymentDTO payment)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentDTO> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get transaction to send to external API
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="enviroment">dev enviroment to test hardcode data </param>
        /// <returns>List<PaymentDTO></returns>
        public List<PaymentDTO> GetProductByParameters(PaymentDTO payment, string enviroment)
        {
            try
            {
                Random rnd = new Random();
                // Test data
                if (enviroment == "dev")
                {
                    var paymentDTOList = new List<PaymentDTO>();
                    List<PaymentModel> resultModel = _Repository.GetById(2, DateTime.Now, DateTime.Now);

                    foreach (var item in resultModel)
                    {
                        var paymentDTO = new PaymentDTO
                        {
                            pa_SifNo = item.pa_SifNo,
                            pa_Sector = item.pa_Sector.ToString(),
                            pa_OrderNo = item.pa_OrderNo.ToString(),    
                            officeId = "3SIXTY_TH",
                            orderNo = item.orderNo.ToString(),
                            productDescription = item.productDescription.ToString(),
                            paymentType = "CC",
                            request3dsFlag = "N",
                            mcpFlag = item.mcpFlag.ToString(),
                            apiRequest = new ApiRequest
                            {
                                requestDateTime = DateTime.Now.ToString(),
                                requestMessageID = Guid.NewGuid().ToString(),
                            },
                            creditCardDetails = new CreditCardDetails
                            {
                                cardNumber = "4111111111111111",
                                cardExpiryMMYY = "1224",
                                cvvCode = "123",
                                payerName = null,
                                issuerBankCountry = null, // Example value
                                issuerBankName = null// Example value
                            },

                            storeCardDetails = new StoreCardDetails
                            {
                                storeCardFlag = item.storeCardFlag.ToString(),
                            },

                            installmentPaymentDetails = new InstallmentPaymentDetails
                            {
                                ippFlag = item.ippFlag.ToString() // Example value
                            },

                            recurringPaymentDetails = new RecurringPaymentDetails
                            {
                                rppFlag = item.rppFlag.ToString() // Example value
                            },

                            transactionAmount = new TransactionAmount
                            {
                                amountText = item.amountText.ToString(),
                                currencyCode = item.currencyCode, // Example value
                                decimalPlaces = item.decimalPlaces,
                                amount = item.pa_amount,
                            },
                            originalTransactionAmount = new OriginalTransactionAmount
                            {
                                amountText = item.amountText.ToString(),
                                currencyCode = item.currencyCode, // Example value
                                decimalPlaces = item.decimalPlaces,
                                amount = item.pa_amount,
                               
                            },

                            notificationURLs = new NotificationURLs
                            {
                                confirmationURL = "-", // Example value
                                failedURL = "-", // Example value
                                cancellationURL = "-", // Example value
                                backendURL = "-" // Example value
                            },
                            generalPayerDetails = new GeneralPayerDetails
                            {
                                personType = item.personType, // Example value
                                personName = "",
                                seqNo = "1" // Example value
                            },
                            purchaseItemize = new List<PurchaseItemize>
                            {
                                new PurchaseItemize
                                {
                                    purchaseItemType = null, // Example value
                                    referenceNo =  rnd.Next().ToString(),
                                }
                            }
                        };
                        paymentDTOList.Add(paymentDTO);

                    };

                    return paymentDTOList;

                }
                else
                {

                    //payment from DB 
                    var paymentDTOList = new List<PaymentDTO>();
                    List<PaymentModel> resultModel = _Repository.GetById(2, DateTime.Now, DateTime.Now);

                    foreach (var item in resultModel)
                    {

                        var paymentDTO = new PaymentDTO
                        {
                            pa_SifNo = item.pa_SifNo,
                            pa_Sector = item.pa_Sector.ToString(),
                            pa_OrderNo = item.pa_OrderNo.ToString(),
                            officeId = item.officeId,
                            orderNo = item.orderNo.ToString(),
                            productDescription = item.productDescription.ToString(),
                            paymentType = item.paymentType,
                            mcpFlag = item.mcpFlag.ToString(),
                            apiRequest = new ApiRequest
                            {
                                requestDateTime = DateTime.Now.ToString(),
                                requestMessageID = Guid.NewGuid().ToString(),
                            },
                            creditCardDetails = new CreditCardDetails
                            {
                                cardNumber = item.cardNumber,
                                cardExpiryMMYY = "", // TODO credit card detail 
                                cvvCode = null,
                                payerName = null,
                                issuerBankCountry = null, // Example value
                                issuerBankName = null// Example value
                            },

                            storeCardDetails = new StoreCardDetails
                            {
                                storeCardFlag = item.storeCardFlag.ToString(),
                            },

                            installmentPaymentDetails = new InstallmentPaymentDetails
                            {
                                ippFlag = item.ippFlag.ToString() // Example value
                            },

                            recurringPaymentDetails = new RecurringPaymentDetails
                            {
                                rppFlag = item.rppFlag.ToString() // Example value
                            },

                            transactionAmount = new TransactionAmount
                            {
                                amountText = item.amountText.ToString(),
                                currencyCode = item.currencyCode, // Example value
                                decimalPlaces = item.decimalPlaces,
                                amount = item.pa_amount,
                            },
                            originalTransactionAmount = new OriginalTransactionAmount
                            {
                                amountText = item.amountText.ToString(),
                                currencyCode = item.currencyCode, // Example value
                                decimalPlaces = item.decimalPlaces,
                                amount = item.pa_amount,
                            },

                            notificationURLs = new NotificationURLs
                            {
                                confirmationURL = "-", // Example value
                                failedURL = "-", // Example value
                                cancellationURL = "-", // Example value
                                backendURL = "-" // Example value
                            },
                            generalPayerDetails = new GeneralPayerDetails
                            {
                                personType = item.personType, // Example value
                                personName = "",
                                seqNo = "1" // Example value
                            },
                            purchaseItemize = new List<PurchaseItemize>
                            {
                                new PurchaseItemize
                                {
                                    purchaseItemType = null ,// Example value
                                      referenceNo =  rnd.Next().ToString(),
                                }
                            }
                        };
                        paymentDTOList.Add(paymentDTO);

                    };



                    return paymentDTOList;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// UpdateStatusTransaction from External API response
        /// </summary>
        /// <param name="payment">PaymentResponseDTO</param>
        /// <returns>true /false</returns>
        public bool UpdateStatusTransaction(PaymentResponseDTO payment)
        {
            try
            {
                if (payment.apiResponse.acquirerResponseCode == acquirerResponse.Approved.ToString())
                {
                    return _Repository.Update(
                        payment.apiResponse.acquirerResponseCode,
                        payment.data.paymentResult.orderNo,
                        payment.data.paymentResult.orderNo
                        );
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool InsertTransactionHeader(PaymentDTO paymentDTOInfo)
        {

            PaymentModel paymentModelInfo = new PaymentModel()
            {
                pa_SifNo = paymentDTOInfo.pa_SifNo,
                pa_Sector = paymentDTOInfo.pa_Sector,
                pa_OrderNo = paymentDTOInfo.pa_OrderNo
            };

            bool resultModel = _Repository.InsertTransactionHeader(paymentModelInfo);
            return true;
        }

        public void UpdateProduct(PaymentDTO payment)
        {
            throw new NotImplementedException();
        }

        public PaymentModel MapToPaymentModel(PaymentDTO paymentDto)
        {
            return _mapper.Map<PaymentModel>(paymentDto);
        }

        public PaymentDTO MapToPaymentDTO(PaymentModel paymentModel)
        {
            return _mapper.Map<PaymentDTO>(paymentModel);
        }
    }
}
