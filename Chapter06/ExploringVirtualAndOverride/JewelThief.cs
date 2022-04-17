using System;

namespace ExploringVirtualAndOverride
{
    class JewelThief : Locksmith
    {
        private string stolenJewels;

        protected void ReturnContents(string safeContents, SafeOwner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
        }
    }
}
