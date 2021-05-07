using System;

namespace DesignPattern.CreatePatterns.FactoryMethod
{
    public  class Undergradute : Leifeng
    {
        

        public override void Sweep()
        {
            Console.WriteLine("大学生扫地");
        }

        public override void Wash()
        {
            Console.WriteLine("大学生洗衣");
        }

        public override void BuyRice()
        {
            Console.WriteLine("大学生买米");
        }
    }
}