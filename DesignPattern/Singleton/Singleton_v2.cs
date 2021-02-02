using System;

namespace DesignPattern.Singleton
{
    public sealed class Singleton_v2 : ISingleton
    {
        private static ISingleton _instance = null;
        private static readonly object verrou = new object();

        private Singleton_v2()
        {
            Console.WriteLine("ctor");
        }

        public static ISingleton Instance
        {
            get
            {
                Console.WriteLine("prop");
                lock (verrou)
                {
                    if (_instance == null)
                        _instance = new Singleton_v2();

                    return _instance;
                }
            }
        }
    }
}
