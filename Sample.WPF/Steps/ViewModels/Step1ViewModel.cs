using System;
using System.Linq;

namespace Sample.WPF.Steps.ViewModels
{
    class Step1ViewModel : Wizardry.ViewModels.Step<Wizardry.Models.Step>
    {
        public Step1ViewModel(Wizardry.Models.Step model)
            : base(model)
        {
            this.Title = "Step 1";
        }
    }
}
