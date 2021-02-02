using System;

namespace DesignPattern.Singleton
{
    public sealed class Singleton_v5 : ISingleton
    {
        static Singleton_v5()
        {
            Console.WriteLine("ctor");
        }

        public static ISingleton Instance 
        { 
            get 
            {
                Console.WriteLine("prop");
                return Nested._instance;
            } 
        }

        private static class Nested
        {
            static Nested()
            {
                Console.WriteLine("Nested ctor");
            }

            internal static readonly ISingleton _instance;
        }
    }
}
