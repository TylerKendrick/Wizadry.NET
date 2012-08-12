using System;

namespace Wizardry.ViewModels
{
    public interface IStep
    {
        event Action<Wizardry.IStep> OnStart;
        event Action<Wizardry.IStep> OnExecute;
        event Action<Wizardry.IStep> OnComplete;

        string Title { get; }

        void Load();
    }
}
