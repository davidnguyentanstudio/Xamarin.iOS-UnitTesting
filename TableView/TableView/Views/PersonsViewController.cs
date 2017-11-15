using System;
using System.Linq;
using Foundation;
using TableView.Models;
using TableView.ViewModels;
using UIKit;

namespace TableView.Views
{
    public partial class PersonsViewController : UIViewController,
    IUITableViewDataSource,
    IUITableViewDelegate
    {
        struct Constants
        {
            public static string SimplePersonCellIdentifier = "SimplePersonCell";
            public static string DetailPersonCellIdentifier = "DetailPersonCell";
        }

        public PersonsViewController() : base("PersonsViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SetupComponentViews();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            Title = "Persons";
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return viewModel.Persons.Count;
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var person = viewModel.Persons[indexPath.Row];
            if (viewModel.IsShowingDetailForPerson(person))
            {
                var cell = tableView.DequeueReusableCell(Constants.DetailPersonCellIdentifier);
                if (cell == null)
                {
                    cell = new UITableViewCell(UITableViewCellStyle.Subtitle, Constants.DetailPersonCellIdentifier);
                }
                cell.TextLabel.Text = person.FullName;
                cell.DetailTextLabel.Text = viewModel.GetDetailForPerson(person);
                return cell;
            }
            else
            {
                var cell = tableView.DequeueReusableCell(Constants.SimplePersonCellIdentifier);
                if (cell == null)
                {
                    cell = new UITableViewCell(UITableViewCellStyle.Default, Constants.SimplePersonCellIdentifier);
                }
                cell.TextLabel.Text = person.FullName;
                return cell;
            }
        }

        [Export("tableView:didSelectRowAtIndexPath:")]
        public void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var person = viewModel.Persons[indexPath.Row];
            viewModel.TogglePersonDetail(person, DidTogglePersonDetail);
        }

        protected void DidTogglePersonDetail(Person person)
        {
            var visibleIndexPaths = PersonTableView.IndexPathsForVisibleRows.ToList();
            var personIndex = viewModel.Persons.IndexOf(person);
            var reloadIndex = visibleIndexPaths.FindIndex((input) =>
            {
                return input.Row == personIndex;
            });
            var reloadIndexPaths = new NSIndexPath[] { visibleIndexPaths[reloadIndex] };
            PersonTableView.ReloadRows(reloadIndexPaths, UITableViewRowAnimation.Automatic);
        }

        protected void SetupComponentViews()
        {
            this.PersonTableView.Source = new BaseTableViewSource(this, this);
            this.PersonTableView.TableFooterView = new UIView();
        }

        protected PersonsViewModel viewModel = new PersonsViewModel();
    }
}

