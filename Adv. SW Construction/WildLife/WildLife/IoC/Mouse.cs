using System;
using System.Collections.Generic;
using WildLife.Common;

namespace WildLife.IoC
{
    public class Mouse : AnimalBaseIoC
    {
        public Mouse(AnimalGender gender) : base(AnimalKind.mouse, gender) { }

        protected override List<(Func<bool> condition, Action behavior)> GetPrioritizedBehaviors()
        {
            return new List<(Func<bool>, Action)>
            {
                // 1. Fleeing
                (
                    () => TheWorld.NearBy(AnimalKind.tiger) || TheWorld.NearBy(AnimalKind.rabbit),
                    () => Flee()
                ),

                // 2. Mating
                (
                    () => TheWorld.NearBy(AnimalKind.mouse) && TheWorld.GenderOfNearBy(AnimalKind.mouse) != Gender,
                    () => Mate()
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
