using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi2c2p.Helper;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using BussinesLogic.Entities.Refund;
using Swashbuckle.AspNetCore.Annotations;
using BussinesLogic.Interfaces.Refund;
using Infrastructure.Helper;



namespace WebApi2c2p.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RefundController : BaseController
    {
        private readonly IRefundService _Service;


        public RefundController(IRefundService service)
        {
            _Service = service;
        }
        AppSettings configValue = new AppSettings();

        [HttpPost]
        [SwaggerOperation("Refund a settled or captured transaction.")]
        [Route("Refund")]
        public async Task<RefundResponseDTO> Refund([FromBody] RefundDTO refund)
        {
            if (refund is null)
            {
                throw new ArgumentNullException(nameof(refund));
            }

            try
            {

                var options = new RestClientOptions(configValue.ReadConfig("2c2pConfigs", "urlRefund"));


                var client = new RestClient(options);
                JsonSerializer serializer = new JsonSerializer();

                string jsonString = JsonOperations.ToJson(refund);

                var request = new RestRequest(jsonString);
                request.AddHeader("accept", "application/json");
                request.AddHeader("apiKey", "12");

                request.AddJsonBody(jsonString, false);
                var response = await client.PostAsync(request);

                Console.WriteLine("{0}", response.Content);

                RefundResponseDTO paymentResponse = JsonConvert.DeserializeObject<RefundResponseDTO>(jsonString);
                LogHelper.LogInfo(this.HttpContext, jsonString, JsonOperations.ToJson(response.Content), LogTypeEnum.info);
                return paymentResponse;

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
