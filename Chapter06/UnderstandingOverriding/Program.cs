﻿using System;

namespace UnderstandingOverriding
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new AnimalFeedVendingMachine();
            Console.WriteLine(vendingMachine.Dispense(2.00M));
        }
    }
}
