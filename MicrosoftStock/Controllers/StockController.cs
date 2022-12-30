using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicrosoftStock.Repository;

namespace MicrosoftStock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public sealed class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        /// <summary>
        /// Lista de valores da bolsa da Microsoft
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna todos os valores da bolsa da Microsoft </response>
        [HttpGet("", Name = nameof(GetAll))]
        [ProducesResponseType(200)]
        public IActionResult GetAll()
        {
            return Ok(_stockRepository.GetAll());
        }
    }
}
