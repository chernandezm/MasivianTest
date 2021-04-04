using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBetService
    {
        public List<Bet> GetBets(int id);
        public Task<Bet> CreateBetAsync(Bet bet);
    }
}
