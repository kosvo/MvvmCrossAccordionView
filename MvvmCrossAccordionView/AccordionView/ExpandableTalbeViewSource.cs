using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace MvvmCrossAccordionView
{


    public class AccordionTalbeViewSource<T> : MvxSimpleTableViewSource
    where T : UITableViewCell, IExpandableMvxTableViewCell
    {
        public AccordionTalbeViewSource(UITableView table, string key, int collapsedHeight, int expandedHeight) : base(table, key)
        {
            collapsedCellHeight = collapsedHeight;
            expandedCellHeight = expandedHeight;
        }
        private int collapsedCellHeight { get; set; }
        private int expandedCellHeight { get; set; }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (T)base.GetCell(tableView, indexPath);
            if (indexPath.Row == selectedPath?.Row)
                cell.ExpandCell();
            else
                cell.CollapseCell();
            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Row == selectedPath?.Row)
                return expandedCellHeight;
            else return collapsedCellHeight;

        }

        private NSIndexPath selectedPath;
        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var oldSelectedPath = selectedPath;
            selectedPath = indexPath;

            if (oldSelectedPath != null && oldSelectedPath.Row != indexPath.Row)
            {
                tableView.ReloadRows(new[] { oldSelectedPath, selectedPath }, UITableViewRowAnimation.Fade);
            }
            else if (oldSelectedPath == null)
            {
                tableView.ReloadRows(new[] { selectedPath }, UITableViewRowAnimation.Fade);
            }
            base.RowSelected(tableView, indexPath);
        }
    }
}
