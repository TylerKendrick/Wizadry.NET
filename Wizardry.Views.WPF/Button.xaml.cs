using System;
using System.Linq;
using System.Windows;

namespace Wizardry.Views
{
    public partial class Button : System.Windows.Controls.Button
    {
        public Button()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            ViewModels.Button button = this.DataContext as ViewModels.Button;

            if (button != null)
            {
                button.Click();
            }
        }
    }
}
