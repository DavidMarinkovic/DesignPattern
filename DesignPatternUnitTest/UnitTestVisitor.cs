using DesignPattern.Visitor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DesignPatternUnitTest
{
    [TestClass]
    public class UnitTestVisitor
    {
        [TestMethod]
        public void VisitorInAction()
        {
            var originalConsoleOut = Console.Out;

            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    var lst = new List<IVisitable>()
                    { new ClassA("Mig 15"),
                        new ClassA("Mig 21"),
                        new ClassB("Renault 5"),
                        new ClassA("Mig 25"),
                        new ClassB("Peugeot 403"),
                        new ClassA("Mig 29")
                    };

                    var bag = new VisitableBag(lst);
                    var visitor = new Visitor();

                    bag.ApplyVisitor(visitor);

                    writer.Flush();
                    var strCallStack = writer.GetStringBuilder().ToString();
                    var nbrANewStuffCall = strCallStack.Split(Environment.NewLine).ToList().Count(x => x.StartsWith("NewStuff-A"));
                    var nbrBNewStuffCall = strCallStack.Split(Environment.NewLine).ToList().Count(x => x.StartsWith("NewStuff-B"));

                    Assert.AreEqual(4, nbrANewStuffCall);
                    Assert.AreEqual(2, nbrBNewStuffCall);
                }
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }
        }
    }
}
