using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3._0
{
    class GameCharacter
    {
        public int defaultHealth = 100;
        public int defaultShield = 100;
        public int health = 100;
        public int shield = 100;
        private int remainder;


        public void TakeDamage(int damage)
        {
            if (damage >= 0)
            {
                remainder = 0;
                shield -= damage;
                if (shield < 0)
                {
                    remainder = shield;
                    shield = 0;
                }

                if (shield == 0)
                {
                    health += remainder;
                    if (health <= 0)
                    {
                        health = 0;
                    }
                }
                    
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Damage must be a positive integer, or zero.");
                Console.ResetColor();
            }
           
        }

        public void ShowStats()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.ResetColor();
            Console.WriteLine("");
        }
        public void Reset()
        {
            health = defaultHealth;
            shield = defaultShield;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reset.");
            Console.ResetColor();
        }
        public void Heal(int HP)
        {   
            if (HP > 2147000000)
            {
                Console.WriteLine("Healing limiter triggered to prevent int overflow.");
                HP = 1000000000;
            }
            if (HP >= 0)
            {
                Console.WriteLine("Incoming healing: " + HP);
                health = health + HP;
                if (health > 100)
                {
                    int excess;
                    excess = health - 100;
                    int amountHealed;
                    amountHealed = HP - excess;
                    Console.WriteLine("Healed for: " + amountHealed);
                    health = 100;
                    Console.WriteLine("Cannot be healed further.");
                }
                else
                {
                    Console.WriteLine("Healed for: " + HP);
                    if (health == 100)
                    {
                        Console.WriteLine("Cannot be healed further.");
                    }
                }
            }
        }

        public void RegenShield(int SP)
        {
            if (SP > 2147000000)
            {
                Console.WriteLine("Regen limiter triggered to prevent int overflow.");
                SP = 1000000000;
            }
            if (SP >= 0)
            {
                Console.WriteLine("Regenerating shield: " + SP);
                shield = shield + SP;
                if (shield > 100)
                {
                    int excess;
                    excess = shield - 100;
                    int amountRegen;
                    amountRegen = SP - excess;
                    Console.WriteLine("Regenerated shield by: " + amountRegen);
                    shield = 100;
                    Console.WriteLine("Cannot be reinforced further.");
                }
                else
                {
                    Console.WriteLine("Regenerated shield by: " + SP);
                    if (shield == 100)
                    {
                        Console.WriteLine("Cannot be reinforced further.");
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("SP must be a positive integer or zero.");
                Console.ResetColor();
            }
        }
    }
}
