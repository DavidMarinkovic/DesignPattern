namespace DesignPattern.Strategy
{
    public class Context
    {
        private IStrategy _strategy;

        public Context()
        {

        }

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public string DoTheJob(object[] parametres)
        {
            return _strategy.DoSomething(parametres);
        }
    }
}
