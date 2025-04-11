using System;
using System.Collections.Generic;
using WildLife.Common;

namespace WildLife.IoC
{
    public class Tiger : AnimalBaseIoC
    {
        public Tiger(AnimalGender gender) : base(AnimalKind.tiger, gender) { }

        protected override List<(Func<bool> condition, Action behavior)> GetPrioritizedBehaviors()
        {
            return new List<(Func<bool>, Action)>
            {
                // 1. Hungry -> Hunt and Eat
                (
                    () => Hungry,
                    () => { Hunt(); Eat(); }
                ),

                // 2. Sleepy
                (
                    () => Sleepy,
                    () => Sleep()
                ),

                // 3. Fleeing
                (
                    () => TheWorld.NearBy(AnimalKind.tiger) && TheWorld.GenderOfNearBy(AnimalKind.tiger) == Gender,
                    () => Flee()
                ),

                // 4. Mating
                (
                    () => TheWorld.NearBy(AnimalKind.tiger) && TheWorld.GenderOfNearBy(AnimalKind.tiger) != Gender,
                    () => Mate()
                ),
            };
        }
    }
}
