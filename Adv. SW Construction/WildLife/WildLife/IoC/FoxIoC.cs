using System;
using System.Collections.Generic;
using WildLife.Common;

namespace WildLife.IoC
{
    public class FoxIoC : AnimalBaseIoC
    {
        public FoxIoC(AnimalGender gender) : base(AnimalKind.fox, gender)
        {    
        }

        protected override List<(Func<bool> condition, Action behavior)> GetPrioritizedBehaviors()
        {
            return new List<(Func<bool>, Action)>
            {
                (
                    () => Hungry && (TheWorld.NearBy(AnimalKind.rabbit) || TheWorld.NearBy(AnimalKind.mouse)),
                    () => { Hunt(); Eat(); }
                ),

                (
                    () => TheWorld.NearBy(AnimalKind.fox) && TheWorld.GenderOfNearBy(AnimalKind.fox) != Gender,
                    () => Mate()
                ),

                (
                    () => TheWorld.NearBy(AnimalKind.tiger),
                    () => Flee()
                ),

                (
                    () => Sleepy,
                    () => Sleep()
                )
            };
        }
    }
}
