using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;
       
        public SecondWindow()
        {
            
            InitializeComponent();

            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
            uxList.AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(GridViewColumnHeaderClickHandler));
           


        }
        void GridViewColumnHeaderClickHandler(object sender, RoutedEventArgs e)
        {
            
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;
            var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
            var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;
        

            if (_lastHeaderClicked == headerClicked)
            {
                if (_lastDirection == ListSortDirection.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                                
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

                Sort(sortBy, direction);
                _lastHeaderClicked = headerClicked;
                _lastDirection = direction;

                
           
        }

        private void Sort(string sortby, ListSortDirection direction)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortby, direction);
            view.SortDescriptions.Add(sd);
            view.Refresh();
            

        }

    }
}
