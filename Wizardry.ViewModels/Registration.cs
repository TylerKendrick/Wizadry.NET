using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Wizardry.ViewModels
{
    public static class Registration
    {
        private static readonly Dictionary<Type, Type> registeredStepViews = new Dictionary<Type, Type>();

        public static void Register<Model, ViewModel>()
            where Model : Models.Step
            where ViewModel : ViewModels.IStep
        {
            registeredStepViews.Add(typeof(Model), typeof(ViewModel));
        }

        public static ViewModels.IStep GetStep(Models.Step model)
        {
            Type modelType = model.GetType();
            Type viewModelType = registeredStepViews[modelType];
            ConstructorInfo constructor = viewModelType.GetConstructor(new Type[] { modelType });
            object result = constructor.Invoke(new object[] { model });
            ViewModels.IStep step = result as ViewModels.IStep;
            return step;
        }
    }
}
