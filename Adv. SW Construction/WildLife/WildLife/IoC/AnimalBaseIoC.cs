using System;
using System.Collections.Generic;
using WildLife.Common;

namespace WildLife.IoC
{
    public abstract class AnimalBaseIoC : AnimalBase
    {
        protected AnimalBaseIoC(AnimalKind kind, AnimalGender gender) : base(kind, gender)
        {
        }

        public override void Act()
        {
            foreach (var (condition, behavior) in GetPrioritizedBehaviors())
            {
                if (condition())
                {
                    behavior();
                    return;
                }
            }

            Idle();
        }

        protected abstract List<(Func<bool> condition, Action behavior)> GetPrioritizedBehaviors();
    }
}
