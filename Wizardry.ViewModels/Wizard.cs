using System;
using System.Linq;
using System.ComponentModel;

namespace Wizardry.ViewModels
{
    public class Wizard : ViewModels.IWizard, INotifyPropertyChanged
    {
        protected Models.Wizard model = null;
        public event PropertyChangedEventHandler PropertyChanged;

        private Wizardry.IStep step = null;
        public Wizardry.IStep Step 
        { 
            get { return step; }
            protected set
            {
                step = value;
                NotifyPropertyChanged("Step");
            }
        }
        
        private ViewModels.IButton btnNext = null;
        public ViewModels.IButton BtnNext 
        { 
            get { return btnNext; }
            set
            {
                btnNext = value;
                NotifyPropertyChanged("BtnNext");
            }
        }

        public Wizard(Models.Wizard handle)
        {
            InitializeModel(handle);
        }
        
        private void InitializeModel(Models.Wizard handle)
        {
            model = handle;
            btnNext = new ViewModels.Button();
            btnNext.OnClick += model.Next;
            InitializeContent();
            model.OnNext += OnNextStep;
        }

        private void OnNextStep(Wizardry.IStep step)
        {
            Models.Step modelStep = (Models.Step)step;
            this.Step = ViewModels.Registration.Get(modelStep);
            this.Step.Load();
        }

        private void InitializeContent()
        {
            foreach (Models.Step modelStep in model.Steps)
            {
                modelStep.OnStart += Started;
                modelStep.OnComplete += Completed;
                modelStep.OnLoad += Loaded;
            }
        }

        private void Loaded(Wizardry.IStep step)
        {
            btnNext.IsEnabled = false;
            if (step == model.Steps.Last())
            {
                btnNext.Content = "Finish";
            }
            else
            {
                btnNext.Content = "Next";
            }
        }

        private void Started(Wizardry.IStep step)
        {
            btnNext.IsEnabled = false;
        }

        private void Completed(Wizardry.IStep step)
        {
            btnNext.IsEnabled = true;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
