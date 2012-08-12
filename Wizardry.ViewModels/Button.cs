using System;
using System.Linq;
using System.ComponentModel;

namespace Wizardry.ViewModels
{
    public class Button : IButton, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event Action OnClick;

        private bool isEnabled = true;
        public bool IsEnabled 
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                NotifyPropertyChanged("IsEnabled");
            }
        }

        private string content = "Start";
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                NotifyPropertyChanged("Content");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Click()
        {
            if (OnClick != null)
            {
                OnClick();
            }
        }
    }
}
