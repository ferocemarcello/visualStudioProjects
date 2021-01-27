using System;
using System.Collections.Generic;

namespace TestExercise
{
    public class ManagementFadace
    {
        private List<Person> persons = new List<Person>();
        public void AddPerson(string capitalType, string name, int age, int salary)
        {
            Factory.CreateIPerson(capitalType,name,age, salary);
            if (capitalType.Equals("T"))
            {
                persons.Add(new Person(name, age,new Teacher(salary)));
            }
            if (capitalType.Equals("S"))
            {
                persons.Add(new Person(name, age,new Student(salary)));
            }

        }

        public List<IPerson> GetAllTeachers()
        {
            List<Person>.Enumerator en = persons.GetEnumerator();
            List<IPerson> ps = new List<IPerson>();
            en.MoveNext();
            while (en.Current != null)
            {
                if (en.Current.GetRole().Equals("Teacher"))
                {
                    ps.Add(en.Current);
                }
                en.MoveNext();
            }
            return ps;
        }
    }
}