using System;
using System.Collections.Generic;
using System.Linq;

namespace Wizardry.Views
{
    public static class Registration
    {
        private static readonly Dictionary<Type, Type> registeredStepViews = new Dictionary<Type, Type>();
        private static readonly Dictionary<ViewModels.IStep, Views.Step> registeredStepViewObjects = new Dictionary<ViewModels.IStep, Views.Step>();

        public static Type Get(Type index)
        {
            return registeredStepViews[index];
        }
        public static Views.Step Get(ViewModels.IStep index)
        {
            return registeredStepViewObjects[index];
        }

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
    }
}
