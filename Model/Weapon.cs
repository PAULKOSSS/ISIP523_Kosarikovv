using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model
{
    public class Weapon
    {
        public string WeaponName { get; set; }
        public double AttackFactor { get; set; }

        public Weapon(string name, double attackfactor)
        {
            WeaponName = name;
            AttackFactor = attackfactor;
        }
    }
}
