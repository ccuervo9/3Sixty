using Microsoft.AspNetCore.Mvc;

using RestSharp;
using System;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using WebApi2c2p.Helper;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using BussinesLogic.Entities.Settlement;
using BussinesLogic.Entities.Settlment;
using BussinesLogic.Interfaces.Settlement;
using Infrastructure.Helper;




namespace WebApi2c2p.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SettlementController : BaseController
    {
        private ISettlementService  _service;


        public SettlementController(ISettlementService service)
        {
            _service = service;
        }

        AppSettings configValue = new AppSettings();

        [HttpPut]
        [SwaggerOperation("Captured un-finished authorized transaction.")]
        [Route("settlement")]
        public async Task<SettlementResponseDTO> updateSettlement([FromBody] SettlementDTO settlement)
        {
            if (settlement is null)
            {
                throw new ArgumentNullException(nameof(settlement));
            }

            try
            {
                var options = new RestClientOptions(configValue.ReadConfig("2c2pConfigs", "urlSettlement"));

            
  
                var client = new RestClient(options);
                var request = new RestRequest("");
                request.AddHeader("accept", "application/json");
                request.AddHeader("apiKey", "12");
                string jsonString = JsonOperations.ToJson(settlement);
                request.AddJsonBody(jsonString, false);
                var response = await client.PutAsync(request);


                SettlementResponseDTO paymentResponse = JsonConvert.DeserializeObject<SettlementResponseDTO>(jsonString);
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
