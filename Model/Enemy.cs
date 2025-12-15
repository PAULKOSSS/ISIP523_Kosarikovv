using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model
{
    public class Enemy : Character
    {
        public enum EnemeType { Гоблин, Скелет, Маг, Слизень }

        public EnemeType EnemyName;
        public double Critchance = 20;
        public double Freezechance = 33;

        public Enemy(double hp, double attack, double defense) : base(hp, attack, defense)
        {
        }

        public bool CheckCritchance(Random random)
        {
            return (random.Next(1, 100) <= Critchance);
        }

        public bool CheckFreezechance(Random random)
        {
            return (random.Next(1, 100) <= Freezechance);
        }

        public virtual void Enemy_Attack(Random random, Player player, bool statflag)
        {
            if (IsAlive)
            {
                double blockfactor = 1 - random.Next(70, 101) / 100.0;
                bool crit = CheckCritchance(random);
                bool freeze = CheckFreezechance(random);

                if (!statflag)
                {
                    switch ((int)EnemyName)
                    {
                        // гоблин
                        case 0:
                            {
                                if (crit)
                                {
                                    Console.WriteLine("Крит прокнул");
                                    double damage_in_at = (Attack_value * 2) - player.Defense_value;
                                    player.HP -= (damage_in_at >= 0) ? damage_in_at : 0;

                                }
                                else
                                {
                                    double damage_in_at = Attack_value - player.Defense_value;
                                    player.HP -= (damage_in_at >= 0) ? damage_in_at : 0;
                                }
                                break;
                            }
                        // скелет
                        case 1:
                            {
                                double damage = Attack_value;
                                player.HP -= (damage >= 0) ? damage : 0;
                                break;
                            }
                        // маг
                        case 2:
                            if (freeze) player.isFrized = true;
                            double damage_in_def = Attack_value - player.Defense_value;
                            double blockdamage = damage_in_def * blockfactor;
                            double resdamage = damage_in_def - blockdamage;
                            player.HP -= (resdamage >= 0) ? resdamage : 0;
                            break;
                        // слизень (базовый)
                        case 3:
                            {
                                double damage = Attack_value - player.Defense_value;
                                player.HP -= (damage >= 0) ? damage : 0;
                                break;
                            }
                    }
                }
                else
                {
                    bool block = player.Defense(random);

                    switch ((int)EnemyName)
                    {
                        // гоблин
                        case 0:
                            if (!block && crit)
                            {
                                double damage_in_def = (Attack_value * 2) - player.Defense_value;
                                double blockdamage = damage_in_def * blockfactor;
                                double resdamage = damage_in_def - blockdamage;
                                player.HP -= (resdamage >= 0) ? resdamage : 0;
                            }
                            else if (!block && !crit)
                            {
                                double damage_in_def = Attack_value - player.Defense_value;
                                double blockdamage = damage_in_def * blockfactor;
                                double resdamage = damage_in_def - blockdamage;
                                player.HP -= (resdamage >= 0) ? resdamage : 0;
                            }
                            else if (block) Console.WriteLine("Вы заблокали удар противника");
                            break;
                        // скелет
                        case 1:
                            player.HP -= Attack_value;
                            break;
                        // маг
                        case 2:
                            {
                                if (freeze) player.isFrized = true;
                                double damage_in_def = Attack_value - player.Defense_value;
                                double blockdamage = damage_in_def * blockfactor;
                                double resdamage = damage_in_def - blockdamage;
                                player.HP -= (resdamage >= 0) ? resdamage : 0;
                                break;
                            }
                        // слизень (базовый)
                        case 3:
                            {
                                if (!block)
                                {
                                    double damage = Attack_value - player.Defense_value;
                                    player.HP -= (damage >= 0) ? damage : 0;
                                }
                                else
                                {
                                    Console.WriteLine("Вы заблокали удар слизня");
                                }
                                break;
                            }
                    }
                }
            }
            else return;
        }
    }
}
