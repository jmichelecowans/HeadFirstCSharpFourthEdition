 using System;

namespace ImplementingIEnumerabe
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = new EnumSequence<Sport>();
            foreach (var item in sequence)
                Console.WriteLine(item);
        }
    }
}
