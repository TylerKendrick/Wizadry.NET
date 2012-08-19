using System;

namespace Wizardry
{
    public interface IWizard
    {
        Wizardry.IStep Step { get; }
    }
}
