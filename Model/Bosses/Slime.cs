using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISIP523_Kosarikov.Model.Enemy;

namespace ISIP523_Kosarikov.Model.Bosses
{
    public class Slime : Enemy
    {
        private const double DamageReduction = 2.0; // Уменьшение входящего урона на 2 единицы

        public Slime(double hp, double attack, double defense) : base(hp, attack, defense)
        {
            EnemyName = EnemeType.Слизень;
        }

        public override void Enemy_Attack(Random random, Player player, bool statflag)
        {
            if (!IsAlive) return;

            if (!statflag)
            {
                // Игрок атакует, не защищается
                double damage = Attack_value - player.Defense_value;
                player.HP -= (damage >= 0) ? damage : 0;
                Console.WriteLine($"Слизень атакует! Урон: {(damage >= 0 ? damage : 0)}");
            }
            else
            {
                // Игрок защищается
                bool block = player.Defense(random);
                if (!block)
                {
                    double damage = Attack_value - player.Defense_value;
                    player.HP -= (damage >= 0) ? damage : 0;
                    Console.WriteLine($"Слизень атакует! Урон: {(damage >= 0 ? damage : 0)}");
                }
                else
                {
                    Console.WriteLine("Вы заблокали удар слизня");
                }
            }
        }

        // Переопределяем получение урона для слизня
        public new double HP
        {
            get => base.HP;
            set
            {
                // При получении урона уменьшаем его на 2 единицы
                double incomingDamage = base.HP - value;
                if (incomingDamage > 0)
                {
                    double reducedDamage = Math.Max(incomingDamage - DamageReduction, 0);
                    base.HP -= reducedDamage;
                    Console.WriteLine($"Слизень уменьшил урон на {DamageReduction} единицы. Фактический урон: {reducedDamage}");
                }
            }
        }
    }
}
