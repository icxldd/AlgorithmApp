using System;

namespace DesignPattern.CreatePatterns.FactoryMethod
{
    public  class Volunteer : Leifeng
    {
        public override void Sweep()
        {
            Console.WriteLine("社区志愿者扫地");
        }

        public override void Wash()
        {
            Console.WriteLine("社区志愿者洗衣");
        }

        public override void BuyRice()
        {
            Console.WriteLine("社区志愿者买米");
        }
    }
}