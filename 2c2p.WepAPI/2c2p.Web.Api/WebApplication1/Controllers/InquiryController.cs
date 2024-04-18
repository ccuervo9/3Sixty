using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi2c2p.Helper;
using System.Net.Http;
using System.Net;
using BussinesLogic.Entities.Inquiry;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using BussinesLogic.Interfaces.Inquiry;
using Infrastructure.Helper;


namespace WebApi2c2p.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class InquiryController : BaseController
    {
        private ITransactionListService _service;


        public InquiryController(ITransactionListService service)
        {
            _service = service;
        }
        AppSettings configValue = new AppSettings();

        [HttpGet]
        [SwaggerOperation("Retrieve status of payment transaction(s)")]
        [Route("TransactionStatus")]
        public async Task<TransactionStatusResponseDTO> TransactionStatus([FromBody] string OrderNo)
        {
            try
            {
           
                var options = new RestClientOptions(configValue.ReadConfig("2c2pConfigs", "urlInquiryTransactionStatus"+"?orderNo=" + OrderNo));

                var client = new RestClient(options);
                var request = new RestRequest("");
                request.AddHeader("accept", "application/json");
                request.AddHeader("apiKey", "12");
                var response = await client.GetAsync(request);
                Console.WriteLine("{0}", response.Content);
         

                TransactionStatusResponseDTO paymentResponse = JsonConvert.DeserializeObject<TransactionStatusResponseDTO>(OrderNo);
                LogHelper.LogInfo(this.HttpContext, OrderNo, JsonOperations.ToJson(response.Content), LogTypeEnum.info);
                return paymentResponse;              

            }
          
            catch (Exception ex)
            {
                var res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(ex.Message);
                throw new System.Web.Http.HttpResponseException(res);
            }           
        }


        [HttpPost]
        [SwaggerOperation("Retrieve transaction list including latest payment status. It can be called without any parameter but the result will only limitted to 500 results and/or within past full 12 months (whatever more limited)")]
        [Route("PrepaymentUI")]
        public TransactionListResponseDTO PrepaymentUI([FromBody] TransactionListDTO payment)
        {
            try
            {

                return null;

            }

            catch (Exception ex)
            {
                var res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(ex.Message);
                throw new System.Web.Http.HttpResponseException(res);
            }

        }
    }
}
