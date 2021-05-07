using System;

namespace DesignPattern.CreatePatterns.AbstractFactory
{
    public class Department
    {
    }
    
    public interface IDepartmentRepo
    {
        void CreateDepartment(Department department);
    }

    public class SqlServerDepartmentRepo : IDepartmentRepo
    {
        public void CreateDepartment(Department department)
        {
            Console.WriteLine("Create department in SqlServer");
        }
    }

    public class AccessDepartmentRepo : IDepartmentRepo
    {
        public void CreateDepartment(Department department)
        {
            Console.WriteLine("Create department in Access");
        }
    }
    
    
    public class User
    {
    }
    
    public interface IUserRepo
    {
        void Insert(User user);

        User GetUser(int userId);
    }

    public class SqlServerUserRepo : IUserRepo
    {
        public void Insert(User user)
        {
            Console.WriteLine("insert user in SqlServer");
        }

        public User GetUser(int userId)
        {
            Console.WriteLine("Get user from SqlServer by userId");
            return null;
        }
    }

    public class AccessUserRepo : IUserRepo
    {
        public void Insert(User user)
        {
            Console.WriteLine("insert user in Access");
        }

        public User GetUser(int userId)
        {
            Console.WriteLine("Get user from Access by userId");
            return null;
        }
    }
}