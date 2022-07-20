using System;

namespace LinqDeferredEvaluation
{
    class PrintWhenGetting
    {
        private int instanceNumber;

        public int InstanceNumber
        {
            get
            {
                Console.WriteLine($"Getting #{instanceNumber}");
                return instanceNumber;
            }
            set { instanceNumber = value; }
        }
    }
}
