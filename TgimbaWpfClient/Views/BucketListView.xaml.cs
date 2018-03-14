using System.Windows;
using System.Windows.Controls;
using TgimbaWpfClient.ViewModels;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace TgimbaWpfClient.Views
{
    public class TodoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }

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
            List<Button> bucketListItemButtons = new List<Button>();
            int lineNumber = 1;
            for (int i = 0; i<bucketListItems.Length; i++)
            {
                string bucketListItem = bucketListItems[i];
                string[] bucketListItemComponents = bucketListItem.Split(',');

                bucketListItemButtons.Add(CreateButton(lineNumber, bucketListItemComponents));

                lineNumber++;
            }

            icBucketListItems.ItemsSource = bucketListItemButtons;
        }
        private Button CreateButton(int lineNumber, string[] bucketItemComponents)
        {
            Button button = new Button();

            button.Content = lineNumber.ToString() + "   " + bucketItemComponents[1];
            button.CommandParameter = bucketItemComponents;
            button.Click += btnMenuItem_Click;
            button.HorizontalContentAlignment = HorizontalAlignment.Left;
            button.Foreground = Brushes.Black;
            button.Background = Brushes.White;
            button.Name = "bucketListItem" + lineNumber.ToString();
            Thickness thickness = new Thickness(0, 0, 0, 0);
            button.BorderThickness = thickness;

            return button;
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.SetCurrentPanel(UseControls.Menu);
        }
        private void btnMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string[] bucketListItems = (string[])button.CommandParameter;

            MessageBox.Show("You selected Item \'"
                + bucketListItems[1] + "'\n"
                + "Database Id: " + bucketListItems[5]
                , "Bucket List View", MessageBoxButton.OK);
        }
    }
}
