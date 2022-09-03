namespace BeehiveManagementSystem
{
    class NectarCollector : Bee
    {
        private const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

        public NectarCollector() : base("Nectar Collector")
        {
            CostPerShift = 1.95f;
        }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
