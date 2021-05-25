﻿using back_technicalTest.Core.Entities;
using back_technicalTest.Core.UseCases;
using back_technicalTest.Entities.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public GreeterController(ILogger<GreeterController> logger,GreeterUseCase greeterUseCase)
        {
            _logger = logger;
            this.greeterUseCase = greeterUseCase;
        }

        /// <summary>
        /// Responses the greet.
        /// </summary>
        /// <param name="greeterDto">The greeter dto.</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpPost()]
        public async Task<IActionResult> ResponseGreet(GreeterDto greeterDto)
        {
                greeterDto.ResponseType = ResponsesType.Greet;
                return new OkObjectResult(await greeterUseCase.Greet(greeterDto));
        }

        /// <summary>
        /// Responses the name.
        /// </summary>
        /// <param name="greeterDto">The greeter dto.</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(string))]
        public async Task<IActionResult> ResponseName(GreeterDto greeterDto)
        {
            greeterDto.ResponseType = ResponsesType.SayName;
            return new OkObjectResult(await greeterUseCase.Greet(greeterDto));
        }

        /// <summary>
        /// Responses the say good bye.
        /// </summary>
        /// <param name="greeterDto">The greeter dto.</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(GreeterDto))]
        public async Task<IActionResult> ResponseSayGoodBye(GreeterDto greeterDto)
        {
            greeterDto.ResponseType = ResponsesType.SayGoodBye;
            return new OkObjectResult(await greeterUseCase.Greet(greeterDto));
        }



    }
}
