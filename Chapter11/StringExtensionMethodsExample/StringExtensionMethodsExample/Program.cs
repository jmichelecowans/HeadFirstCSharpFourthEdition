using System;
using StringExtensionMethodsExample.AmazingExtensions;

namespace StringExtensionMethodsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "Evil clones are wrecking havoc. Help!";
            Console.WriteLine("Is it a distress call? {0}", message.IsDistressCall());
        }
    }
}
