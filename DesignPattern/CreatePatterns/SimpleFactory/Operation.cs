namespace DesignPattern.CreatePatterns.SimpleFactory
{
    /// <summary>
    /// 算数操作基类
    /// </summary>
    public abstract class Operation
    {
        public double NumberA { get; set; }

        public double NumberB { get; set; }

        public abstract double GetResult();
    }
}