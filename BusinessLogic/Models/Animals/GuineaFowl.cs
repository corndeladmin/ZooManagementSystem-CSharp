using System;

namespace Zoo.BusinessLogic.Models.Animals
{
  public class GuineaFowl : Animal, ICanBeGroomed, ISmallAnimal
  {
    private DateTime lastGroomed;

    public GuineaFowl(DateTime dateOfBirth) : base(dateOfBirth)
    {
    }

    public override void Feed()
    {
      Console.WriteLine("<Cluck, Cluck>");
      base.Feed();
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