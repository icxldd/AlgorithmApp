namespace DesignPattern.CreatePatterns.FactoryMethod
{
    public class VolunteerFactory : ILeifengFactory
    {
        public Leifeng CreateLeifeng()
        {
            return new Volunteer();
        }
    }
}