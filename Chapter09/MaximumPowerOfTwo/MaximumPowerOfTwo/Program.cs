using System;

namespace MaximumPowerOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var number in new PowersOfTwo())
            {
                Console.Write($"{number} ");
            }
        }
    }
}
