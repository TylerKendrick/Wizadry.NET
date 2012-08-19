using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Wizardry.ViewModels
{
    public static class Registration
    {
        private static readonly Dictionary<Type, Type> registeredStepViews = new Dictionary<Type, Type>();
        private static readonly Dictionary<Models.Step, ViewModels.IStep> registeredStepViewObjects = new Dictionary<Models.Step, ViewModels.IStep>();

        public static void Register<Model, ViewModel>()
            where Model : Models.Step
            where ViewModel : ViewModels.IStep
        {
            registeredStepViews.Add(typeof(Model), typeof(ViewModel));
        }

        public static void Register(Models.Step model, ViewModels.IStep viewModel)
        {
            registeredStepViews.Add(model.GetType(), viewModel.GetType());
            registeredStepViewObjects.Add(model, viewModel);
        }

        public static ViewModels.IStep Get(Models.Step model)
        {
            Type modelType = model.GetType();
            Type viewModelType = null;
            ViewModels.IStep result = registeredStepViewObjects[model];
            
            if (result == null)
            {
                viewModelType = registeredStepViews[modelType];
                ConstructorInfo constructor = viewModelType.GetConstructor(new Type[] { modelType });
                object instance = constructor.Invoke(new object[] { model });
                result = instance as ViewModels.IStep;
            }
            return result;
        }
    }
}
