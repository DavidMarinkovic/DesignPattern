using DesignPattern.Prototype;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPatternUnitTest
{
    [TestClass]
    public class UnitTestPrototype
    {
        [TestMethod]
        public void TestPrototype()
        {
            var protoManager = new PrototypeManager();

            protoManager["reference-A"] = new ConcreteClassA() { Code = "A", Id = Guid.NewGuid(), reference2Somewhat = new object()};
            var refB = (ConcreteClassA)protoManager["reference-A"].Clone();
            refB.Code = "whatever";
            var refA = (ConcreteClassA)protoManager["reference-A"];
            
            Assert.AreEqual(refB.Id.ToString(), refA.Id.ToString());
            Assert.AreEqual(refB.Id, refA.Id);
            Assert.AreNotEqual(refB.reference2Somewhat, refA.reference2Somewhat);
        }
    }
}
