namespace DesignPattern.CreatePatterns.SimpleFactory
{
    /// <summary>
    /// 加法
    /// </summary>
    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
}