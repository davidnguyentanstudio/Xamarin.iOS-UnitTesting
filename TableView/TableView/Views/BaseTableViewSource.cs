using System;
using Foundation;
using UIKit;

namespace TableView
{
    public class BaseTableViewSource : UITableViewSource
    {
        public IUITableViewDataSource TableViewDataSource { get; set; }
        public IUITableViewDelegate TableViewDelegate { get; set; }

        public override nint NumberOfSections(UITableView tableView)
        {
            try
            {
                return TableViewDataSource.NumberOfSections(tableView);
            }
            catch
            {
                return 1;
            }
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            return TableViewDataSource.GetCell(tableView, indexPath);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableViewDataSource.RowsInSection(tableview, section);
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            try
            {
                return TableViewDelegate.GetHeightForRow(tableView, indexPath);
            }
            catch
            {
                return UITableView.AutomaticDimension;
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            try
            {
                TableViewDelegate.RowSelected(tableView, indexPath);
            }
            catch
            {
                // Do nothing
            }
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            try
            {
                return TableViewDataSource.CanEditRow(tableView, indexPath);
            }
            catch
            {
                return false;
            }
        }

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            try
            {
                return TableViewDelegate.EditActionsForRow(tableView, indexPath);
            }
            catch
            {
                return new UITableViewRowAction[0];
            }
        }

        public BaseTableViewSource(IUITableViewDataSource tableViewDataSource,
                               IUITableViewDelegate tableViewDelegate)
        {
            TableViewDataSource = tableViewDataSource;
            TableViewDelegate = tableViewDelegate;
        }
    }
}
