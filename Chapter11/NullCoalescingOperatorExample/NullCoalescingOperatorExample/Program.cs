using System;
using System.IO;

#nullable enable
namespace NullCoalescingOperatorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using var stringReader = new StringReader("");
            var nextLine = stringReader.ReadLine() ?? string.Empty;
            Console.WriteLine("Line length is: {0}", nextLine.Length);
        }
    }
}
