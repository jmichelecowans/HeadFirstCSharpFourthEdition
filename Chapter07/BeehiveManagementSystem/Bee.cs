namespace BeehiveManagementSystem
{
    abstract class Bee : IWorker
    {
        public string Job { get; }

        public float CostPerShift { get; protected set; }

        public Bee(string job)
        {
            Job = job;
        }

        public void WorkNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }

        protected abstract void DoJob();
    }
}
