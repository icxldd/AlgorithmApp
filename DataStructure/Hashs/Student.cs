using System.Collections;

namespace DataStructure.Hashs
{
    public class Student
    {
        public int Grade { get; set; }

        public int Cls { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Student(int grade, int cls, string firstName, string lastName)
        {
            Grade = grade;
            Cls = cls;
            FirstName = firstName;
            LastName = lastName;
        }


        public override int GetHashCode()
        {
            int B = 31;
            int hash = 0;
            hash = hash * B + Grade;
            hash = hash * B + Cls;
            hash = hash * B + FirstName.GetHashCode();
            hash = hash * B + LastName.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
            {
                return true;
            }

            if (obj == null)
            {
                return false;
            }

            Student otherStudent = (Student) obj;
            return otherStudent.Cls == this.Cls && otherStudent.Grade == this.Grade &&
                   otherStudent.FirstName.ToLower().Equals(this.FirstName.ToLower()) &&
                   otherStudent.LastName.ToLower().Equals(this.LastName.ToLower());
        }
    }
}