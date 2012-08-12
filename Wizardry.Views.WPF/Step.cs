using System;
using System.Linq;
using System.Windows.Controls;

namespace Wizardry.Views
{
    public class Step : UserControl
    {
        public ViewModels.IStep ViewModel
        {
            get;
            set;
        }

        public Step()
            : base()
        {
        }
    }
}
