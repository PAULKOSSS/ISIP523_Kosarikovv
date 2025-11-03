namespace Pr6
{
    class Programm
    {
        class Weapon
        {
            public string WeaponName;
            public double AttackFactor;
        }

        class Armor
        {
            public string ArmorName;
            public double DefenseFactor;
        }

        public class Character
        {
            public double HP;
            public double Attack_value;
            public double Defense_value;

            public Character(int hp, int attack, int defense)
            {
                HP = Convert.ToDouble(hp);
                Attack_value = Convert.ToDouble(attack);
                Defense_value = Convert.ToDouble(defense);
            }
        }

        

        class Player : Character 
        {
            public Weapon Player_weapon;
            public Armor Player_armor;
            public bool isFrized = false;

            public Player(int hp, int attack, int defense, Weapon weapon, Armor armor) 
                :base (hp, attack, defense)
            {
                Attack_value = Convert.ToDouble(attack) * weapon.AttackFactor;
                Defense_value = Convert.ToDouble(defense) * armor.DefenseFactor;
                Player_weapon = weapon;
                Player_armor = armor;
            }

            
            public double Attack()
            {
                return Attack_value;
            }

            public bool Defense(Random random)
            {
                if (random.Next(1, 100) <= 40) return true;
                else return false;
            }

            


        }

        class Enemy : Character
        {
            public enum EnemeType {Гоблин, Скелет, Маг}

            public EnemeType EnemyName;

            public double Critchance = 40;
            public double Freezechance = 33;

            public Enemy(int hp, int attack, int defense) : base(hp, attack, defense) 
            {
                Random rand = new();
                int randchoice = rand.Next(3);
                EnemyName = (EnemeType)randchoice;
            }

            public bool CheckCritchance(Random random)
            {
                return (random.Next(1, 100) <= Critchance);
            }

            public bool CheckFreezechance(Random random)
            {
                return (random.Next(1, 100) <= Freezechance);
            }

            public virtual void Enemy_Attack(Random random, Player player)
            {
                bool block = player.Defense(random);
                bool crit = CheckCritchance(random);
                bool freeze = CheckFreezechance(random);

                switch ((int)EnemyName) 
                {
                    case 0:
                        if (!block && crit)
                        {
                            player.HP -= (((Attack_value * 2) - player.Defense_value) * (random.Next(70, 100) / 100));
                        }
                        else if (!block && !crit)
                        {
                            player.HP -= ((Attack_value - player.Defense_value) * (random.Next(70, 100) / 100));
                        }
                        else if (block) Console.WriteLine("Вы заблокали удар противника");
                        break;
                    case 1:
                        player.HP -= (Attack_value * (random.Next(70, 100) / 100));
                        break;
                    case 2:
                        if (freeze) player.isFrized = true;
                        break;

                }
            }
        }

        class BBG : Enemy 
        {
            public BBG(int hp, int attack, int defense) : base(hp, attack, defense) 
            {
                HP = Convert.ToDouble(hp) * 2;
                Attack_value = Convert.ToDouble(attack) * 1.5;
                Defense_value = Convert.ToDouble(defense) * 1.2;
                EnemyName = EnemeType.Гоблин;
                Critchance *= 1.1;
            }
        }

        class ArchiWizard : Enemy
        {
            public ArchiWizard(int hp, int attack, int defense) : base(hp, attack, defense) {
                HP = Convert.ToDouble(hp) * 1.8;
                Attack_value = Convert.ToDouble(attack) * 1.6;
                Defense_value = Convert.ToDouble(defense) * 1.1;
                EnemyName = EnemeType.Маг;
                Freezechance *= 1.1;
            }
        }

        class Kovalski : Enemy
        {
            public Kovalski(int hp, int attack, int defense) : base(hp, attack, defense) {
                HP = Convert.ToDouble(hp) * 2.5;
                Attack_value = Convert.ToDouble(attack) * 1.3;
                Defense_value = Convert.ToDouble(defense) * 1.4;
                EnemyName = EnemeType.Скелет;
            }
        }

        class Pestov : Enemy
        {
            public Pestov(int hp, int attack, int defense) : base(hp, attack, defense) {
                HP = Convert.ToDouble(hp) * 1.3;
                Attack_value = Convert.ToDouble(attack) * 1.8;
                Defense_value = Convert.ToDouble(defense) * 0.6;
                EnemyName = EnemeType.Скелет;
                Freezechance *= 1.15;
            }

            public override void Enemy_Attack(Random random, Player player)
            {
                bool freeze = CheckFreezechance(random);
                player.HP -= Attack_value;
                if (freeze) player.isFrized = true;
            }
        }

        class Game
        {
            public int turn = 1;

            public void Start() 
            {
                
            }

            public void Fight()
            {

            }

            public void BossFight()
            {

            }

            public void Event()
            {

            }
        }

        



        static void Main(string[] args)
        {
            Random random = new();
            
        }
    }
}
