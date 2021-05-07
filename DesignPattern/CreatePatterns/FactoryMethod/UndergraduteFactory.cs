namespace DesignPattern.CreatePatterns.FactoryMethod
{
    public class UndergraduteFactory : ILeifengFactory
    {
        public Leifeng CreateLeifeng()
        {
            return new Undergradute();
        }
    }
}