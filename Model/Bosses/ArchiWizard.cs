using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISIP523_Kosarikov.Model.Enemy;

namespace ISIP523_Kosarikov.Model.Bosses
{
    public class ArchiWizard : Enemy
    {
        public ArchiWizard(double hp, double attack, double defense) : base(hp * 1.8, attack * 1.6, defense * 1.1)
        {
            EnemyName = EnemeType.Маг;
            Freezechance = 43;
        }
    }
}
