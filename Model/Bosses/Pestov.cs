using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISIP523_Kosarikov.Model.Enemy;

namespace ISIP523_Kosarikov.Model.Bosses
{
    public class Pestov : Enemy
    {
        public Pestov(double hp, double attack, double defense) : base(hp * 1.3, attack * 1.8, defense * 0.6)
        {
            EnemyName = EnemeType.Скелет;
            Freezechance = 48;
        }

        public override void Enemy_Attack(Random random, Player player, bool statflag)
        {
            bool freeze = CheckFreezechance(random);
            player.HP -= Attack_value;
            if (freeze) player.isFrized = true;
        }
    }
}
