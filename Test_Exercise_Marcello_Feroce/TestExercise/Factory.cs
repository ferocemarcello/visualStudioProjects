using System;
using System.Collections.Generic;
using TestExercise;

namespace TestExercise
{
    public class Factory
    {
        private static LinkedList<IRole> roles = new LinkedList<IRole>();
        private static bool ContainingRole(IRole role)
        {
            LinkedList<IRole>.Enumerator en = roles.GetEnumerator();
            en.MoveNext();
            foreach(IRole irole in roles)
            {
                if (irole.GetRoleType().Equals(role.GetRoleType()) && (irole.GetSalary() == role.GetSalary()))
                {
                    return true;
                }
            }
            return false;
        }
        public static IPerson CreateIPerson(string capitalType, string name, int age, int salary)
        {
            
            IRole role;
            if (capitalType.Equals("T"))
            {
                role = new Teacher(salary);
            }
            else
            {
                if (capitalType.Equals("S")) role = new Student(salary);
                else throw new Exception();
            }
            IPerson p = new Person(name, age,role);
            if (!Factory.ContainingRole(role))
            {
                roles.AddFirst(role);
            }
            p.AssignRole(role);
            return p;
        }
    }
}