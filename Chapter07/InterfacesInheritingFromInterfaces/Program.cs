namespace InterfacesInheritingFromInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            IClown.CarCapacity = 18;
            System.Console.WriteLine(IClown.ClownCarDescription());

            IClown fingersTheClown = new ScaryScary("big red nose", 14);
            fingersTheClown.Honk();

            if (fingersTheClown is IScaryClown iScaryClownReference)
            {
                iScaryClownReference.ScareAdults();
            }
        }
    }
}