using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model
{
    public class Armor
    {
        public string ArmorName { get; set; }
        public double DefenseFactor { get; set; }

        public Armor(string name, double defenseFactor)
        {
            ArmorName = name;
            DefenseFactor = defenseFactor;
        }
    }
}
