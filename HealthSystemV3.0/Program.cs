﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemV3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTest test = new UnitTest();
            test.RunUnitTest();
            Console.ReadKey(true);
        }
    }
}
