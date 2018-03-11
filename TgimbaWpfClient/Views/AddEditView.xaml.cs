using System.Windows.Controls;

namespace TgimbaWpfClient.Views
{
    public partial class AddEditView : UserControl
    {
        public AddEditView()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
