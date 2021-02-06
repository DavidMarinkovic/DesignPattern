using System;

namespace DesignPattern.Visitor
{
    public interface IClassA 
    {
        void DoSomeStuffA();
    }

    public interface IClassB 
    {
        void DoSomeStuffB();
    }
    
    /// <summary>
    /// This is a class we cannot modify or we don't want to modify
    /// </summary>
    public class ClassA : IClassA, IVisitable
    {
        public string Id { get; set; }
        
        public ClassA(string id)
        {
            Id = id;
        }
        
        public void DoSomeStuffA()
        {
            Console.WriteLine("Stuff-A");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.SomeNewStuff(this);
        }
    }

    /// <summary>
    /// This is a class we cannot modify or we don't want to modify
    /// </summary>
    public class ClassB : IClassB, IVisitable
    {
        public string Id { get; set; }

        public ClassB(string id)
        {
            Id = id;
        }

        public void DoSomeStuffB()
        {
            Console.WriteLine("Stuff-B");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.SomeNewStuff(this);
        }
    }
}
