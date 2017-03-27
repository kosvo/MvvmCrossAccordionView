using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCrossAccordionView
{
    public interface IExpandableMvxTableViewCell
    {
        void ExpandCell();
        void CollapseCell();
    }
    
}
