using System;

namespace DesignPattern.Singleton
{
    public sealed class Singleton_v1 : ISingleton
    {
        private static ISingleton _instance = null;

        private Singleton_v1()
        {
            Console.WriteLine("ctor");
        }

        public static ISingleton Instance
        {
            get
            {
                Console.WriteLine("prop");

                if (_instance == null)
                    _instance = new Singleton_v1();

                return _instance;
            }
        }
    }
}
