using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Plugins;

namespace MvvmCrossAccordionView
{
    public class App
        : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<AccordionViewModel>();
        }
    }
}