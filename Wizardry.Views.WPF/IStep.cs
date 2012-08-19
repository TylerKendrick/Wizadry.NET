using System;
using System.Linq;

namespace Wizardry.Views
{
    interface IStep : Wizardry.IStep
    {
        ViewModels.IStep ViewModel { get; set; }
    }
}
