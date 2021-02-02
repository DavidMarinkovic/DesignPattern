using System;

namespace DesignPattern.Singleton
{
    public sealed class Singleton_v6 : ISingleton
    {
        private static readonly Lazy<ISingleton> lazy = new Lazy<ISingleton>(() => new Singleton_v6());

        public static ISingleton Instance
        {
            get
            {
                Console.WriteLine("prop");
                return lazy.Value;
            }
        }

        private Singleton_v6()
        {
            Console.WriteLine("ctor");
        }
    }
}
