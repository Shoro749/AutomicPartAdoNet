using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomicPartAdoNet.Models
{
    internal class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Card { get; set; }
        public int Balance { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
