using System.Windows.Controls;

namespace TgimbaWpfClient.Views
{
    /// <summary>
    /// Interaction logic for SearchEntry.xaml
    /// </summary>
    public partial class SearchEntryView : UserControl
    {
        public SearchEntryView()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.SeachResults);
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
