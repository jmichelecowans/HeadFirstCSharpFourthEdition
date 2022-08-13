using System;

namespace ExtensionMethosExample
{
    sealed class OrdinaryHuman
    {
        private int weight;

        public OrdinaryHuman(int weight)
        {
            this.weight = weight;
        }

        public void GoToWork() { /* code to go to work */ }
        public void PayBills() { /* code to pay bills */ }
    }

    static class AmazeballsSerum
    {
        public static string BreakWalls(this OrdinaryHuman h, double wallDensity)
            => ($"I broke through a wall of {wallDensity} density.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrdinaryHuman steve = new(185);
            Console.WriteLine(steve.BreakWalls(89.2));
        }
    }
}
