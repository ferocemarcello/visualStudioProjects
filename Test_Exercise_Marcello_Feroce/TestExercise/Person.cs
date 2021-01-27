using System;
using System.Collections.Generic;

namespace TestExercise
{
    public class Person:IPerson
    {
        protected string name;
        protected string type;
        protected int age;
        private LinkedList<Cource> cources;
        private IRole role;

        public Person(string name,int age,IRole role)
        {
            this.name = name;
            this.age = age;
            this.cources = new LinkedList<Cource>();
            this.role = role;
        }

        public void Add(Cource c)
        {
            this.cources.AddFirst(c);
        }

        public string AgeRange()
        {
            if (this.age > 0 && this.age <= 12) return "Kid";
            if (this.age > 12 && this.age <= 19) return "Teenager";
            if (this.age > 19 && this.age <= 29) return "Young";
            else return "Old";
        }

        public void Add(int year, string name, string room)
        {
            Cource c = new Cource(year, name, room);
            this.Add(c);
        }
        public string PrintAll()
        {
            string s=(this.name==null?"":this.name )+ " - "+(this.type == null ? "" : this.type) + " - "+this.age;
            return s;
        }

        public void AssignRole(IRole role)
        {
            if(this.role!=null)this.role.RemovePerson(this);
            this.role = role;
            role.AddPerson(this);
        }

        public string GetRole()
        {
            return this.role.GetRoleType();
        }

        public string GetName()
        {
            return this.name;
        }
    }
}