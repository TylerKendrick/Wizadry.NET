using System;
using System.Linq;
using System.Collections.Generic;

namespace Wizardry.Models
{
    interface IWizard : Wizardry.IWizard
    {
        event Action<Wizardry.IStep> OnNext;
        event Action OnFinished;
        
        IEnumerable<Models.Step> Steps { get; }

        void Next();
    }
}
