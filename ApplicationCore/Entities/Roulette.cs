using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Roulette
    {
        [Key]
        public int IdRoulette { get; set; }
        public bool Status { get; set; }
        public List<Bet> bet { get; set; }
    }
}
