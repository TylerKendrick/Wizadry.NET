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
                
                if (viewInstance != null)
                {
                    viewInstance.DataContext = instance;
                    Type viewType = viewInstance.GetType();
                    FrameworkElementFactory factory = new FrameworkElementFactory(viewType);
                    DataTemplate template = new DataTemplate(viewType);
                    template.VisualTree = factory;

                    return template;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
