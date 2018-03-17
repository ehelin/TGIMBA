using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using System;
using System.Linq;

namespace TgimbaWpfClient
{
    public class Utilities
    {
        public const int REGISTRATION_VALUE_LENGTH = 8;
        public const string EMAIL_AT_SIGN = "@";

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
        public static string EncodeClientBase64String(string val)
        {
            string encodedString = string.Empty;

            if (!string.IsNullOrEmpty(val))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(val);
                encodedString = Convert.ToBase64String(data);
            }

            return encodedString;
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
        }
        public static bool ValidUserToRegistration(string user, string email, string password)
        {
            bool valid = true;

            if (string.IsNullOrEmpty(user) || user.Equals("null"))
                valid = false;
            else if (string.IsNullOrEmpty(email) || email.Equals("null"))
                valid = false;
            else if (string.IsNullOrEmpty(password) || password.Equals("null"))
                valid = false;
            else if (user.Length < REGISTRATION_VALUE_LENGTH)
                valid = false;
            else if (password.Length < REGISTRATION_VALUE_LENGTH)
                valid = false;
            else if (!ContainsOneNumber(password))
                valid = false;
            else if (email.IndexOf(EMAIL_AT_SIGN) < 1)
                valid = false;

            return valid;
        }
        private static bool ContainsOneNumber(string password)
        {
            char[] charArray = password.ToArray();
            var numberFound = false;

            for (var i = 0; i < charArray.Length; i++)
            {
                string curChar = charArray[i].ToString();

                int j;
                if (Int32.TryParse(curChar, out j))
                {
                    numberFound = true;
                    break;
                }
            }

            return numberFound;
        }
    }
}
