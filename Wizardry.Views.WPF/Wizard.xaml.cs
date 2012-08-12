using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace Wizardry.Views
{
    public partial class Wizard : UserControl
    {
        private ViewModels.Wizard viewModel { get { return DataContext as ViewModels.Wizard; } }
        private ViewModels.IStep step { get { return this.viewModel.Step; } }

        public Wizard()
        {
            InitializeComponent();
            currentStep.DataContextChanged += currentStepDataContextChanged;
        }

        private void currentStepDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            Type viewModelType = step.GetType();
            DataTemplate template = Registration.GetTemplateFromRegisteredTypes(viewModelType);
            //currentStep.ContentTemplate. = template;
            currentStep.SetValue(ContentPresenter.ContentTemplateProperty, template);
        }

    }
}
