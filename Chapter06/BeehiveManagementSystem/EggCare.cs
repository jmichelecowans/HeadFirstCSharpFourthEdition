namespace BeehiveManagementSystem
{
    class EggCare : Bee
    {
        private const float CARE_PROGRESS_PER_SHIFT = 0.15f;

        private readonly Queen queen;

        public EggCare(Queen queen) : base("Egg Care")
        {
            CostPerShift = 1.35f;
            this.queen = queen;
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
