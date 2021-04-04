using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infraestructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class BetRepository : IAsyncRepository<Bet>
    {
        protected readonly RouletteContext _dbContext;

        public BetRepository(RouletteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bet> AddAsync(Bet entity)
        {
            try
            {
                var res = await _dbContext.Bet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        public List<Bet> GetById(int id)
        {
            var res = _dbContext.Bet.Where(x => x.IdRoulette == id).ToList();
            return res;

        }

        public Task<IReadOnlyList<Bet>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Bet> UpdateAsync(int id, Bet entity)
        {
            throw new NotImplementedException();
        }

        Task<Bet> IAsyncRepository<Bet>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
