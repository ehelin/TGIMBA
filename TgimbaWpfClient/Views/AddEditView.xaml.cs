using System;
using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;

namespace TgimbaWpfClient.Views
{
    public partial class AddEditView : UserControl
    {
        private AddEditModel addEditModel = null;

        public AddEditView()
        {
            InitializeComponent();

            addEditModel = new AddEditModel();
            clearFields();

            tbDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            cbCategory.Items.Add("Hot");
            cbCategory.Items.Add("Warm");
            cbCategory.Items.Add("Cold");
        }

        private void clearFields()
        {
            this.tbName.Text = string.Empty;
            this.tbDate.Text = string.Empty;
            this.cbCategory.SelectedIndex = 0;
            this.cbAchieved.IsChecked = false;
        }

        private void btnSubmit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string name = this.tbName.Text;
            string date = this.tbDate.Text;
            string category = this.cbCategory.SelectedValue.ToString();
            bool achieved = this.cbAchieved.IsChecked.Value;

            if (addEditModel.AddBucketListItem(name, date, category, achieved))
            {
                clearFields();
                MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
            }
            else
            {
                // TODO - handle better
                MessageBox.Show("Add Failed", "Login", MessageBoxButton.OK);
                clearFields();
            }
        }

        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
