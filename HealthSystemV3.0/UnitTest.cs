using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3._0
{
    class UnitTest
    {
        public void RunUnitTest()
        {
            Player uTestPlayer = new Player();
            Enemy uTestEnemy = new Enemy();
            uTestPlayer.UnitTest();
            uTestEnemy.UnitTest();
        }
    }
}
