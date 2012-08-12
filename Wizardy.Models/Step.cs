using System;
using System.Linq;

namespace Wizardry.Models
{
    public abstract partial class Step : IStep
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
        public void Execute()
        {
            OnStart.BeginInvoke(this, Completed, null);
        }
        public void Load()
        {
            if (OnLoad != null)
            {
                OnLoad(this);
            }
        }

        private void Completed(IAsyncResult result)
        {
            OnComplete(this);
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
