using System;

namespace NullableValueTypesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            bool? nullableBool = true;
            int? nullableInt = 10;
            Nullable<byte> nullabbleByte = 0b1;
            Nullable<char> nullableChar = 'a';
            Nullable<decimal> nullableDouble = 100m;

            string format = "{0} - HasValue: {1} / GetValueOrDefault: {2}";

            Console.WriteLine(format, nameof(nullableBool), nullableBool.HasValue, nullableBool.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullableInt), nullableInt.HasValue, nullableInt.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullabbleByte), nullabbleByte.HasValue, nullabbleByte.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullableChar), nullableChar.HasValue, nullableChar.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullableDouble), nullableDouble.HasValue, nullableDouble.GetValueOrDefault());

            Console.WriteLine();
            Console.WriteLine("Setting null for nullable value types...");
            Console.WriteLine();
            nullableBool = null;
            nullableInt = null;
            nullabbleByte = null;
            nullableChar = null;
            nullableDouble = null;

            Console.WriteLine(format, nameof(nullableBool), nullableBool.HasValue, nullableBool.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullableInt), nullableInt.HasValue, nullableInt.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullabbleByte), nullabbleByte.HasValue, nullabbleByte.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullableChar), nullableChar.HasValue, nullableChar.GetValueOrDefault());
            Console.WriteLine(format, nameof(nullableDouble), nullableDouble.HasValue, nullableDouble.GetValueOrDefault());
            
            Console.WriteLine();
            Console.WriteLine("Accessing {0}.{1}, which is set to null", nameof(nullableBool), nameof(nullableBool.Value));
            Console.WriteLine();

            try
            {
                Console.WriteLine("{0}",nullableBool.Value);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Threw {0}", e.GetType().FullName);
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}
