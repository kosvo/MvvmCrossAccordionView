// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MvvmCrossAccordionView
{
    [Register ("ExpandedTableViewCell")]
    partial class ExpandedTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView greenUIView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint heightConstraint { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (greenUIView != null) {
                greenUIView.Dispose ();
                greenUIView = null;
            }

            if (heightConstraint != null) {
                heightConstraint.Dispose ();
                heightConstraint = null;
            }
        }
    }
}