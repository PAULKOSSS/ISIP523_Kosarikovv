using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Kosarikov.Model
{
    public class Player : Character
    {
        private Weapon _player_weapon;
        private Armor _player_armor;
        private double _base_attack;
        private double _base_defense;

        public bool isFrized = false;
        public double basehp = 150;

        public Weapon Player_weapon
        {
            get => _player_weapon;
            set
            {
                _player_weapon = value;
                RecalculateStats();
            }
        }

        public Armor Player_armor
        {
            get => _player_armor;
            set
            {
                _player_armor = value;
                RecalculateStats();
            }
        }

        public Player(double hp, double attack, double defense, Weapon weapon, Armor armor)
            : base(hp, attack, defense)
        {
            _base_attack = attack;
            _base_defense = defense;
            _player_weapon = weapon;
            _player_armor = armor;
            RecalculateStats();
        }

        private void RecalculateStats()
        {
            Attack_value = _base_attack * _player_weapon.AttackFactor;
            Defense_value = _base_defense * _player_armor.DefenseFactor;
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
}
