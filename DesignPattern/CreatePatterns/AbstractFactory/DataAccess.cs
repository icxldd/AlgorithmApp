namespace DesignPattern.CreatePatterns.AbstractFactory
{
    public class DataAccess
    {
        private static readonly string AssemblyName = "DesignPattern.CreatePatterns.AbstractFactory";
        private static readonly string DbName = ConfigurationHelper.AppSetting("DbName");

        public static IUserRepo CreateUserRepo()
        {
            return (IUserRepo)typeof(DataAccess).Assembly.CreateInstance($"{AssemblyName}.{DbName}UserRepo");
        }

        public static IDepartmentRepo CreateDepartmentRepo()
        {
            return (IDepartmentRepo)typeof(DataAccess).Assembly.CreateInstance($"{AssemblyName}.{DbName}DepartmentRepo");
        }
    }

}