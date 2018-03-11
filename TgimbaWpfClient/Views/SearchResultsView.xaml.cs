using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;
using System.Text;

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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Search Results List");
            sb.AppendLine("");

            int ctr = 1;
            foreach (string bucketListItem in fndBucketListItems)
            {
                string[] bucketListItemComponents = bucketListItem.Split(',');
                sb.AppendLine(ctr.ToString() + "-" + bucketListItemComponents[1]);
                ctr++;
            }

            this.tbBucketListItems.Text = sb.ToString();
        }

        private void btnBucketItemList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
