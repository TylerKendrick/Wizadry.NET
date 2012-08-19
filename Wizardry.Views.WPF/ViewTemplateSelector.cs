using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace Wizardry.Views
{
    class ViewTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                ViewModels.IStep instance = (ViewModels.IStep)item;
                Views.Step viewInstance = Registration.Get(instance);
                Type viewType = viewInstance.GetType();

                if (viewType == null)
                {
                    viewType = typeof(Views.Step);
                }
                
                return new DataTemplate(viewType);
            }
            return base.SelectTemplate(item, container);
        }
    }
}
