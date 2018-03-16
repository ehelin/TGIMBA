using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;

namespace TgimbaWpfClient
{
    public class Utilities
    {
        public List<Button> CreateBucketListView(string[] bucketListItems)
        {
            List<Button> bucketListItemButtons = new List<Button>();
            int lineNumber = 1;
            for (int i = 0; i < bucketListItems.Length; i++)
            {
                string bucketListItem = bucketListItems[i];
                string[] bucketListItemComponents = bucketListItem.Split(',');

                bucketListItemButtons.Add(CreateButton(lineNumber, bucketListItemComponents));

                lineNumber++;
            }

            return bucketListItemButtons;
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
        private void btnMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string[] bucketListItems = (string[])button.CommandParameter;

            MainWindow.Instance.SetCurrentPanel(UseControls.Edit, bucketListItems);

            //MessageBox.Show("You selected Item \'"
            //    + bucketListItems[1] + "'\n"
            //    + "Database Id: " + bucketListItems[5]
            //    , "Bucket List View", MessageBoxButton.OK);
        }
    }
}
