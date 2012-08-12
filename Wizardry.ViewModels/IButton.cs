using System;
using System.Linq;

namespace Wizardry.ViewModels
{
    public interface IButton
    {
        event Action OnClick;

        bool IsEnabled { get; set; }

        string Content { get; set; }
    }
}
