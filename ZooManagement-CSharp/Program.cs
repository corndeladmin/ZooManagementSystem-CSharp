using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Models;
using Zoo.BusinessLogic.Models.Animals;
using Zoo.BusinessLogic.Services;

namespace Zoo.ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            var largeAnimals = new ILargeAnimal[]
            {
                new Lion(new DateTime(2010, 4, 28)),
                new Lion(new DateTime(2012, 5, 11)),
                new Zebra(new DateTime(2008, 12, 1))
            };
            var smallAnimals = new ISmallAnimal[] {
                new Rabbit(new DateTime(2014, 1, 1)),
                new GuineaFowl(new DateTime(2010, 3, 14))
            };
            var animals = largeAnimals.Union<IAnimal>(smallAnimals).ToList();

            var largeAnimalKeeper = new Keeper<ILargeAnimal>(largeAnimals);
            var smallAnimalKeeper = new Keeper<ISmallAnimal>(smallAnimals);

            var keepers = new IKeeper[]
            {
                largeAnimalKeeper,
                smallAnimalKeeper
            };

            var babyRabbit = new Rabbit(DateTime.Today);
            smallAnimalKeeper.StartLookingAfter(babyRabbit);

            var feedingScheduler = FeedingScheduler.Instance;
            var groomingScheduler = GroomingScheduler.Instance;

            var timer = new ZooTimer();
            new Thread(timer.Run).Start();

            timer.Tick += () => feedingScheduler.AssignFeedingJobs(keepers, animals);
            timer.Tick += () => groomingScheduler.AssignGroomingJobs(keepers, animals);
            timer.Tick += () => animals.ForEach(Console.WriteLine);
        }
    }
}
