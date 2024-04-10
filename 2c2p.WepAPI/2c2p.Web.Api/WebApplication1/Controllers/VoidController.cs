using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApi2c2p.Helper;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using BussinesLogic.Entities.Void;
using Swashbuckle.AspNetCore.Annotations;
using BussinesLogic.Interfaces.Void;
using Infrastructure.Helper;

namespace WebApi2c2p.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VoidController : BaseController
    {
        private IVoidService _service;
        public VoidController(IVoidService service)
        {
            _service = service;
        }

        AppSettings configValue = new AppSettings();

        [HttpPost]
        [SwaggerOperation("Void or cancel un-finished authorized transaction. Only transaction that not settled/captured yet can be voided.")]
        [Route("PaymentNonUI")]
        public async Task<VoidResponseDTO> PaymentNonUI([FromBody] BussinesLogic.Entities.Void.VoidDTO voidEntitie)
        {
            try
            {
                var options = new RestClientOptions(configValue.ReadConfig("2c2pConfigs", "urlVoid"));

                var client = new RestClient(options);
                JsonSerializer serializer = new JsonSerializer();

                string jsonString = JsonOperations.ToJson(voidEntitie);

                var request = new RestRequest(jsonString);
                request.AddHeader("accept", "application/json");
                request.AddHeader("apiKey", "12");

                request.AddJsonBody(jsonString, false);
                var response = await client.PostAsync(request);

                Console.WriteLine("{0}", response.Content);

                VoidResponseDTO paymentResponse = JsonConvert.DeserializeObject<VoidResponseDTO>(jsonString);
                LogHelper.LogInfo(this.HttpContext, jsonString, JsonOperations.ToJson(response.Content));
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
