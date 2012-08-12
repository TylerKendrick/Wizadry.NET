using System;
using System.Linq;

namespace Sample.WPF.Steps.ViewModels
{
    class Step3ViewModel : Wizardry.ViewModels.Step<Wizardry.Models.Step>
    {
        public Step3ViewModel(Wizardry.Models.Step model)
            : base(model)
        {
        }
    }
}
