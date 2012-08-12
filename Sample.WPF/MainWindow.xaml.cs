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
            Wizardry.Views.Registration.Register<Step1ViewModel, Step1>();
            Wizardry.ViewModels.Registration.Register<Step1Model, Step1ViewModel>();

            Step1Model step1 = new Step1Model();

            this.wizardModel = new Wizardry.Models.Wizard(step1);
            this.wizardModel.OnFinished += delegate { this.Close(); };
            this.wizardViewModel = new Wizardry.ViewModels.Wizard(wizardModel);
            this.wizardView.DataContext = this.wizardViewModel;
        }
    }
}
