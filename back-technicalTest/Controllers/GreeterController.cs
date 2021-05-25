using back_technicalTest.Core.Entities;
using back_technicalTest.Core.Exceptions;
using back_technicalTest.Core.UseCases;
using back_technicalTest.Entities.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace back_technicalTest_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GreeterController : ControllerBase
    {

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<GreeterController> _logger;
        /// <summary>
        /// The greeter use case
        /// </summary>
        private readonly GreeterUseCase greeterUseCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="GreeterController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="greeterUseCase">The greeter use case.</param>
        public GreeterController(ILogger<GreeterController> logger, GreeterUseCase greeterUseCase)
        {
            _logger = logger;
            this.greeterUseCase = greeterUseCase;
        }

        /// <summary>
        /// Responses the greet.
        /// </summary>
        /// <param name="greeterDto">The greeter dto.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(GreeterResponse))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> ResponseGreet(GreeterDto greeterDto)
        {
            try
            {
                greeterDto.ResponseType = ResponseType.Greet;
                return new OkObjectResult(await greeterUseCase.Greet(greeterDto));
            }
            catch (NotExistIdiomException nei)
            {
                _logger.LogError(nei.Message);
                return NotFound(nei.Message);
            }

        }

        /// <summary>
        /// Responses saying name .
        /// </summary>
        /// <param name="greeterDto">The greeter dto.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(GreeterResponse))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> ResponseName(GreeterDto greeterDto)
        {
            try
            {
                greeterDto.ResponseType = ResponseType.SayName;
                return new OkObjectResult(await greeterUseCase.Greet(greeterDto));
            }
            catch (NotExistIdiomException nei)
            {
                _logger.LogError(nei.Message);
                return NotFound(nei.Message);
            }
        }

        /// <summary>
        /// Responses saying good bye.
        /// </summary>
        /// <param name="greeterDto">The greeter dto.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(GreeterResponse))]
        [ProducesResponseType(404, Type = typeof(string))]
        public async Task<IActionResult> ResponseSayGoodBye(GreeterDto greeterDto)
        {
            try
            {
                greeterDto.ResponseType = ResponseType.SayGoodBye;
                return new OkObjectResult(await greeterUseCase.Greet(greeterDto));
            }
            catch (NotExistIdiomException nei)
            {
                _logger.LogError(nei.Message);
                return NotFound(nei.Message);
            }
        }



    }
}
