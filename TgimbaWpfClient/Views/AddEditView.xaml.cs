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

        private void setUp()
        {
            clearFields();

            if (isAdd)
            {
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
            }
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
            if (isAdd)
            {
                AddBucketListItem();
            }
            else
            {
                EditBucketListItem();
            }
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

            if (addEditModel.EditBucketListItem(bucketListItem))
            {
                clearFields();
                MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
            }
            else
            {
                // TODO - handle better
                MessageBox.Show("Edit Failed", "Edit", MessageBoxButton.OK);
                clearFields();
            }
        }
        private void AddBucketListItem()
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
                MessageBox.Show("Add Failed", "Add", MessageBoxButton.OK);
                clearFields();
            }
        }
        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.BucketList);
        }
    }
}
