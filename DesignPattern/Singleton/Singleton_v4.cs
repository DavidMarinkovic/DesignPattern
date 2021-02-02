using System;

namespace DesignPattern.Singleton
{
    public sealed class Singleton_v4 : ISingleton
    {
        private static readonly ISingleton _instance = new Singleton_v4();

        static Singleton_v4()
        {
            Console.WriteLine("static ctor");
        }

        private Singleton_v4()
        {
            Console.WriteLine("ctor");
        }

        public static ISingleton Instance
        {
            get
            {
                Console.WriteLine("prop");
                return _instance;
            }
        }
    }
}
