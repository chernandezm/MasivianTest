using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Bet
    {
        [Key]
        public int IdBet { get; set; }
        public int IdUser { get; set; }
        [Range(0, 38)]
        public int Number { get; set; }
        [Range(0.5d, maximum: 10000)]
        public double Cash { get; set; }
        public bool Colour { get; set; }
        public int IdRoulette { get; set; }
    }
}
