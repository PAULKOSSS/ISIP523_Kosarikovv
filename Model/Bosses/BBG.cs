using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISIP523_Kosarikov.Model.Enemy;

namespace ISIP523_Kosarikov.Model.Bosses
{
    public class BBG : Enemy
    {
        public BBG(double hp, double attack, double defense) : base(hp * 2, attack * 1.5, defense * 1.5)
        {
            EnemyName = EnemeType.Гоблин;
            Critchance = 30;
        }
    }
}
