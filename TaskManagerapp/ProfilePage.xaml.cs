using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace TaskManagerapp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            string imagePath = Preferences.Get("ProfileImagePath", string.Empty);
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                ProfileImage.Source = ImageSource.FromFile(imagePath);
            }

            UsernameEntry.Text = Preferences.Get("Username", string.Empty);
            NameEntry.Text = Preferences.Get("Name", string.Empty);
            PhoneEntry.Text = Preferences.Get("PhoneNumber", string.Empty);

        }

        private async void OnEditProfilePictureClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Pick a Profile Picture" });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                ProfileImage.Source = ImageSource.FromStream(() => stream);

                string fileName = Path.GetFileName(result.FullPath);
                string localPath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                using (var fileStream = File.OpenWrite(localPath))
                {
                    await stream.CopyToAsync((Stream)fileStream);
                }

                Preferences.Set("ProfileImagePath", localPath);
            }
        }

        private void OnGroupButtonClicked(object sender, EventArgs e)
        {
            // Implement group selection logic (e.g., display dropdown)
        }

        private void OnAddRemoveDomainClicked(object sender, EventArgs e)
        {
            // Implement domain add/remove logic
        }

        private void OnAddRemoveSubdomainClicked(object sender, EventArgs e)
        {
            // Implement subdomain add/remove logic
        }

        private void OnFinishedTasksClicked(object sender, EventArgs e)
        {
            // Navigate to Finished Tasks page
        }

        private void OnToDoTasksClicked(object sender, EventArgs e)
        {
            // Navigate to To Do Tasks page
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            string username = UsernameEntry.Text;
            string name = NameEntry.Text;
            string phoneNumber = PhoneEntry.Text;

            Preferences.Set("Username", username);
            Preferences.Set("Name", name);
            Preferences.Set("PhoneNumber", phoneNumber);

            DisplayAlert("Success", "Profile saved successfully.", "OK");
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            // Close the page
            Navigation.PopAsync();
        }
    }

    internal class ProfileImage
    {
        public static ImageSource Source { get; internal set; }
    }

    internal class PhoneEntry
    {
        public static string Text { get; internal set; }
    }

    internal class NameEntry
    {
        public static string Text { get; internal set; }
    }

    internal class UsernameEntry
    {
        public static string Text { get; internal set; }
    }
}
