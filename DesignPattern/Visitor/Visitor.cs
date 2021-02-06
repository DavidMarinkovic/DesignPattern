using System;

namespace DesignPattern.Visitor
{
    public class Visitor : IVisitor
    {
        public void SomeNewStuff(ClassA a)
        {
            Console.WriteLine($"NewStuff-A from {a.Id}");
        }

        public void SomeNewStuff(ClassB b)
        {
            Console.WriteLine($"NewStuff-B from {b.Id}");
        }
    }
}
