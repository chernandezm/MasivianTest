using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class BetService : IBetService
    {
        private IAsyncRepository<Bet> _repository;

        public BetService(IAsyncRepository<Bet> repository)
        {
            _repository = repository;

        }

        public async Task<Bet> CreateBetAsync(Bet bet)
        {
            var res = await _repository.AddAsync(bet);
            return bet;
        }

        public List<Bet> GetBets(int id)
        {
            var res = _repository.GetById(id);
            return res;
        }

        public Task<IEnumerable<Bet>> GetBetsAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
