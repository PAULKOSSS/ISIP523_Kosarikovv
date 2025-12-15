using ISIP523_Kosarikov.Model.Bosses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model.EnemyFactory
{
    public class SimpleEnemyFactory : IEnemyFactory
    {
        public Enemy CreateRandomEnemy(Random random)
        {
            double hp = Convert.ToDouble(random.Next(50, 71));
            double attack = Convert.ToDouble(random.Next(8, 16));
            double defense = Convert.ToDouble(random.Next(10, 21));

            int enemyType = random.Next(4); // 0-3 (4 типа врагов)

            Enemy enemy = enemyType switch
            {
                0 => new Enemy(hp, attack, defense) { EnemyName = Enemy.EnemeType.Гоблин },
                1 => new Enemy(hp, attack, defense) { EnemyName = Enemy.EnemeType.Скелет },
                2 => new Enemy(hp, attack, defense) { EnemyName = Enemy.EnemeType.Маг },
                3 => new Slime(hp, attack, defense) { EnemyName = Enemy.EnemeType.Слизень },
                _ => new Enemy(hp, attack, defense) { EnemyName = Enemy.EnemeType.Гоблин }
            };

            return enemy;
        }

        public Enemy CreateBoss(Random random)
        {
            double baseHP = random.Next(70, 101);
            double baseAttack = random.Next(15, 26);
            double baseDefense = random.Next(10, 16);

            int bossType = random.Next(5); // 0-4 (5 типов боссов)

            return bossType switch
            {
                0 => new BBG(baseHP, baseAttack, baseDefense),
                1 => new Kovalski(baseHP, baseAttack, baseDefense),
                2 => new ArchiWizard(baseHP, baseAttack, baseDefense),
                3 => new Pestov(baseHP, baseAttack, baseDefense),
                4 => new Slime(baseHP * 1.5, baseAttack * 1.2, baseDefense * 1.2),
                _ => new BBG(baseHP, baseAttack, baseDefense)
            };
        }
    }
}
