using System;
using System.Collections.Generic;
using WildLife.Common;

namespace WildLife.IoC
{
    public class Fox : AnimalBaseIoC
    {
        public Fox(AnimalGender gender) : base(AnimalKind.fox, gender)
        {    
        }

        protected override List<(Func<bool> condition, Action behavior)> GetPrioritizedBehaviors()
        {
            return new List<(Func<bool>, Action)>
            {
                // 1. Hungry -> Hunt and Eat
                (
                    () => Hungry && (TheWorld.NearBy(AnimalKind.rabbit) || TheWorld.NearBy(AnimalKind.mouse)),
                    () => { Hunt(); Eat(); }
                ),

                // 2. Mating
                (
                    () => TheWorld.NearBy(AnimalKind.fox) && TheWorld.GenderOfNearBy(AnimalKind.fox) != Gender,
                    () => Mate()
                ),

                // 3. Fleeing
                (
                    () => TheWorld.NearBy(AnimalKind.tiger),
                    () => Flee()
                ),

                // 4. Sleepy
                (
                    () => Sleepy,
                    () => Sleep()
                )
            };
        }
    }
}
