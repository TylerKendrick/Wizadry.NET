using System;
using System.Linq;

namespace Sample.WPF.Steps.ViewModels
{
    class Step2ViewModel : Wizardry.ViewModels.Step<Wizardry.Models.Step>
    {
        public Step2ViewModel(Wizardry.Models.Step model)
            : base(model)
        {
        }
    }
}
