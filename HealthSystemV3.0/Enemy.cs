using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HealthSystemV3._0
{
    class Enemy : GameCharacter
    {
        //private int remainder;

        public void UnitTest()
        {
            DamageTest(50, 100, 100, 100, 50);
            DamageTest(125, 100, 100, 75, 0);
            DamageTest(250, 100, 100, 0, 0);
            DamageTest(int.MaxValue, 100, 100, 0, 0);
            DamageTest(int.MaxValue, 1, 0, 0, 0);
            DamageTest(int.MinValue, 100, 100, 100, 100);
            DamageTest(int.MinValue, 1, 0, 1, 0);
            HealTest(50, 22, 100, 72, 100);
            HealTest(50, 100, 100, 100, 100);
            HealTest(int.MaxValue, 100, 100, 100, 100);
            HealTest(int.MaxValue, 1, 100, 100, 100);
            HealTest(int.MinValue, 100, 100, 100, 100);
            HealTest(int.MinValue, 1, 0, 1, 0);
            RegenTest(50, 100, 22, 100, 72);
            RegenTest(50, 100, 100, 100, 100);
            RegenTest(int.MaxValue, 100, 100, 100, 100);
            RegenTest(int.MaxValue, 100, 0, 100, 100);
            RegenTest(int.MinValue, 100, 0, 100, 0);
            RegenTest(int.MinValue, 100, 100, 100, 100);
        }

        public void DamageTest(int damage, int healthValue, int shieldValue, int assertedHealth, int assertedShield)
        {
            shield = shieldValue;
            health = healthValue;
            TakeDamage(damage);
            Debug.Assert(health == assertedHealth);
            Debug.Assert(shield == assertedShield);
        }

        public void HealTest(int HP, int healthValue, int shieldValue, int assertedHealth, int assertedShield)
        {
            shield = shieldValue;
            health = healthValue;
            Heal(HP);
            Debug.Assert(health == assertedHealth);
            Debug.Assert(shield == assertedShield);
        }
        public void RegenTest(int SP, int healthValue, int shieldValue, int assertedHealth, int assertedShield)
        {
            shield = shieldValue;
            health = healthValue;
            RegenShield(SP);
            Debug.Assert(health == assertedHealth);
            Debug.Assert(shield == assertedShield);
        }


    }
}
