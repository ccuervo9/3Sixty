using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi2c2p.Helper;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using BussinesLogic.Interfaces.Payment;
using Swashbuckle.AspNetCore.Annotations;
using BussinesLogic.Entities.Payment.Request;
using BussinesLogic.Entities.Payment.Response;
using Infrastructure.Helper;
using DataAccess.Model.Payment;



namespace WebApi2c2p.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService )
        {
            _paymentService = paymentService;
        }
        AppSettings configValue = new AppSettings();

        [HttpPost]
        [SwaggerOperation("Get the response for secure/nonUI Payment")]
        [Route("PaymentNonUI")]
        [Authorize]
        public async Task<bool> PaymentNonUI()
        {
            try
            {
                var options = new RestClientOptions(configValue.ReadConfig("2c2pConfigs", "urlPrePaymentNonUI"));

                var client = new RestClient(options);

                JsonSerializer serializer = new JsonSerializer();
                bool paymentResponse = false;


                string enviroment = configValue.ReadConfig("Enviroment", "dev_enviroment");
                //Call servcices
                PaymentDTO payment = new PaymentDTO();
                var product = _paymentService.GetProductByParameters(payment, enviroment);


                int order = 0;
                foreach (var item in product)
                {
                    if (item != null)
                    {
                        order = order + 1;
                        paymentResponse = await SendDataAsync(client, item, order);
                    }
                }

                return paymentResponse;

             
            }

            catch (Exception ex)
            {
                var res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(ex.Message);
                throw new System.Web.Http.HttpResponseException(res);
            }

        }



        /// <summary>
        /// Method to retry when it fails  the execution
        /// </summary>
        /// <param name="client"></param>
        /// <param name="product"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private async Task<bool> SendDataAsync(RestClient client, PaymentDTO product, int order)
        {
            // Retry logic with exponential backoff
            int maxRetries = 1;
            TimeSpan delay = TimeSpan.FromSeconds(2);
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    // Make API call
                    return SenRequestExternalAPI(client, product, order);
                }
                catch (HttpRequestException ex) when (ex.InnerException is System.Net.Sockets.SocketException)
                {
                    // Log the error
                    Console.WriteLine($"Error: {ex.Message}");

                    // Retry after delay
                    await Task.Delay(delay);
                    delay *= 2; // Exponential backoff
                }
                catch (Exception ex)
                {
                    // Handle other types of errors
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }

            // Retry limit exceeded
            return false;
        }


        /// <summary>
        /// SenRequestExternalAPI to 2C2P
        /// </summary>
        /// <param name="client"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        private bool SenRequestExternalAPI(RestClient client, PaymentDTO product, int order)
        {
            try
            {

                string jsonString = JsonOperations.ToJson(product);

                var request = new RestRequest("");

                request.AddHeader("apiKey", "ab282fc6d34b4eb29f4367c486fad8c4");
                request.AddHeader("accept", "application/json");
                request.AddHeader("My-Custom-Header", "foobar");
                request.AddHeader("Content-type", "application/json");

                request.AddHeader("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6Im1YTXlJSnE0ejFWbzFKMWI5LXpZX2ciLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE2MDM0MzkxODksImV4cCI6MTYzNDk5NjE0MSwiaXNzIjoiaHR0cHM6Ly9pZGVudGl0eS1zZXJ2ZXIuc2l0LXBhY28uMmMycC5jb20iLCJhdWQiOiJQYUNvQVBJIiwiY2xpZW50X2lkIjoiQXNwTmV0Q29yZUlkZW50aXR5Iiwic3ViIjoiNjhiMzJmYjMtNzM0Ny00YTdlLWE4ODItNWVlYzcyZjdmMjAzIiwiYXV0aF90aW1lIjoxNjAzNDM5MTg3LCJpZHAiOiJsb2NhbCIsImNvbXBhbnlJZCI6ImYyOTNiZjM1M2VjMjRlZWFiMzdiOTllYjg0NmZkNjExIiwib3JnYW5pemF0aW9uSWQiOiIyIiwibmFtZSI6Im1yIENvbXBhbnkgQWRtaW4iLCJlbWFpbCI6ImNvbXBhbnlhZG1pbkAyYzJwLmNvbSIsInRlbmFudCI6Im1hYiIsImdyb3VwSWQiOiI0ZTcwZDE1Yy01ODhlLTQxMTUtOTU5Mi1jMWRmMmFmNDQzMzQiLCJncm91cE5hbWUiOiJQQUNPLkNvbXBhbnkuQWRtaW4iLCJvZmZpY2VHcm91cElkIjoiZWRhZDc2YzI4ZmQ5NGY0M2JkOTdjYzEwNGIwYWFiYTciLCJsYXN0TG9nZ2VkSW4iOiIxMC8yMy8yMDIwIDA3OjQ2OjI3Iiwic2NvcGUiOlsib3BlbmlkIiwicHJvZmlsZSIsIlBhQ29BUEkiLCJvZmZsaW5lX2FjY2VzcyJdLCJhbXIiOlsicHdkIl19.P4RaPMWhsKpq4rF5cAS4QpqMQtkAqWCSFY2kta1wb6Ocbdxn3NjgPG0kxY8vlGwIUwP1h0XchWThkF0JtTeAOzVBBd52bJpva9hlJWWLW6xZgqZkWKAg9dwqbDfixsaYCLAOy-H78CIs_1SqX_2r1XT5rkPpYnOzcuud60bqqt7-jV7xr4tYC9W6udaK9nEfoIR_T5D8tup2hwgksPcJ1zMUrKkwzLGpQQfEQCzWTAmXnzQNWoZ79IV6Uq8EVdVZqXJsFB-0zsfCCpkaUWNM9Mw0ksJ3JchZwws61WlhxkGv-eaiGfFVyqgBoWUCCs_M3YA1MZDQ-hwcsn2lO3rv_A");
                request.AddJsonBody(jsonString, false);

                var response = client.ExecutePost(request);

                PaymentResponseDTO paymentResponse = JsonConvert.DeserializeObject<PaymentResponseDTO>(response.Content);

                LogHelper.LogInfo(this.HttpContext, jsonString, JsonOperations.ToJson(response.Content), LogTypeEnum.info);


                _paymentService.InsertTransactionHeader( product);


                if (response.IsSuccessStatusCode)
                {
                    LogHelper.LogInfo(this.HttpContext, $"Transaction {order} sent successfully.", JsonOperations.ToJson(response.Content), LogTypeEnum.info);
                    // UpdateStatusTransaction for every transaction executed in external API 
                    _paymentService.UpdateStatusTransaction(paymentResponse);

                    return true;
                }
                else
                {
                    LogHelper.LogInfo(this.HttpContext, $"Failed to send transaction {order} and order {product.orderNo} " + jsonString, JsonOperations.ToJson(response.Content), LogTypeEnum.error);
                    return false;
                }

            }
            catch (Exception ex)
            {
                LogHelper.LogInfo(this.HttpContext, "Exeption External API " , ex.Message.ToString(), LogTypeEnum.error);
                return false;
            }
        }

        [HttpPost]
        [SwaggerOperation("Get the response for secure/Prepayment  Payment")]
        [Route("PrepaymentUI")]
        [Authorize]
        public async Task<PrePaymentUIResponseDTO> PrepaymentUI([FromBody] PrePaymentUIDTO payment)
        {
            PrePaymentUIResponseDTO paymentResponse = new PrePaymentUIResponseDTO();
            try
            {

                var options = new RestClientOptions(configValue.ReadConfig("2c2pConfigs", "urlPrePaymentUI"));

                var client = new RestClient(options);
                JsonSerializer serializer = new JsonSerializer();

                string jsonString = JsonOperations.ToJson(payment);

                var request = new RestRequest(jsonString);
                request.AddHeader("accept", "application/json");
                request.AddHeader("apiKey", "ab282fc6d34b4eb29f4367c486fad8c4");

                request.AddJsonBody(jsonString, false);
                var response = await client.PostAsync(request);

                Console.WriteLine("{0}", response.Content);

                paymentResponse = JsonConvert.DeserializeObject<PrePaymentUIResponseDTO>(jsonString);
                LogHelper.LogInfo(this.HttpContext, jsonString, JsonOperations.ToJson(response.Content),LogTypeEnum.info);
                return paymentResponse;

            }

            catch (Exception ex)
            {
                var res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(ex.Message);

                LogHelper.LogInfo(this.HttpContext, "Exeption External API ", ex.Message.ToString(), LogTypeEnum.error);
                return paymentResponse;

                throw new System.Web.Http.HttpResponseException(res);
            }

        }
    }
}
