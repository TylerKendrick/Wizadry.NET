using System;
using System.Linq;

namespace Wizardry.Views
{
    public interface IStep : Wizardry.IStep
    {
        ViewModels.IStep ViewModel { get; set; }
    }
}
