using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Wizardry.Views
{
    public static class Registration
    {
        private static readonly Dictionary<Type, Type> registeredStepViews = new Dictionary<Type, Type>();
        private static readonly Dictionary<ViewModels.IStep, Views.Step> registeredStepViewObjects = new Dictionary<ViewModels.IStep, Views.Step>();

        public static void Register<ViewModel, View>()
            where ViewModel : ViewModels.IStep
            where View : Views.Step
        {
            registeredStepViews.Add(typeof(ViewModel), typeof(View));
        }
        public static void Register(ViewModels.IStep viewModel, Views.Step view)
        {
            registeredStepViews.Add(viewModel.GetType(), view.GetType());
            registeredStepViewObjects.Add(viewModel, view);
        }

        public static Views.IStep Get(ViewModels.IStep viewModel)
        {
            Type modelType = viewModel.GetType();
            Type viewModelType = null;
            Views.Step result = registeredStepViewObjects[viewModel];

            if (result == null)
            {
                viewModelType = registeredStepViews[modelType];
                ConstructorInfo constructor = viewModelType.GetConstructor(new Type[] { modelType });
                object instance = constructor.Invoke(new object[] { viewModel });
                result = instance as Views.Step;
            }

            result.DataContext = viewModel;
            return result;
        }
    }
}
