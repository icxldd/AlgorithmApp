namespace DesignPattern.BehaviorPatterns.Strategy
{
    /// <summary>
    /// 正常收钱
    /// </summary>
    public class CashNormal : AbstractCash
    {
        public override double AcceptCash(double money)
        {
            return money;
        }
    }
}