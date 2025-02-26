﻿using System;

namespace FinalizerExample
{
    class EvilClone
    {
        static int CloneCount = 0;

        public int CloneID { get; } = ++CloneCount;

        public EvilClone() => Console.WriteLine("Clone #{0} is wreaking havoc", CloneID);

        ~EvilClone()
        {
            Console.WriteLine("Clone #{0} destroyed", CloneID);
        }
    }
}
