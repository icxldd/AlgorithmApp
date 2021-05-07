using System;

namespace DesignPattern.StructurePatterns.Proxy
{
    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("request from real subject");
        }
    }

    public class Proxy : Subject
    {
        private readonly Subject _subject;
        public Proxy(Subject subject) => _subject = subject;
        public override void Request()
        {
            Console.WriteLine("代理请求");
            _subject.Request();
        }
    }
}