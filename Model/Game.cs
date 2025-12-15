using ISIP523_Kosarikov.Model;
using ISIP523_Kosarikov.Model.Bosses;
using ISIP523_Kosarikov.Model.EnemyFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov
{
    public class Game
    {
        public int turn = 1;
        private readonly Random _random;
        private readonly SimpleEnemyFactory _enemyFactory;

        public Game(Random random)
        {
            _random = random;
            _enemyFactory = new SimpleEnemyFactory();
        }

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

        public void Start()
        {
            List<Weapon> weapons = CreateWeapons();
            List<Armor> armors = CreateArmors();
            Console.WriteLine("Добро пожаловать в игру, сделанную на коленке в 3 часа ночи. Игра кончается на 50 ходу или после смерти игрока");
            Weapon weapon0 = new("кулаки", 1);
            Armor armor0 = new("пайта", 1);
            Player Mainplayer = new(150.0, 20.0, 10.0, weapon0, armor0);

            while (Mainplayer.IsAlive && turn <= 50)
            {
                Console.WriteLine($"### Ход - {turn} ###");
                int randchoice = _random.Next(1, 3);
                if (turn % 10 != 0)
                {
                    switch (randchoice)
                    {
                        case 1:
                            Event(Mainplayer, weapons, armors);
                            break;
                        case 2:
                            Fight(Mainplayer);
                            break;
                    }
                }
                else
                {
                    BossFight(Mainplayer);
                }
                turn++;
                Console.WriteLine("");
            }

            if (!Mainplayer.IsAlive || turn > 50)
            {
                EndGame(Mainplayer);
            }
        }

        public void Fight(Player player)
        {
            Enemy enemy = _enemyFactory.CreateRandomEnemy(_random);
            Console.WriteLine($"Перед вами {enemy.EnemyName}");

            while (enemy.IsAlive && player.IsAlive)
            {
                Console.WriteLine($"ХП врага - {enemy.HP}, ваше ХП - {player.HP}");
                if (!player.isFrized)
                {
                    Console.Write("Можете атаковать(1) или защищаться(2). Что выберете? ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            enemy.HP -= (player.Attack() > enemy.Defense_value) ? player.Attack() : 0;
                            enemy.Enemy_Attack(_random, player, false);
                            break;
                        case 2:
                            enemy.Enemy_Attack(_random, player, true);
                            enemy.HP -= (player.Attack() > enemy.Defense_value) ? (player.Attack() * 0.5) : 0;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вас заморозили, скип");
                    enemy.Enemy_Attack(_random, player, true);
                    player.isFrized = false;
                    continue;
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
                Console.WriteLine($"Поражение, слабость");
                return;
            }
        }

        public void BossFight(Player player)
        {
            Enemy boss = _enemyFactory.CreateBoss(_random);

            // Определяем имя босса
            string bossName = boss switch
            {
                BBG => "ВВГ (Усиленный Гоблин)",
                Kovalski => "Ковальский (Усиленный Скелет)",
                ArchiWizard => "Архимаг C++ (Усиленный Маг)",
                Pestov => "Пестов С-- (Особый Скелет)",
                Slime => "Король Слизней",
                _ => "Неизвестный босс"
            };

            Console.WriteLine(bossName);

            while (boss.IsAlive && player.IsAlive)
            {
                Console.WriteLine($"ХП босса - {boss.HP}, ваше ХП - {player.HP}");
                if (!player.isFrized)
                {
                    Console.Write("Можете атаковать(1) или защищаться(2). Что выберете? ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            boss.HP -= player.Attack();
                            boss.Enemy_Attack(_random, player, false);
                            break;
                        case 2:
                            boss.Enemy_Attack(_random, player, true);
                            boss.HP -= (player.Attack() * 0.5);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вас заморозили, скип");
                    player.isFrized = false;
                    boss.Enemy_Attack(_random, player, true);
                    continue;
                }
            }

            if (!boss.IsAlive)
            {
                Console.WriteLine($"Победа, босс {boss.EnemyName} сгинул");
                player.PrintInfo();
                return;
            }
            if (!player.IsAlive)
            {
                Console.WriteLine($"Поражение, слабость");
                return;
            }
        }

        public void Event(Player Mainplayer, List<Weapon> weapons, List<Armor> armors)
        {
            Console.Write("Сундук, а в нем... ");
            int choice = _random.Next(1, 4);
            switch (choice)
            {
                case 1:
                    Mainplayer.HP = Mainplayer.basehp;
                    Console.WriteLine($"Лечебное зелье, ваше здоровье пополнено до максимума - {Mainplayer.HP}");
                    break;
                case 2:
                    {
                        int weaponchoice = _random.Next(5);
                        Console.WriteLine($"Оружие: {weapons[weaponchoice].WeaponName} - {weapons[weaponchoice].AttackFactor}");
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
                        int armorchoice = _random.Next(5);
                        Console.WriteLine($"Броня: {armors[armorchoice].ArmorName} - {armors[armorchoice].DefenseFactor}");
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
            if (!Mainplayer.IsAlive)
            {
                Console.WriteLine("Вы бездарь и умерли");
                Console.WriteLine($"Прожито ходов: {turn}");
                return;
            }
            else if (turn > 50)
            {
                Console.WriteLine("Игра закончилась, вы достигли последнего хода");
                return;
            }
        }
    }
}
