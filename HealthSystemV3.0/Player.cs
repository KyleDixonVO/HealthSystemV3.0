using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HealthSystemV3._0
{
    class Player : GameCharacter
    {
        public int lives = 3;
        public int defaultLives = 3;
        //public int defaultHealth = 100;
        public bool dead = false;
        private int remainder;

        public new void TakeDamage(int damage)
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
                        Die();
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

        public void Die()
        {
            ShowStats();
            Console.WriteLine("Player lost a life!");
            if (lives > 0)
            {
                Respawn();
            }
            else
            {
                Console.WriteLine("Out Of lives!");
                lives = 0;
                dead = true;
                return;
            }
            lives--;
        }

        public void Respawn()
        {
            health = defaultHealth;
            shield = defaultShield;
            Console.WriteLine("Player respawned!");
        }

        public new void Reset()
        {
            health = defaultHealth;
            shield = defaultShield;
            lives = defaultLives;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reset.");
            Console.ResetColor();
        }

        public void UnitTest()
        {
            DamageTest(50, 100, 100, 3, 100, 50, 3);
            DamageTest(110, 100, 100, 3, 90, 0, 3);
            DamageTest(210, 100, 100, 3, 100, 100, 2);
            DamageTest(int.MaxValue, 1, 0, 3, 100, 100, 2);
            DamageTest(int.MinValue, 100, 100, 3, 100, 100, 3);
            DamageTest(-50, 100, 100, 3, 100, 100, 3);
            DamageTest(200, 1, 0, 0, 0, 0, 0);
            HealTest(50, 33, 0, 3, 83, 0, 3);
            HealTest(100, 100, 0, 3, 100, 0, 3);
            HealTest(int.MaxValue, 100, 0, 3, 100, 0, 3);
            HealTest(int.MaxValue, 1, 0, 3, 100, 0, 3);
            HealTest(int.MinValue, 1, 0, 3, 1, 0, 3);
            HealTest(int.MinValue, 100, 0, 3, 100, 0, 3);
            RegenTest(50, 100, 33, 3, 100, 83, 3);
            RegenTest(50, 100, 100, 3, 100, 100, 3);
            RegenTest(int.MinValue, 100, 100, 3, 100, 100, 3);
            RegenTest(int.MinValue, 100, 0, 3, 100, 0, 3);
            RegenTest(int.MaxValue, 100, 0, 3, 100, 100, 3);
            RegenTest(int.MaxValue, 100, 100, 3, 100, 100, 3);
        }

        public void DamageTest(int damage, int healthValue, int shieldValue, int livesValue, int assertedHealth, int assertedShield, int assertedLives)
        {
            shield = shieldValue;
            health = healthValue;
            lives = livesValue;
            TakeDamage(damage);
            Debug.Assert(health == assertedHealth);
            Debug.Assert(shield == assertedShield);
            Debug.Assert(lives == assertedLives);
        }

        public void HealTest(int HP, int healthValue, int shieldValue, int livesValue, int assertedHealth, int assertedShield, int assertedLives)
        {
            shield = shieldValue;
            health = healthValue;
            lives = livesValue;
            Heal(HP);
            Debug.Assert(health == assertedHealth);
            Debug.Assert(shield == assertedShield);
            Debug.Assert(lives == assertedLives);
        }

        public void RegenTest(int SP, int healthValue, int shieldValue, int livesValue, int assertedHealth, int assertedShield, int assertedLives)
        {
            shield = shieldValue;
            health = healthValue;
            lives = livesValue;
            RegenShield(SP);
            Debug.Assert(health == assertedHealth);
            Debug.Assert(shield == assertedShield);
            Debug.Assert(lives == assertedLives);
        }
    }
}
