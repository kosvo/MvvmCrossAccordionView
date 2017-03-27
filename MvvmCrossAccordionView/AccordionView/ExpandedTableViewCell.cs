using System;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MvvmCrossAccordionView
{
    public partial class ExpandedTableViewCell : MvxTableViewCell, IExpandableMvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ExpandedTableViewCell");
        public static readonly UINib Nib;

        static ExpandedTableViewCell()
        {
            Nib = UINib.FromName("ExpandedTableViewCell", NSBundle.MainBundle);
        }

        protected ExpandedTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void CollapseCell()
        {
            greenUIView.Hidden = true;
            heightConstraint.Constant = 0;
        }

        public void ExpandCell()
        {
            greenUIView.Hidden = false;
            heightConstraint.Constant = 160;

        }
    }
}
