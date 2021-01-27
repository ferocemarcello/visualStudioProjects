using System;

namespace TestExercise
{
    public class Cource
    {
        private int year;
        private string name;
        private string room;

        public Cource(int year, string name, string room)
        {
            this.year = year;
            this.name = name;
            this.room = room;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetRoom()
        {
            return this.room;
        }

        public int GetYear()
        {
            return this.year;
        }
    }
}