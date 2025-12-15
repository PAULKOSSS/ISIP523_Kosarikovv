using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISIP523_Kosarikov.Model.Enemy;

namespace ISIP523_Kosarikov.Model.Bosses
{
    public class Kovalski : Enemy
    {
        public Kovalski(double hp, double attack, double defense) : base(hp * 2.5, attack * 1.3, defense * 1.4)
        {
            EnemyName = EnemeType.Скелет;
        }
    }
}
