namespace DesignPattern.Strategy
{
    public class ConcreteStrategyA : IStrategy
    {
        public string DoSomething(object[] parametres)
        {
            return "ConcreteStrategyA";
        }
    }
}
