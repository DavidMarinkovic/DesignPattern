using System;

namespace DesignPattern.Singleton
{
    public sealed class Singleton_v3 : ISingleton
    {
        private static ISingleton _instance = null;
        private static readonly object verrou = new object();

        private Singleton_v3()
        {
            Console.WriteLine("ctor");
        }

        public static ISingleton Instance
        {
            get
            {
                Console.WriteLine("prop");

                if (_instance == null)
                {
                    lock (verrou)
                    {
                        if (_instance == null)
                            _instance = new Singleton_v3();
                    }
                }
                
                return _instance;
            }
        }
    }
}
