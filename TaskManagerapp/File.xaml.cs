using Microsoft.Maui.Storage;
using System;

namespace TaskManagerapp
{
    public partial class File : ContentPage
    {
        public File()
        {
            InitializeComponent();
        }

        // Handle the Upload Button click
        private async void OnUploadButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Open file picker to choose a file
                var result = await FilePicker.PickAsync();
                if (result != null)
                {
                    // Display the selected file name to the user
                    await DisplayAlert("File Selected", $"File: {result.FileName}", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle errors such as user canceling the file picker
                await DisplayAlert("Error", "File selection was canceled.", "OK");
            }
        }

        // Handle the Save Button click
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Retrieve the URL entered by the user
            string url = UrlEntry.Text;

            // Retrieve the selected access level (Admin or Members)
            string accessLevel = AccessPicker.SelectedItem?.ToString();

            // Save data using preferences (persistence across app sessions)
            Preferences.Set("FileUrl", url); // Save URL
            Preferences.Set("AccessLevel", accessLevel); // Save access level

            // Notify the user that the data has been saved
            DisplayAlert("Saved", "File information saved successfully!", "OK");
        }

        // Handle the Close Button click
        private async void OnCloseButtonClicked(object sender, EventArgs e)
        {
            // Close the current page and return to the previous page
            await Navigation.PopAsync();
        }

        internal static bool Exists(string imagePath)
        {
            throw new NotImplementedException();
        }

        internal static IDisposable OpenWrite(string localPath)
        {
            throw new NotImplementedException();
        }
    }

    internal class AccessPicker
    {
        public static string SelectedItem { get; internal set; }
    }

    internal class UrlEntry
    {
        public static string Text { get; internal set; }
    }
}
