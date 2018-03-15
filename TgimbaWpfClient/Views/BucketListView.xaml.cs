using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;
using System.Collections.Generic;

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

            Utilities utilities = new Utilities();
            List<Button> bucketListItemButtons = utilities.CreateBucketListView(bucketListItems);

            icBucketListItems.ItemsSource = bucketListItemButtons;
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.Menu);
        }
    }
}
