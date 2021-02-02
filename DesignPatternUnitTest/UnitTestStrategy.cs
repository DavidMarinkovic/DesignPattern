using DesignPattern.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPatternUnitTest
{
    [TestClass]
    public class UnitTestStrategy
    {
        [TestMethod]
        [DataRow("ConcreteStrategyA")]
        [DataRow("ConcreteStrategyB")]
        public void CallDifferentConcreteStrategy(string className)
        {
            var aType = Type.GetType($"DesignPattern.Strategy.{className}, DesignPattern");
            var strat = (IStrategy)Activator.CreateInstance(aType);
            var ctx = new Context(strat);
            var str = ctx.DoTheJob(null);
            Assert.AreEqual(aType.Name, str);
        }
    }
}
