using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model.EnemyFactory
{
    public interface IEnemyFactory
    {
        Enemy CreateRandomEnemy(Random random);
        Enemy CreateBoss(Random random);
    }
}
