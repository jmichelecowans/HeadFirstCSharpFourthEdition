using System;
using System.IO;

#nullable enable
namespace NullAssignmentOperatorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using var stringReader = new StringReader("");
            var nextLine = stringReader.ReadLine();
            nextLine ??= string.Empty; // If it is null, the operator assigns the value
            Console.WriteLine("Line length is: {0}", nextLine.Length);
        }
    }
}
