using System;

namespace ServerProject
{
    public class GuessNumber
    {
        private int number;
        public GuessNumber()
        {
            number = new Random().Next(10);
        }
        public void setNewNumber()
        {
            this.number =new Random().Next(10);
        }
        public int getNumber()
        {
            return this.number;
        }
    }
}