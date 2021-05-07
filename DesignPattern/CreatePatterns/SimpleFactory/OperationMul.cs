namespace DesignPattern.CreatePatterns.SimpleFactory
{
    /// <summary>
    /// 乘法
    /// </summary>
    public class OperationMul : Operation
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
}