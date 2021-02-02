using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DesignPatternUnitTest
{
    [TestClass]
    public class UnitTestSingleton
    {
        [TestMethod]
        [DataRow("Singleton_v1")]
        [DataRow("Singleton_v2")]
        [DataRow("Singleton_v3")]
        [DataRow("Singleton_v4")]
        [DataRow("Singleton_v5")]
        [DataRow("Singleton_v6")]
        public void SingletonTestSingleCall(string className)
        {
            var aType = Type.GetType($"DesignPattern.Singleton.{className}, DesignPattern");

            if (aType == null)
                throw new Exception("Unknown type");

            var originalConsoleOut = Console.Out;

            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    PropertyInfo propInfo = aType.GetProperty("Instance");
                    var methInfos = propInfo.GetAccessors().First();
                    var singleton1 = methInfos.Invoke(aType, null);
                    var singleton2 = methInfos.Invoke(aType, null);
                    var singleton3 = methInfos.Invoke(aType, null);
                    writer.Flush();
                    var strCallStack = writer.GetStringBuilder().ToString();
                    var nbrCtor = strCallStack.Split(Environment.NewLine).Count(c => String.Equals(c, "ctor", StringComparison.InvariantCultureIgnoreCase));
                    var nbrProp = strCallStack.Split(Environment.NewLine).Count(c => String.Equals(c, "prop", StringComparison.InvariantCultureIgnoreCase));

                    Assert.AreEqual(1, nbrCtor);
                    Assert.AreEqual(3, nbrProp);
                }
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }
        }

        [TestMethod]
        [DataRow("Singleton_v1")]
        [DataRow("Singleton_v2")]
        [DataRow("Singleton_v3")]
        [DataRow("Singleton_v4")]
        [DataRow("Singleton_v5")]
        [DataRow("Singleton_v6")]
        public void SingletonTestThreadCall(string className)
        {
            var aType = Type.GetType($"DesignPattern.Singleton.{className}, DesignPattern");

            if (aType == null)
                throw new Exception("Unknown type");

            var originalConsoleOut = Console.Out;

            try
            {
                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    Parallel.For(1, 21, (i, state) => {
                        PropertyInfo propInfo = aType.GetProperty("Instance");
                        var methInfos = propInfo.GetAccessors().First();
                        var singleton = methInfos.Invoke(aType, null);
                    });

                    var strCallStack = writer.GetStringBuilder().ToString();
                    var nbrCtor = strCallStack.Split(Environment.NewLine).Count(c => String.Equals(c, "ctor", StringComparison.InvariantCultureIgnoreCase));
                    var nbrProp = strCallStack.Split(Environment.NewLine).Count(c => String.Equals(c, "prop", StringComparison.InvariantCultureIgnoreCase));

                    writer.Flush();
                    Assert.AreEqual(1, nbrCtor);
                    Assert.AreEqual(20, nbrProp);
                }
            }
            finally
            {
                Console.SetOut(originalConsoleOut);
            }
        }
    }
}
