using Microsoft.AspNetCore.Mvc;
using System;
using WebApi2c2p.Helper;
using Microsoft.AspNetCore.Authorization;
using BussinesLogic.Entities.Void;
using Swashbuckle.AspNetCore.Annotations;
using BussinesLogic.Interfaces.Void;

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
        public VoidResponseDTO PaymentNonUI([FromBody] BussinesLogic.Entities.Void.VoidDTO voidEntitie)
        {

            throw new NotImplementedException();

        }
    }
}
