using System;
using System.Linq;
using System.Windows.Controls;
using System.ComponentModel;

namespace Wizardry.Views
{
    public partial class Wizard : UserControl, Wizardry.IWizard, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Wizardry.IStep step = null;
        public Wizardry.IStep Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
                NotifyPropertyChanged("Step");
            }
        }
        
        public Wizard()
        {
            InitializeComponent();
        }

        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
