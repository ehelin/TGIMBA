using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;
using System.Collections.Generic;

namespace TgimbaWpfClient.Views
{
    public partial class SearchResultsView : UserControl
    {
        private SearchResultsModel searchResultsModel = null;

        public SearchResultsView()
        {
            InitializeComponent();

            searchResultsModel = new SearchResultsModel();
        }

        public void SearchBucketListItems()
        {
            string[] fndBucketListItems = searchResultsModel.SearchBucketListItems();

            Utilities utilities = new Utilities();
            List<Button> bucketListItemButtons = utilities.CreateBucketListView(fndBucketListItems);

            icBucketListItems.ItemsSource = bucketListItemButtons;
        }
        private void btnBucketItemList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
