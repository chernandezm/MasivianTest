using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class RouletteService : IRouletteService
    {
        private IAsyncRepository<Roulette> _repository;

        public RouletteService(IAsyncRepository<Roulette> repository)
        {
            _repository = repository;
        }

        public async Task<Roulette> CreateRouletteAsync(Roulette roulette)
        {
            var resultado = await _repository.AddAsync(roulette);
            return resultado;
        }

        public async Task<IEnumerable<Roulette>> GetRoulettesAsync()
        {
            var resultado = await _repository.ListAllAsync();

            return resultado;
        }

        public Task<Roulette> UpdateRouletteAsync(int id, Roulette roulette)
        {
           var res =  _repository.UpdateAsync(id, roulette);
           return res;
        }

        public async Task<Roulette> GetRouletteById(int id)
        {
            var res = await _repository.GetByIdAsync(id);
            return res;
        }
    }
}
