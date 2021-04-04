using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRouletteService
    {
        public Task<IEnumerable<Roulette>> GetRoulettesAsync();
        public Task<Roulette> CreateRouletteAsync(Roulette roulette);
        public Task<Roulette> GetRouletteById(int id);
        public Task<Roulette> UpdateRouletteAsync(int id, Roulette roulette);
    }
}
