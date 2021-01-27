using System;
using System.Collections.Generic;

namespace TestExercise
{
    public class Student:Role,IRole
    {
        private int salary;
        private LinkedList<IPerson> persons;
        public Student(int salary)
        {
            this.salary = salary;
            this.persons = new LinkedList<IPerson>();
        }

        public void AddPerson(IPerson person)
        {
            this.persons.AddFirst(person);
        }

        public string GetRoleType()
        {
            return "Student";
        }

        public string ShowAll()
        {
            string s = "";
            foreach(IPerson p in this.persons)
            {
                s = p.GetName() + "," + s;
            }
            return s;
        }

        public void RemovePerson(IPerson person)
        {
            try { this.persons.Remove(person); }
            catch (Exception) { };
        }
        public int GetSalary()
        {
            return this.salary;
        }
    }
}