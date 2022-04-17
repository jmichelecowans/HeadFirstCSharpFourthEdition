using System;
using System.Linq;

namespace BeehiveManagementSystem
{
    class Queen : Bee
    {
        private Bee[] workers = new Bee[0];
        private float unassignedWorkers = 0;
        private float eggs = 0;

        private const float EGGS_PER_SHIFT = 0.45f;
        private const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        public string StatusReport { get; private set; } = "";

        public Queen() : base("Queen")
        {
            CostPerShift = 2.15f;
            unassignedWorkers = 3;
            AddWorker(new NectarCollector());
            AddWorker(new HoneyManufacturer());
            AddWorker(new EggCare(this));
            UpdateStatusReport();
        }

        /// <summary>
        /// Expand the workers array by one slot and add a Bee reference.
        /// </summary>
        /// <param name="worker">Worker to add to the workers array.</param>
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}" + "\n\n" +
                $"Egg count: {eggs}\n" +
                $"Unassigned workers: {unassignedWorkers}\n" +
                $"{WorkerStatus("Nectar Collector")}\n" +
                $"{WorkerStatus("Honey Manufacturer")}\n" +
                $"{WorkerStatus("Egg Care")}\n" +
                $"TOTAL WORKERS: {workers.Length}\n";
        }

        private string WorkerStatus(string job)
        {
            int count = workers.Where(p => p != null && p.Job?.Trim().ToUpper() == job?.Trim().ToUpper()).Count();
            string s = count > 1 ? "s" : string.Empty;
            return $"{count} {job} bee{s}";
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;

            foreach (Bee worker in workers.Where(p => p != null))
            {
                worker.WorkNextShift();
            }

            _ = HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);

            UpdateStatusReport();
        }

        public void AssignBee(string job)
        {
            switch (job?.ToUpper())
            {
                case "NECTAR COLLECTOR":
                    AddWorker(new NectarCollector());
                    break;
                case "EGG CARE":
                    AddWorker(new EggCare(this));
                    break;
                case "HONEY MANUFACTURER":
                    AddWorker(new HoneyManufacturer());
                    break;
                default:
                    break;
            }

            UpdateStatusReport();
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }

            UpdateStatusReport();
        }
    }
}
