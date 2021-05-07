namespace DesignPattern.CreatePatterns.SimpleFactory
{
    /// <summary>
    /// 减法
    /// </summary>
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
}