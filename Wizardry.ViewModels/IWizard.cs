using System;
using System.Linq;

namespace Wizardry.ViewModels
{
    public interface IWizard
    {
        ViewModels.IButton BtnNext { get; }
        ViewModels.IStep Step { get; }
    }
}
