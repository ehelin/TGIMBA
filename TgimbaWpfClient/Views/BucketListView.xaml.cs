using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;
using System.Text;

namespace TgimbaWpfClient.Views
{
    public partial class BucketListView : UserControl
    {
        private BucketListModel bucketListModel = null;

        public BucketListView()
        {
            InitializeComponent();

            bucketListModel = new BucketListModel();
        }

        public void DisplayBucketListItems()
        {
            string[] bucketListItems = bucketListModel.GetBucketListItems();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Bucket List");
            sb.AppendLine("");

            int ctr = 1;
            foreach (string bucketListItem in bucketListItems)
            {
                string[] bucketListItemComponents = bucketListItem.Split(',');
                sb.AppendLine(ctr.ToString() + "-" + bucketListItemComponents[1]);
                ctr++;
            }

            this.tbBucketListItems.Text = sb.ToString();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.Menu);
        }
    }
}
