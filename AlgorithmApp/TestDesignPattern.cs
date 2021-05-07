using System;
using System.ComponentModel;
using System.Reflection;
using Autofac;
using DesignPattern.BehaviorPatterns.State;
using DesignPattern.BehaviorPatterns.Strategy;
using DesignPattern.CreatePatterns.AbstractFactory;
using DesignPattern.CreatePatterns.Builder;
using DesignPattern.CreatePatterns.FactoryMethod;
using DesignPattern.CreatePatterns.SimpleFactory;
using DesignPattern.StructurePatterns.Adapter;
using DesignPattern.StructurePatterns.Proxy;
using Newtonsoft.Json;

namespace AlgorithmApp
{
    public class TestDesignPattern
    {
        public static string GetEnumDes(Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false); //获取描述属性
            if (objs == null || objs.Length == 0) //当描述属性没有时，直接返回名称
                return value;
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute) objs[0];
            return descriptionAttribute.Description;
        }

        public static void Main2()
        {
            // TestSimpleFactory();
            // TestStrategy();
            // TestProxy();
            // TestFactoryMethod();
            // TestAbstractFactory();
            // TestState();
            // TestBuilder();
            TestAdapter();
        }

        private static void TestAdapter()
        {
            DriveACarTarget tag = new DriveWLHGAdapter();
            tag.Run();

        }

        private static void TestBuilder()
        {

            GuildBuilder gb = new GuildBuilder();
            GuildDirector gd = new GuildDirector(gb);
            Guild icxlAudit =  gd.CreateAuditGuild("icxl");
            Guild icxlNotAudit =  gd.CreateNotAuditGuild("not audit");
            printObject(icxlAudit);
            printObject(icxlNotAudit);
            var audit2 = gd.UpdateGuildToVip(icxlAudit);
            var notAudit2 = gd.UpdateGuildToVip(gd.AddGuildMoney(icxlNotAudit,300));
            printObject(audit2);
            printObject(notAudit2);
            
            
        }

        private static void printObject(object obj)
        {
            Console.WriteLine(JsonConvert.SerializeObject(obj));
        }

        private static void TestState()
        {
            PluginWork work = new PluginWork(PluginWork.EventType.去打坐);
            work.Run();
            work.SwitchState(PluginWork.EventType.去打怪);
            work.Run();
            work.SwitchState(PluginWork.EventType.去摆摊);
            work.Run();
            work.SwitchState(PluginWork.EventType.去跑图);
            work.Run();
        }

        private static void TestAbstractFactory()
        {
            IDbFactory factory = new AccessFactory();
            var userRepo = factory.CreateUserRepo();
            var deRepo = factory.CreateDepartmentRepo();
            deRepo.CreateDepartment(null);
            userRepo.Insert(null);

            factory = new SqlServerFactory();
            userRepo = factory.CreateUserRepo();
            userRepo.Insert(null);
            
            
            #region AbstractFactory + Reflection

            var departmentRepo = DataAccess.CreateDepartmentRepo();
            departmentRepo.CreateDepartment(null);

            #endregion AbstractFactory + Reflection

            #region AbstractFactory + DependencyInjection

            var builder = new ContainerBuilder();
            builder.RegisterType<SqlServerFactory>().As<IDbFactory>();
            var container = builder.Build();

            var dbFactory = container.Resolve<IDbFactory>();
            dbFactory.CreateDepartmentRepo().CreateDepartment(null);

            #endregion AbstractFactory + DependencyInjection
        }

        private static void TestFactoryMethod()
        {
            ILeifengFactory factory = new UndergraduteFactory();
            var studentLeifeng = factory.CreateLeifeng();
            studentLeifeng.BuyRice();
            var studentLeifeng1 = factory.CreateLeifeng();
            studentLeifeng1.Sweep();

            ILeifengFactory factory2 = new VolunteerFactory();
            var leifengVolun = factory2.CreateLeifeng();
            leifengVolun.Sweep();
        }

        private static void TestProxy()
        {
            Subject proxy = new Proxy(new RealSubject());
            proxy.Request();
        }

        private static void TestStrategy()
        {
            var stragetyArray = new[]
            {
                CashContext.CashContextType.Normal,
                CashContext.CashContextType.EightFold,
                CashContext.CashContextType.MaxReturn
            };
            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                var enumVal = stragetyArray[random.Next(stragetyArray.Length)];
                var cashContext = new CashContext(enumVal);
                var money = random.Next(500);
                Console.WriteLine($"结算方式：{GetEnumDes(enumVal)} ，原价{money}，实际收取：{cashContext.AcceptCash(money)}");
            }
        }

        private static void TestSimpleFactory()
        {
            var oper = OperationFactory.CreateOperation(OperationFactory.OperationType.SUB);
            oper.NumberA = 10;
            oper.NumberB = 6.6;
            Console.WriteLine($"result:{oper.GetResult()}");
        }
    }
}