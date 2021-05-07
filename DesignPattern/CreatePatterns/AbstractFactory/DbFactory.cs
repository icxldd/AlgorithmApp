namespace DesignPattern.CreatePatterns.AbstractFactory
{
    public interface IDbFactory
    {
        IUserRepo CreateUserRepo();

        IDepartmentRepo CreateDepartmentRepo();
    }

    public class SqlServerFactory : IDbFactory
    {
        public IUserRepo CreateUserRepo()
        {
            return new SqlServerUserRepo();
        }

        public IDepartmentRepo CreateDepartmentRepo()
        {
            return new SqlServerDepartmentRepo();
        }
    }

    public class AccessFactory : IDbFactory
    {
        public IUserRepo CreateUserRepo()
        {
            return new AccessUserRepo();
        }

        public IDepartmentRepo CreateDepartmentRepo()
        {
            return new AccessDepartmentRepo();
        }
    }
}
