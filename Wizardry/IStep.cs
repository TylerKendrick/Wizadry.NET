using System;
using System.Linq;

namespace Wizardry
{
    public interface IStep
    {
        void Load();
        void Execute();
    }
}
