using System;
using System.Collections.Generic;

namespace Problem3.HeroesofCodeandLogicVII
{
    class Hero
    {
        private const int MaxHitPoint = 100;
        private const int MaxManaPoints = 100;

        private int manaPoints;
        private int hitPoints;

        public Hero(string name, int hitPoints, int manaPoints)
        {
            this.Name = name;
            this.HitPoints = hitPoints;
            this.ManaPoints = manaPoints;
        }

        public string Name { get; set; }

        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                if (value > MaxHitPoint)
                {
                    throw new ArgumentException("Hit points can't be more than 100");
                }
                hitPoints = value;
            }
        }

        public int ManaPoints
        {
            get { return manaPoints; }
            set
            {
                if (value > MaxManaPoints)
                {
                    throw new ArgumentException("Mana points can't be more than 200");
                }
                manaPoints = value;
            }
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {

            var numberOfHeroes = int.Parse(Console.ReadLine());

            var listHeroes = new List<Hero>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                var heroArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //Hero arguments
                var heroName = heroArgs[0];
                var heroHitPoints = int.Parse(heroArgs[1]);
                var heroManaPoints = int.Parse(heroArgs[2]);

                var hero = new Hero(heroName, heroHitPoints, heroManaPoints);

                listHeroes.Add(hero);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {

                }
            }
        }
    }
}