# MvvmCrossAccordionView
MvvmCross Expandable Accordion View with mvvm approach



Just imagine that we need to create expandable accordion TableView using MvvmCross.
In this case we can use MvxSimpleTableViewSource but with some modifications.
 
We should override:

1. **GetCell** to perform collapse and expand cells modifications
2. **GetHeightForRow** to get correct cells height after expansion
3. **RowSelected** for changing selected condition

Let's do it:
        
    public class ExpandableTalbeViewSource : MvxSimpleTableViewSource
    {
		public ExpandableTalbeViewSource(UITableView table, string key) : base(table, key) { }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = base.GetCell(tableView, indexPath);
			//expand or collapse cell here according to condition
			return cell;
		}

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 50;// expanded or collapsed height according to condition

		}

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//set selected row condition and reload needed rows
			base.RowSelected(tableView, indexPath);
		}

    }
    
For now we have to find place where we will store information about selected row.
It can be cell or DataSource - the best solution is DataSource, because cell can be reused

     NSIndexPath selectedRowIndexPath;
     public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			selectedRowIndexPath = indexPath;
			//set selected row condition and reload needed rows
			base.RowSelected(tableView, indexPath);
		}

Also we need condition to check if this is selected row

    private bool IsSelectedRow(NSIndexPath indexPath) => selectedRowIndexPath?.Row==indexPath.Row

Let's merge all together;

	public class AccordionTalbeViewSource<T> : MvxSimpleTableViewSource
		where T : UITableViewCell, IExpandableMvxTableViewCell
	{
		public AccordionTalbeViewSource(UITableView table, string key, int collapsedHeight, int expandedHeight) : base(table, key) 
		{
			collapsedCellHeight = collapsedHeight;
			expandedCellHeight = expandedHeight;
		}
		private  int collapsedCellHeight { get; set; }
		private  int expandedCellHeight { get; set; }
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
     
For doing expand/collapse stuff our cell should implement this interface.

	public interface IExpandableMvxTableViewCell
	{
		void ExpandCell();
		void CollapseCell();
	}
In viewController we just need create our ViewSource and bind it.

       source = new AccordionTalbeViewSource<ExpandedTableViewCell>(TableView,ExpandedTableViewCell.Key,50,250);
			TableView.Source = source;
			var set = this.CreateBindingSet<HomeView, HomeViewModel>();
			set.Bind(source).For(s => s.ItemsSource).To(vm => vm.Items);
			set.Apply();

That's all!

![](https://media.giphy.com/media/3o6YfTNbkY6QSalYR2/giphy.gif)

