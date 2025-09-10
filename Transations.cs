using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Parallel
{
    internal class Transations
    {
        public int TransactionGroupId { get; set; }
        public string? TransitionName { get; set; }
        public string? TransitionDate { get; set; }
        public decimal TransitionAmmount { get; set; }
        public decimal TransitionCostPerPerson { get; set; }
        public string? Paytor {  get; set; } 
        public bool DebtsPayed { get; set; }

    }
}
