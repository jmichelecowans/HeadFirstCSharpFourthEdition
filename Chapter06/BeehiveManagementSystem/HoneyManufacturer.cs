namespace BeehiveManagementSystem
{
    class HoneyManufacturer : Bee
    {
        private const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

        public HoneyManufacturer() : base("Honey Manufacturer")
        {
            CostPerShift = 1.7f;
        }

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
