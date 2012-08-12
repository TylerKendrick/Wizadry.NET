using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Wizardry.Views
{
    public static class Registration
    {
        private static readonly Dictionary<Type, Type> registeredStepViews = new Dictionary<Type, Type>();
        
        public static DataTemplate GetTemplateFromRegisteredTypes(Type viewModelType)
        {
            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.DataType = registeredStepViews[viewModelType];
            return dataTemplate;
        }
        
        public static void Register<ViewModel, View>()
            where ViewModel : ViewModels.IStep
            where View : Views.Step
        {
            registeredStepViews.Add(typeof(ViewModel), typeof(View));
        }
    }
}
