using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace UnicodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //File.WriteAllText("eureka.txt", "Eureka!");
            File.WriteAllText("eureka.txt", "שלום", Encoding.Unicode);
            byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");
            foreach (byte b in eurekaBytes)
                Console.Write("{0} ", b);
            Console.WriteLine(Encoding.UTF8.GetString(eurekaBytes));
            foreach (byte b in eurekaBytes)
                Console.Write("{0:x2} ", b);
            Console.WriteLine();
            Console.WriteLine(JsonSerializer.Serialize("🐘"));
            File.WriteAllText("elephant1.txt", "\uD83D\uDC18");
            File.WriteAllText("elephant2.txt", "\U0001F418");

            /*
            File.WriteAllText("eureka_ASCII.txt", "שלום", Encoding.ASCII);
            File.WriteAllText("eureka_BigEndianUnicode.txt", "שלום", Encoding.BigEndianUnicode);
            File.WriteAllText("eureka_Default.txt", "שלום", Encoding.Default);
            File.WriteAllText("eureka_Latin1.txt", "שלום", Encoding.Latin1);
            File.WriteAllText("eureka_Unicode.txt", "שלום", Encoding.Unicode);
            File.WriteAllText("eureka_UTF32.txt", "שלום", Encoding.UTF32);
            File.WriteAllText("eureka_UTF7.txt", "שלום", Encoding.UTF7);
            File.WriteAllText("eureka_UTF8.txt", "שלום", Encoding.UTF8);

            Console.Write("ASCII: "); foreach (byte b in File.ReadAllBytes("eureka_ASCII.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            Console.Write("BigEndianUnicode: "); foreach (byte b in File.ReadAllBytes("eureka_BigEndianUnicode.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            Console.Write("Default: "); foreach (byte b in File.ReadAllBytes("eureka_Default.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            Console.Write("Latin1: "); foreach (byte b in File.ReadAllBytes("eureka_Latin1.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            Console.Write("Unicode: "); foreach (byte b in File.ReadAllBytes("eureka_Unicode.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            Console.Write("UTF32: "); foreach (byte b in File.ReadAllBytes("eureka_UTF32.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            Console.Write("UTF7: "); foreach (byte b in File.ReadAllBytes("eureka_UTF7.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            Console.Write("UTF8: "); foreach (byte b in File.ReadAllBytes("eureka_UTF8.txt")) Console.Write("{0:x2} ", b); Console.WriteLine();
            */
        }
    }
}
