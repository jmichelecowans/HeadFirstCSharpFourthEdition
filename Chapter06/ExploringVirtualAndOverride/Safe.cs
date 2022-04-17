namespace ExploringVirtualAndOverride
{
    class Safe
    {
        private readonly string contents = "precious jewels";
        private readonly string safeCombination = "12345";

        public string Open(string combination)
        {
            if (combination == safeCombination) return contents;
            return "";
        }

        public void PickLock(Locksmith lockpicker)
        {
            lockpicker.Combination = safeCombination;
        }
    }
}
