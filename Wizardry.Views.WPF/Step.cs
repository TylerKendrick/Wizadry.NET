using System;
using System.Linq;
using System.Windows.Controls;

namespace Wizardry.Views
{
    public class Step : UserControl, Wizardry.IStep
    {
        public ViewModels.IStep ViewModel { get; set; }

        public Step()
            : base()
        {
        }

        public virtual void Load()
        {
            ViewModel.Load();
        }

        public virtual void Execute()
        {
            ViewModel.Execute();
        }
    }
}
