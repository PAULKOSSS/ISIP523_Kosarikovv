namespace Pr6
{
    class Programm
    {
        public class Character
        {
            public int HP;
            public int Attack_value;
            public int Defense_value;

            public Character(int hp, int attack, int defense)
            {
                HP = hp;
                Attack_value = attack;
                Defense_value = defense;
            }
        }

        class Weapon
        {
            public string WeaponName;
            public float AttackFactor;
        }

        class Armor
        {
            public string ArmorName;
            public float DefenseFactor;
        }

        class Player : Character 
        {
            public Weapon Player_weapon;
            public Armor Player_armor;

            public Player(int hp, int attack, int defense, Weapon weapon, Armor armor) 
                :base (hp, attack, defense)
            {
                Player_weapon = weapon;
                Player_armor = armor;
            }

            public void Attack()
            {

            }

            public void Defense()
            {

            }

            public void PickUpItem()
            {

            }
        }

        static void Main(string[] args)
        {

        }
    }
}
