using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;

namespace TgimbaWpfClient.Views
{
    public partial class SearchEntryView : UserControl
    {
        private SearchEntryModel searchEntryModel = null;

        public SearchEntryView()
        {
            InitializeComponent();

            searchEntryModel = new SearchEntryModel();
        }

        private void btnSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearchTerm.Text))
            {
                searchEntryModel.SetSearchTerm(tbSearchTerm.Text);
                MainWindow.Instance.SetCurrentPanel(UseControls.SeachResults);
            }
            else
            {
                MessageBox.Show("Please enter a search term", "Search", MessageBoxButton.OK);
            }
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
