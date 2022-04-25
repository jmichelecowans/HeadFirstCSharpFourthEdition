namespace BeehiveManagementSystem
{
    interface IWorker
    {
        string Job { get; }

        void WorkNextShift();
    }
}
