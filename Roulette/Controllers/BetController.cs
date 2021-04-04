using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Roulette.Controllers
{
    [ApiController]
    [Route("api/Bet")]
    public class BetController : Controller
    {
        private IBetService _service;

        public BetController(IBetService service)
        {
            _service = service;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Bet> CreateBet([FromBody] Bet bet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = true,
                    msg = "Bad Request"
                });
            }
            var res = _service.CreateBetAsync(bet);
            return res.Result;
        }
    }
}
