using System;
using System.Collections.Generic;
using WildLife.Common;

namespace WildLife.IoC
{
    public class Rabbit : AnimalBaseIoC
    {
        public Rabbit(AnimalGender gender) : base(AnimalKind.rabbit, gender)
        {
        }

        protected override List<(Func<bool> condition, Action behavior)> GetPrioritizedBehaviors()
        {
            return new List<(Func<bool>, Action)>
            {
                // 1. Mating
                (
                    () => TheWorld.NearBy(AnimalKind.rabbit) && TheWorld.GenderOfNearBy(AnimalKind.rabbit) != Gender,
                    () => Mate()
                ),
                
                // 3. Fleeing
                (
                    () => TheWorld.NearBy(AnimalKind.tiger) || TheWorld.NearBy(AnimalKind.fox),
                    () => Flee()
                ),

                // 3. Hungry -> Scavange and Eat
                (
                    () => Hungry,
                    () => { Scavenge(); Eat(); }
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
