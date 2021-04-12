using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using vacay.Interface;
using vacay.Services;

namespace vacay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchasablesController : ControllerBase
    {
        private readonly VacationServices _vacationServices;
        public PurchasablesController(VacationServices vacationServices)
        {
            _vacationServices = vacationServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<IPurchasable>> GetAllPurchasables()
        {
            try
            {
                return Ok(_vacationServices.getAll());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}