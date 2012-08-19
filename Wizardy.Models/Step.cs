using System;
using System.Linq;

namespace Wizardry.Models
{
    public partial class Step : Models.IStep
    {
        public event Action<Wizardry.IStep> OnStart;
        public event Action<Wizardry.IStep> OnExecute;
        public event Action<Wizardry.IStep> OnComplete;
        public event Action<Wizardry.IStep> OnLoad;

        private string title = "Header Title Goes Here";
        public string Title 
        {
            get { return title; }
            set { title = value; }
        }

        public Step()
        {
            OnStart += Started;
        }

        public virtual void Execute()
        {
            if (OnStart != null)
            {
                OnStart(this);
                Completed();
            }
        }
        public virtual void Load()
        {
            if (OnLoad != null)
            {
                OnLoad(this);
            }
        }

        private void Completed()
        {
            if (OnComplete != null)
            {
                OnComplete(this);
            }
        }
        private void Started(Wizardry.IStep step)
        {
            if (OnExecute != null)
            {
                OnExecute(step);
            }
        }
    }
}
