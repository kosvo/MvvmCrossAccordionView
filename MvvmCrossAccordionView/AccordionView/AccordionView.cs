using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCrossAccordionView
{
    public partial class AccordionView : MvxViewController<AccordionViewModel>
    {
        public AccordionView() : base("AccordionView", null)
        {
        }
        AccordionTalbeViewSource<ExpandedTableViewCell> source;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            source = new AccordionTalbeViewSource<ExpandedTableViewCell>(TableView, ExpandedTableViewCell.Key, 40, 200);
            TableView.Source = source;
            var set = this.CreateBindingSet<AccordionView, AccordionViewModel>();
            set.Bind(source).For(s => s.ItemsSource).To(vm => vm.Items);
            set.Apply();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}

