using System;

namespace Zoo.BusinessLogic.Models.Animals
{
    public class AnimalThatCanBeGroomed : Animal
    {

      private DateTime lastGroomed;
        public AnimalThatCanBeGroomed(DateTime dateOfBirth) : base(dateOfBirth)
        {
        }

        public void Groom()
    {
      lastGroomed = DateTime.Now;
    }

    public override string ToString()
    {
      return base.ToString() + $"; Last Groomed {lastGroomed}";
    }
    }
}