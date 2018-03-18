using System;
using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;

namespace TgimbaWpfClient.Views
{
    public partial class AddEditView : UserControl
    {
        private AddEditModel addEditModel = null;
        private bool isAdd = true;
        private string[] bucketListItem = null;

        public bool SetIsAdd
        {
            set
            {
                isAdd = value;
                setUp();
            }
        }
        public string[] SetBucketListItem
        {
            set
            {
                bucketListItem = value;
            }
        }

        public AddEditView()
        {
            InitializeComponent();

            addEditModel = new AddEditModel();

            cbCategory.Items.Add("Hot");
            cbCategory.Items.Add("Warm");
            cbCategory.Items.Add("Cold");
        }
        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!this.isAdd)
            {
                string dbId = Utilities.RemoveCharacaters(this.bucketListItem[5]);
                HandleResult(addEditModel.DeleteBucketListItem(dbId));
            }
            else
            {
                MessageBox.Show("Delete is only allowed on Edit", "AddEditDelete", MessageBoxButton.OK);
            }
        }
        private void btnSubmit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (isAdd)
            {
                AddBucketListItem();
            }
            else
            {
                EditBucketListItem();
            }
        }
        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
        private void EditBucketListItem()
        {
            bucketListItem[1] = this.tbName.Text;
            bucketListItem[2] = this.tbDate.Text;
            bucketListItem[3] = this.cbCategory.SelectedValue.ToString();
            if (this.cbAchieved.IsChecked.Value == true)
            {
                bucketListItem[4] = "1";
            }
            else
            {
                bucketListItem[4] = "0";
            }
            bucketListItem[5] = Utilities.RemoveCharacaters(bucketListItem[5]);

            HandleResult(addEditModel.EditBucketListItem(bucketListItem), false);
        }
        private void AddBucketListItem()
        {
            string name = this.tbName.Text;
            string date = this.tbDate.Text;
            string category = this.cbCategory.SelectedValue.ToString();
            bool achieved = this.cbAchieved.IsChecked.Value;

            HandleResult(addEditModel.AddBucketListItem(name, date, category, achieved));
        }
        private void HandleResult(bool goodResult, bool clearResults = true)
        {
            if (goodResult)
            {
                clearFields();
                MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
            }
            else
            {
                // TODO - handle better
                MessageBox.Show("Selection Failed", "AddEditDelete", MessageBoxButton.OK);
                if (clearResults)
                {
                    clearFields();
                }
            }
        }
        private void setUp()
        {
            if (isAdd)
            {
                clearFields();
                tbDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            }
            else
            {
                tbName.Text = this.bucketListItem[1];
                tbDate.Text = this.bucketListItem[2];

                if (this.bucketListItem[3] == "Hot")
                {
                    this.cbCategory.SelectedIndex = 0;
                }
                else if (this.bucketListItem[3] == "Warm")
                {
                    this.cbCategory.SelectedIndex = 1;
                }
                else
                {
                    this.cbCategory.SelectedIndex = 2;
                }

                if (bucketListItem[4] == "1")
                {
                    this.cbAchieved.IsChecked = true;
                }
                else
                {
                    this.cbAchieved.IsChecked = false;
                }
            }
        }
        private void clearFields()
        {
            this.tbName.Text = string.Empty;
            this.tbDate.Text = string.Empty;
            this.cbCategory.SelectedIndex = 0;
            this.cbAchieved.IsChecked = false;
        }
    }
}
