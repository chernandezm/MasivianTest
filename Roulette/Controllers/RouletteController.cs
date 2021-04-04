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
    [Route("api/Roulette")]
    public class RouletteController : Controller
    {
        private IRouletteService _service;
        private IBetService _service2;

        public RouletteController(IRouletteService service, IBetService service2)
        {
            _service = service;
            _service2 = service2;
        }

        /// <summary>
        /// Obtains al roulettes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ApplicationCore.Entities.Roulette> GetRoulettes()
        {
            var roulette = _service.GetRoulettesAsync();
            return roulette.Result;
        }

        /// <summary>
        /// Create a new roulette
        /// </summary>
        /// <param name="roulette"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ApplicationCore.Entities.Roulette> CreateRoulette([FromBody] ApplicationCore.Entities.Roulette roulette)
        {
            var res = _service.CreateRouletteAsync(roulette);
            return res.Result;
        }

        /// <summary>
        /// Update a roulette
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roulette"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ApplicationCore.Entities.Roulette> UpdateRoulette(int id, [FromBody] ApplicationCore.Entities.Roulette roulette)
        {
            var res = _service.UpdateRouletteAsync(id, roulette);
            if (res.Result.Status == false)
            {
                var result = _service2.GetBets(res.Result.IdRoulette);
                res.Result.bet = result;
            }
            return res.Result;
        }

        /// <summary>
        /// Create bet
        /// </summary>
        /// <param name="bet"></param>
        /// <returns></returns>
        [Route("api/Roulette/bet")]
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
            var res = _service2.CreateBetAsync(bet);
            return res.Result;
        }
    }
}
