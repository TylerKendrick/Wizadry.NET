using System;
using System.Linq;

namespace Wizardry
{
    public interface IStep
    {
        event Action<Wizardry.IStep> OnStart;
        event Action<Wizardry.IStep> OnExecute;
        event Action<Wizardry.IStep> OnComplete;
        event Action<Wizardry.IStep> OnLoad;

        string Title { get; }

        void Load();
        void Execute();
    }
}
