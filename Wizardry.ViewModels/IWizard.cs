using System;
using System.Linq;

namespace Wizardry.ViewModels
{
    public interface IWizard : Wizardry.IWizard
    {
        ViewModels.IButton BtnNext { get; }
    }
}
