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
                if (random.Next(100) <= 40) return true;
                else return false;
            }

            


        }

        class Enemy : Character
        {
            public string EnemyName;

            public Enemy(int hp, int attack, int defense) : base(hp, attack, defense) { }

            
        }

        class BBG : Enemy 
        {
            public BBG(int hp, int attack, int defense) : base(hp, attack, defense) { }
        }

        class ArchiWizard : Enemy
        {
            public ArchiWizard(int hp, int attack, int defense) : base(hp, attack, defense) { }
        }

        class Kovalski : Enemy
        {
            public Kovalski(int hp, int attack, int defense) : base(hp, attack, defense) { }
        }

        class Pestov : Enemy
        {
            public Pestov(int hp, int attack, int defense) : base(hp, attack, defense) { }
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
            Random random = new Random();
            
        }
    }
}
