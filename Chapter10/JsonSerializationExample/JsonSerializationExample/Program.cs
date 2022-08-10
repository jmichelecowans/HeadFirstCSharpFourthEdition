using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonSerializationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var guys = new List<Guy>() {
                new Guy() { Name = "Bob", Clothes = new Outfit() { Top = "t-shirt", Bottom = "jeans" },
                    Hair = new HairStyle() { Color = HairColor.Red, Length = 3.5f } },
                new Guy() { Name = "Joe", Clothes = new Outfit() { Top = "polo", Bottom = "slacks" },
                    Hair = new HairStyle() { Color = HairColor.Gray, Length = 2.7f } },
            };

            var options = new JsonSerializerOptions() { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(guys, options);
            Console.WriteLine(jsonString);

            var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);

            foreach (var guy in copyOfGuys)
                Console.WriteLine("I deserialized this guy: {0}", guy);

            var dudes = JsonSerializer.Deserialize<Stack<Dude>>(jsonString);
            while (dudes.Count > 0)
            {
                var dude = dudes.Pop();
                Console.WriteLine($"Next dude: {dude.Name} with {dude.Hair} hair");
            }

            Console.WriteLine();
            Console.WriteLine(JsonSerializer.Serialize(3)); // 3
            Console.WriteLine(JsonSerializer.Serialize((long)-3)); // -3
            Console.WriteLine(JsonSerializer.Serialize((byte)0)); // 0
            Console.WriteLine(JsonSerializer.Serialize(float.MaxValue)); //  3.4028235E+38
            Console.WriteLine(JsonSerializer.Serialize(float.MinValue)); // -3.4028235E+38
            Console.WriteLine(JsonSerializer.Serialize(true)); // true
            Console.WriteLine(JsonSerializer.Serialize("Elephant")); // "Elephant"
            Console.WriteLine(JsonSerializer.Serialize("Elephant".ToCharArray())); // ["E","l","e","p","h","a","n","t"]
            Console.WriteLine(JsonSerializer.Serialize(" ")); // " "
        }
    }
}
