using System;
using System.Linq;
using System.Windows.Controls;

namespace Wizardry.Views
{
    public partial class Wizard : UserControl, Wizardry.IWizard
    {
        private Type viewType = typeof(Views.Step);
        private ViewModels.Wizard viewModel { get { return DataContext as ViewModels.Wizard; } }
        public Wizardry.IStep Step { get { return this.viewModel.Step; } }

        public Wizard()
        {
            InitializeComponent();
        }
    }
}
