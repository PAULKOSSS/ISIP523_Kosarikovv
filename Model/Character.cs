using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model
{
    public class Character
    {
        public double HP { get; set; }
        public double Attack_value { get; set; }
        public double Defense_value { get; set; }

        public bool IsAlive => HP > 0;

        public Character(double hp, double attack, double defense)
        {
            HP = hp;
            Attack_value = attack;
            Defense_value = defense;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Общее состояние: ХП - {HP}, Атака - {Attack_value}, Защита - {Defense_value}");
        }
    }
}
