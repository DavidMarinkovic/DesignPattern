using System;

namespace DesignPattern.Prototype
{
    public class ConcreteClassA : IPrototype
    {
        public string Code { get; set; }
        public Guid Id { get; set; }
        public object reference2Somewhat { get; set; }

        public IPrototype Clone()
        {
            var res = (ConcreteClassA)this.MemberwiseClone();
            res.reference2Somewhat = new object();
            res.Id = new Guid(res.Id.ToString());
            return (IPrototype)res;
        }
    }
}
