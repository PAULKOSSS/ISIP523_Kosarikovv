namespace Pr6
{
    class Programm
    {
        public class Character
        {
            public int HP;
            public double Attack_value;
            public double Defense_value;

            public Character(int hp, int attack, int defense)
            {
                HP = hp;
                Attack_value = Convert.ToDouble(attack);
                Defense_value = Convert.ToDouble(defense);
            }
        }

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

        class Player : Character 
        {
            public Weapon Player_weapon;
            public Armor Player_armor;

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

            public void Defense()
            {
                bool 
            }

            public void PickUpItem()
            {

            }


        }

        class Enemy : Character
        {
            

            public Enemy(int hp, int attack, int defense) : base(hp, attack, defense) { }


        }

        class Game
        {
            public int turn = 0;

            public void Fight()
            {

            }

            public void Event()
            {

            }
        }

        



        static void Main(string[] args)
        {
            Random random = new Random();
            Dictionary<string, double> weapons = new Dictionary<string, double>() { {"Безоружный", 1 }, {"Меч", 1.3 }, {"Рапира", 1.6 }, {"Боевой топор", 1.7 }, {"Алебарда", 1.8 } };
            Dictionary<string, double> armors = new Dictionary<string, double>() { { "Без брони", 1 }, { "Кольчуга", 1.4 }, { "Кожаная броня", 1.2 }, { "Латы", 1.6 } };
        }
    }
}
