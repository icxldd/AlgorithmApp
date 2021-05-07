namespace DesignPattern.CreatePatterns.SimpleFactory
{
    /// <summary>
    /// 除法
    /// </summary>
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            return NumberA / NumberB;
        }
    }
}