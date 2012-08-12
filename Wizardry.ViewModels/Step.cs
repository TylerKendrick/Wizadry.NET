using System;
using System.Linq;
using System.ComponentModel;

namespace Wizardry.ViewModels
{
    public class Step<T> : ViewModels.IStep, INotifyPropertyChanged
        where T : Models.Step
    {
        protected T model { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event Action<Wizardry.IStep> OnStart
        {
            add { model.OnStart += value; }
            remove { model.OnStart -= value; }
        }
        public event Action<Wizardry.IStep> OnExecute
        {
            add { model.OnExecute += value; }
            remove { model.OnExecute -= value; }
        }
        public event Action<Wizardry.IStep> OnComplete
        {
            add { model.OnComplete += value; }
            remove { model.OnComplete -= value; }
        }
        public event Action<Wizardry.IStep> OnLoad
        {
            add { model.OnLoad += value; }
            remove { model.OnLoad -= value; }
        }

        public string Title
        {
            get { return model.Title; }
            set
            {
                model.Title = value;
                NotifyPropertyChanged("Title");
            }
        }

        public Step(T handle)
        {
            this.model = handle;
        }

        public void Load()
        {
            model.Load();
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
