using System;
using System.Collections.Generic;
using System.Linq;

namespace Wizardry.Models
{
    public class Wizard : Models.IWizard
    {
        private IEnumerator<Models.Step> enumerator;
        
        public event Action<Wizardry.IStep> OnNext;
        public event Action OnFinished;
        public IEnumerable<Models.Step> Steps { get; private set; }

        private Wizardry.IStep step = null;
        public Wizardry.IStep Step 
        { 
            get { return step; }
            private set { step = value; }
        }

        public Wizard(params Models.Step[] steps)
            : this(steps.AsEnumerable())
        {
        }

        public Wizard(IEnumerable<Models.Step> steps)
        {
            this.Steps = steps;
            OnNext += OnNextCalled;
        }

        private void OnNextCalled(Wizardry.IStep step)
        {
            step.Load();
        }

        public virtual void Next()
        {
            if (enumerator == null)
            {
                enumerator = Steps.GetEnumerator();
                enumerator.MoveNext();
                step = enumerator.Current;
                this.OnNext(Step);
            }
            else
            {
                if (Step != Steps.Last())
                {
                    enumerator.MoveNext();
                    step = enumerator.Current;
                    this.OnNext(Step);
                }
                else
                {
                    if (OnFinished != null)
                    {
                        OnFinished();
                    }
                }
            }
        }
    }
}
