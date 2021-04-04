using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class RouletteRepository : IAsyncRepository<Roulette>
    {
        protected readonly RouletteContext _dbContext;

        public RouletteRepository(RouletteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Roulette> AddAsync(Roulette entity)
        {
            try
            {
                await _dbContext.Roulette.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Roulette> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Roulette> GetByIdAsync(int id)
        {
            var res = await _dbContext.Roulette.FindAsync(id);
            return res;
        }

        public async Task<IReadOnlyList<Roulette>> ListAllAsync()
        {
            var res = await _dbContext.Roulette.ToListAsync();
            return res;
        }

        public async Task<Roulette> UpdateAsync(int id, Roulette roulette)
        {
            try
            {
                Roulette res = await GetByIdAsync(id);
                res.Status = roulette.Status;

                _dbContext.Update(res);
                _dbContext.SaveChanges();
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
            

        }
    }
}
