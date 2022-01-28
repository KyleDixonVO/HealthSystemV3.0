using System;

namespace HealthSystemV3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTest test = new UnitTest();
            test.RunUnitTest();
            Player player = new Player();
            player.ShowStats();
            Enemy enemy = new Enemy();
            enemy.ShowStats();
            Console.ReadKey(true);
        }
    }
}
