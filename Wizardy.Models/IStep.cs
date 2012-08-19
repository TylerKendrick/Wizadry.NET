using System;
using System.Linq;

namespace Wizardry.Models
{
    public interface IStep : Wizardry.IStep
    {
        event Action<Wizardry.IStep> OnExecute;
        event Action<Wizardry.IStep> OnLoad;
        event Action<Wizardry.IStep> OnStart;
        event Action<Wizardry.IStep> OnComplete;
    }
}
