namespace DesignPattern.Visitor
{
    public interface IVisitor
    {
        void SomeNewStuff(ClassA a);

        void SomeNewStuff(ClassB b);
    }
}
