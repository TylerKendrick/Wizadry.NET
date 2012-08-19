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

        public event Action<Wizardry.IStep> OnExecute
        {
            add { model.OnExecute += value; }
            remove { model.OnExecute -= value; }
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

        public virtual void Load()
        {
            model.Load();
        }

        public virtual void Execute()
        {
            model.Execute();
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
