using System;

namespace ChainedEventHandlersExample
{
    class Program
    {
        private static int _count;

        static void Main(string[] args)
        {
            var myEvent = new Talker();

            while (true)
            {
                Console.WriteLine("1 - chain SaySomething"
                                  + Environment.NewLine
                                  + "2 - chain SaySomethingElse"
                                  + Environment.NewLine
                                  + "3 - unchain SaySomething"
                                  + Environment.NewLine
                                  + "4 - unchain SaySomethingElse"
                                  + Environment.NewLine
                                  + "or a message");
                var line = Console.ReadLine();

                switch (line?.Trim())
                {
                    case "1":
                        Console.WriteLine("Adding SaySomething");
                        myEvent.TalkToMe += SaySomething;
                        break;
                    case "2":
                        Console.WriteLine("Adding SaySomethingElse");
                        myEvent.TalkToMe += SaySomethingElse;
                        break;
                    case "3":
                        Console.WriteLine("Removing SaySomething");
                        myEvent.TalkToMe -= SaySomething;
                        break;
                    case "4":
                        Console.WriteLine("Removing SaySomethingElse");
                        myEvent.TalkToMe -= SaySomethingElse;
                        break;
                    case "":
                        return;
                    default:
                        _count = 1;
                        Console.WriteLine("Raising the TalkToMe event");
                        myEvent.OnTalkToMe(line);
                        break;
                }
            }
        }

        static void SaySomething(object sender, TalkEventArgs e)
        {
            Console.WriteLine($"Call #{_count++}: I said something: {e.Message}");
        }

        static void SaySomethingElse(object sender, TalkEventArgs e)
        {
            Console.WriteLine($"Call #{_count++}: I said something else: {e.Message}");
        }
    }
}
