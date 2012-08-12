using System;
using System.Linq;

namespace Wizardry.Models
{
    public abstract partial class Step : Wizardry.IStep
    {
        public class Increment
        {
            public event Action<Step.Increment, Models.Step> OnStart;
            public event Action<Step.Increment, Models.Step> OnExecute;
            public event Action<Step.Increment, Models.Step> OnComplete;

            public void Execute()
            {
            }

            public void Initialize(Models.Step step)
            {
            }
        }
    }
}
