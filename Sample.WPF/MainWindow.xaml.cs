using System;
using System.Linq;
using System.Windows;
using Sample.WPF.Steps.Models;
using Sample.WPF.Steps.ViewModels;
using Sample.WPF.Steps.Views;

namespace Sample.WPF
{
    public partial class MainWindow : Window
    {
        private Wizardry.Models.Wizard wizardModel = null;
        private Wizardry.ViewModels.Wizard wizardViewModel = null;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWizard();
        }

        private void InitializeWizard()
        {
            Step1Model model = new Step1Model();
            Step1ViewModel viewModel = new Step1ViewModel(model);
            Step1View view = new Step1View();
            
            Wizardry.Views.Registration.Register(viewModel, view);
            Wizardry.ViewModels.Registration.Register(model, viewModel);

            this.wizardModel = new Wizardry.Models.Wizard(model);
            this.wizardModel.OnFinished += delegate { this.Close(); };
            this.wizardViewModel = new Wizardry.ViewModels.Wizard(wizardModel);
            this.wizardView.DataContext = this.wizardViewModel;
        }
    }
}
