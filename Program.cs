namespace Pr6
{
    class Programm
    {
        class Weapon
        {
            public string WeaponName;
            public double AttackFactor;

            public Weapon(string name, double attackfactor)
            {
                WeaponName = name;
                AttackFactor = attackfactor;
            }
        }

        class Armor
        {
            public string ArmorName;
            public double DefenseFactor;

            public Armor(string name, double defenseFactor) 
            { 
                ArmorName = name;
                DefenseFactor = defenseFactor;
            }
        }

        public class Character
        {
            
            public double HP;
            public double Attack_value;
            public double Defense_value;
            public bool IsAlive
            {
                get
                {
                    if (HP > 0) return true;
                    else return false;
                }
            }

            public Character(int hp, int attack, int defense)
            {
                HP = Convert.ToDouble(hp);
                Attack_value = Convert.ToDouble(attack);
                Defense_value = Convert.ToDouble(defense);
            }

            public virtual void PrintInfo()
            {
                Console.WriteLine($"Общее состояние: ХП - {HP}, Атака - {Attack_value}, Защита - {Defense_value}");
            }
        }

        

        class Player : Character 
        {
            public Weapon Player_weapon;
            public Armor Player_armor;
            public bool isFrized = false;
            public double basehp = 100;

            public Player(int hp, int attack, int defense, Weapon weapon, Armor armor) 
                :base (hp, attack, defense)
            {
                Attack_value = Convert.ToDouble(attack) * weapon.AttackFactor;
                Defense_value = Convert.ToDouble(defense) * armor.DefenseFactor;
                Player_weapon = weapon;
                Player_armor = armor;
            }

            public override void PrintInfo()
            {
                base.PrintInfo();
                Console.WriteLine($"Оружие: Название - {Player_weapon.WeaponName}, Бафф - {Player_weapon.AttackFactor}");
                Console.WriteLine($"Броня: Название - {Player_armor.ArmorName}, Бафф - {Player_armor.DefenseFactor}");
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

            public double Critchance = 20;
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
            //public bool isGame = true;
            public static List<Weapon> CreateWeapons()
            {
                List<Weapon> weapons = new List<Weapon>
                {
                    new Weapon("Меч", 1.5),
                    new Weapon("Топор", 1.8),
                    new Weapon("Лук", 1.3),
                    new Weapon("Кинжал", 1.2),
                    new Weapon("Посох", 1.4)
                };
                return weapons;
            }

            public static List<Armor> CreateArmors()
            {
                List<Armor> armors = new List<Armor>
                {
                    new Armor("Кожаная броня", 1.2),
                    new Armor("Кольчуга", 1.5),
                    new Armor("Латы", 2.0),
                    new Armor("Мантия мага", 1.1),
                    new Armor("Доспех разбойника", 1.3)
                };
                return armors;
            }

            public void Start(Random random) 
            {
                List<Weapon> weapons = CreateWeapons();
                List<Armor> armors = CreateArmors();
                Console.WriteLine("Добро пожаловать в игру, сделанную на коленке в 3 часа ночи. Игра кончается на 50 ходу или после смерти игрока");
                Weapon weapon0 = new("кулаки", 1);
                Armor armor0 = new("пайта", 1);
                Player Mainplayer = new(100, 20, 15, weapon0, armor0);

                while (Mainplayer.IsAlive && turn <= 50)
                {
                    Console.WriteLine($"Ход - {turn}");
                    int randchoice = random.Next(1, 2);
                    if (turn % 10 != 0)
                    {
                        switch (randchoice)
                        {
                            case 1:
                                Event(random, Mainplayer, weapons, armors);
                                break;
                            case 2:
                                Fight(Mainplayer, random);
                                break;
                        }
                    }
                    else
                    {
                        BossFight();
                    }
                }
            }

            public void Fight(Player player, Random random)
            {
                Enemy enemy = new(50, 10, 5);
                Console.WriteLine($"Перед вами враг {enemy.EnemyName}");
                while (enemy.IsAlive && player.IsAlive)
                {
                    Console.Write("Можете атаковать(1) или защищаться(2). Что выберете? ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"ХП врага - {enemy.HP}, ваше ХП - {player.HP}");
                            enemy.HP -= player.Attack();
                            break;
                        case 2:
                            enemy.Enemy_Attack(random, player);
                            Console.WriteLine($"ХП врага - {enemy.HP}, ваше ХП - {player.HP}");
                            break;
                    }
                    
                }
                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"Победа, {enemy.EnemyName} сгинул");
                    player.PrintInfo();
                    return;
                }
                if (!player.IsAlive)
                {
                    Console.WriteLine($"Поражение, ты слаб");
                    EndGame(player);
                    //player.PrintInfo();
                    return;
                }

            }

            public void BossFight()
            {

            }

            public void Event(Random random, Player Mainplayer, List<Weapon> weapons, List<Armor> armors)
            {
                Console.Write("Сундук, а в нем...");
                int choice = random.Next(1, 3);
                switch (choice) 
                {
                    case 1:
                        Mainplayer.HP = Mainplayer.basehp;
                        Console.WriteLine($"Лечебное зелье, ваше здоровье пополнено до максимума - {Mainplayer.HP}");
                        break;
                    case 2:
                        {
                            int weaponchoice = random.Next(5);
                            Console.Write($"Оружие: {weapons[weaponchoice].WeaponName} - {weapons[weaponchoice].AttackFactor}");
                            Console.WriteLine($"Ваше текущее: {Mainplayer.Player_weapon.WeaponName} - {Mainplayer.Player_weapon.AttackFactor}");
                            Console.WriteLine("1.Поднять");
                            Console.WriteLine("2.Оставить");
                            int player_choice = Convert.ToInt32(Console.ReadLine());
                            if (player_choice == 1) Mainplayer.Player_weapon = weapons[weaponchoice];
                            else return;
                            break;
                        }
                        
                    case 3:
                        {
                            int armorchoice = random.Next(5);
                            Console.Write($"Броня: {armors[armorchoice].ArmorName} - {armors[armorchoice].DefenseFactor}");
                            Console.WriteLine($"Ваше текущее: {Mainplayer.Player_armor.ArmorName} - {Mainplayer.Player_armor.DefenseFactor}");
                            Console.WriteLine("1.Поднять");
                            Console.WriteLine("2.Оставить");
                            int player_choice = Convert.ToInt32(Console.ReadLine());
                            if (player_choice == 1) Mainplayer.Player_armor = armors[armorchoice];
                            else return;
                            break;
                        }
                        
                }

            }

            public void EndGame(Player Mainplayer)
            {
                if (!Mainplayer.IsAlive) {
                    Console.WriteLine("Вы бездарь и умерли");    
                    return; 
                }
                else if (turn > 50)
                {
                    Console.WriteLine("Игра закончилась, вы достигли последнего хода");
                    return;
                }
            }
        }

        



        static void Main(string[] args)
        {
            Random random = new();
            Game game = new Game();
            game.Start(random);
        }
    }
}
