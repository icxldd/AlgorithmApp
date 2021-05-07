namespace DesignPattern.BehaviorPatterns.Strategy
{
    /// <summary>
    /// 结算方式
    /// </summary>
    public abstract class AbstractCash
    {
        /// <summary>
        /// 实际收取金额
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public abstract double AcceptCash(double money);
    }
}