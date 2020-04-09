using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem3.HeroesofCodeandLogicVII
{
    class Hero
    {
        private const int MaxHitPoints = 100;
        private const int MaxManaPoints = 200;

        private int manaPoints;
        private int hitPoints;

        public Hero()
        {
        }

        public Hero(string name, int hitPoints, int manaPoints) : this()
        {
            this.Name = name;
            this.HitPoints = hitPoints;
            this.ManaPoints = manaPoints;
        }

        public string Name { get; private set; }

        public int HitPoints
        {
            get { return hitPoints; }
            private set
            {
                if (value > MaxHitPoints)
                {
                    throw new ArgumentException("Hit points can't be more than 100");
                }
                hitPoints = value;
            }
        }

        public int ManaPoints
        {
            get { return manaPoints; }
            private set
            {
                if (value > MaxManaPoints)
                {
                    throw new ArgumentException("Mana points can't be more than 200");
                }
                manaPoints = value;
            }
        }

        public bool IsDead { get; private set; }

        internal void CastSpell(int mpNeeded, string spellName)
        {
            if (this.ManaPoints >= mpNeeded)
            {
                this.ManaPoints -= mpNeeded;
                Console.WriteLine($"{this.Name} has successfully cast {spellName} and now has {this.ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{this.Name} does not have enough MP to cast {spellName}!");
            }
        }

        internal void TakeDamage(int damage, string attacker)
        {
            if (this.HitPoints > 0 && this.HitPoints > damage)
            {
                this.HitPoints -= damage;

                Console.WriteLine($"{this.Name} was hit for {damage} HP by {attacker} and now has {this.HitPoints} HP left!");
            }
            else
            {
                this.IsDead = true;

                Console.WriteLine($"{this.Name} has been killed by {attacker}!");
            }
        }

        internal void Recharge(int rechargeAmount)
        {
            var currentManaPoints = this.ManaPoints;
            var difference = 0;

            if (rechargeAmount > MaxManaPoints || (currentManaPoints += rechargeAmount) > MaxManaPoints)
            {
                difference = MaxManaPoints - this.ManaPoints;
                this.ManaPoints = MaxManaPoints;
            }
            else
            {
               this.ManaPoints += rechargeAmount;
                difference = rechargeAmount;
            }

            Console.WriteLine($"{this.Name} recharged for {difference} MP!");
        }

        internal void Heal(int healAmount)
        {
            var difference = 0;
            var currentHitPoints = this.HitPoints;

            if ((healAmount + currentHitPoints) > MaxHitPoints)
            {
                difference = MaxHitPoints - this.HitPoints;
                this.HitPoints = MaxHitPoints;
            }
            else
            {
                this.HitPoints += healAmount;

                difference = healAmount;
            }

            Console.WriteLine($"{this.Name} healed for {difference} HP!");
        }
    }

    class StartUp
    {
        static void Main(string[] args)
        {

            var numberOfHeroes = int.Parse(Console.ReadLine());

            var listHeroes = new List<Hero>();
            Hero hero = new Hero();

            //Add heroes to list
            for (int i = 0; i < numberOfHeroes; i++)
            {
                var heroArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                //Hero arguments
                var heroName = heroArgs[0];
                var heroHitPoints = int.Parse(heroArgs[1]);
                var heroManaPoints = int.Parse(heroArgs[2]);

                hero = new Hero(heroName, heroHitPoints, heroManaPoints);

                listHeroes.Add(hero);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                var commandArgs = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                var command = commandArgs[0];
                var heroName = commandArgs[1];

                switch (command)
                {
                    case "CastSpell":
                        var manaNeeded = int.Parse(commandArgs[2]);
                        var spellName = commandArgs[3];

                        hero = listHeroes.First(h => h.Name == heroName);

                        hero.CastSpell(manaNeeded, spellName);
                        break;
                    case "TakeDamage":
                        var damage = int.Parse(commandArgs[2]);
                        var attacker = commandArgs[3];

                        hero = listHeroes.First(h => h.Name == heroName);
                        hero.TakeDamage(damage, attacker);

                        if (hero.IsDead)
                        {
                            listHeroes.Remove(hero);
                        }

                        break;
                    case "Recharge":
                        var rechargeAmount = int.Parse(commandArgs[2]);

                        hero = listHeroes.First(h => h.Name == heroName);
                        hero.Recharge(rechargeAmount);
                        break;
                    case "Heal":
                        var healAmount = int.Parse(commandArgs[2]);

                        hero = listHeroes.First(h => h.Name == heroName);
                        hero.Heal(healAmount);
                        break;
                }
            }
            var sortedHeroes = listHeroes.OrderByDescending(h => h.HitPoints)
                    .ThenBy(h => h.Name)
                    .ToList();

            foreach (var sortedHero in sortedHeroes)
            {
                Console.WriteLine(sortedHero.Name);
                Console.WriteLine($"  HP: {sortedHero.HitPoints}");
                Console.WriteLine($"  MP: {sortedHero.ManaPoints}");
            }
        }
    }
}