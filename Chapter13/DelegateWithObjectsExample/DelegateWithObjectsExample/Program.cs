using System;

namespace DelegateWithObjectsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Adrian adrian = new();
            Harper harper = new();
            GetSecretIngredient addIngredientMethod = null;

            while (true)
            {
                Console.Write("Enter A for Adrian, H for Harper, or an amount: ");
                var line = Console.ReadLine();

                switch (line)
                {
                    case "A":
                        Console.WriteLine("Selected Adrian");
                        addIngredientMethod = adrian.MySecretIngredientMethod;
                        break;
                    case "H":
                        Console.WriteLine("Selected Harper");
                        addIngredientMethod = harper.HarpersSecretIngredientMethod;
                        break;
                    default:
                        if (int.TryParse(line, out int amount))
                        {
                            if (addIngredientMethod is null)
                                Console.WriteLine("Please select a chef!");
                            else
                                Console.WriteLine(addIngredientMethod(amount));
                        }
                        else
                        {
                            return;
                        }
                        break;
                }
            }
        }
    }
}
