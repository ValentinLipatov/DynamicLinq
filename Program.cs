using System;

namespace DynamicLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DynamicLinq.Invoke<string, bool>("a.Contains(\"Hello\")", "a", "Hello world"));
            Console.ReadKey();
        }
    }
}