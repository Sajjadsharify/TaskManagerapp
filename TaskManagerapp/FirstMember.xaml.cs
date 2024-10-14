using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace TaskManagerapp
{
    public partial class FirstMember : ContentPage
    {
        private List<string> selectedDomains = new List<string>();

        private List<string> domains = new List<string>
    {
        "Domain A",
        "Domain B",
        "Domain C",
        "Domain D",
        "Domain E"
    };
        public FirstMember()
        {
            InitializeComponent();
            // Load saved data from preferences
            LoadData();

            // Set the ItemSource for DomainCollectionView
            DomainCollectionView.ItemsSource = domains;

            // Load saved data from preferences
            LoadData();

            // Update live DateTime
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                DateTimeLabel.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                return true; // Repeat every second
            });
        }

        // 1. Edit Profile Picture (with Preferences)
        private async void OnEditProfilePictureClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    var imageData = await ConvertStreamToBase64Async(stream);
                    Preferences.Set("ProfileImage", imageData);
                    ProfileImage.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(imageData)));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        // Convert Stream to Base64
        private async Task<string> ConvertStreamToBase64Async(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        // 2. Load Data (from Preferences)
        private void LoadData()
        {
            NameEntry.Text = Preferences.Get("Name", "");
            UsernameEntry.Text = Preferences.Get("Username", "");
            GroupPicker.SelectedItem = Preferences.Get("Group", null);
            var selectedDomainsString = Preferences.Get("SelectedDomains", string.Empty);
            selectedDomains = selectedDomainsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            UpdateCheckBoxStatus();


            // ???????? ??? ?????
            var role = Preferences.Get("Role", "Member"); // ??????? "Member"
            RolePicker.SelectedItem = role;


            var profileImageBase64 = Preferences.Get("ProfileImage", null);
            if (!string.IsNullOrEmpty(profileImageBase64))
            {
                ProfileImage.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(profileImageBase64)));
            }
        }

        private void UpdateCheckBoxStatus()
        {
        }

        // 3. Save Button Clicked (store real data in Preferences)
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (NameEntry.Text != null)
            {
                Preferences.Set("Name", NameEntry.Text);
            }

            if (UsernameEntry.Text != null)
            {
                Preferences.Set("Username", UsernameEntry.Text);
            }

            if (GroupPicker.SelectedItem != null)
            {
                Preferences.Set("Group", GroupPicker.SelectedItem.ToString());
            }
            else
            {
                // ??? ???? ?????? ???? ????? ?? ????? ??????? ???? ????
                Preferences.Set("Group", "DefaultGroup");
            }

            Preferences.Set("Role", RolePicker.SelectedItem?.ToString() ?? "Member");

            Preferences.Set("IsAdmin", AdminSwitch.IsToggled);
            Preferences.Set("SelectedDomains", string.Join(",", selectedDomains));

            DisplayAlert("Saved", "Your data has been saved!", "OK");
        }


        // 4. Close Button Clicked
        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(); // Close the page
        }

        // 5. Task Buttons (Completed and Pending Tasks)
        private void OnCompletedTasksClicked(object sender, EventArgs e)
        {
            // Logic for completed tasks
            DisplayAlert("Tasks", "Show Completed Tasks", "OK");
        }

        private void OnPendingTasksClicked(object sender, EventArgs e)
        {
            // Logic for pending tasks
            DisplayAlert("Tasks", "Show Pending Tasks", "OK");
        }
        private void OnDomainCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var selectedDomain = checkBox.BindingContext.ToString();

            if (e.Value)
            {
                // ????? ???? ????? ?? ???? ?????? ???
                if (!selectedDomains.Contains(selectedDomain))
                {
                    selectedDomains.Add(selectedDomain);
                }
            }
            else
            {
                // ??? ????? ?? ???? ?????? ???
                if (selectedDomains.Contains(selectedDomain))
                {
                    selectedDomains.Remove(selectedDomain);
                }
            }
        }
    }

    internal class RolePicker
    {
        public static string SelectedItem { get; internal set; }
    }

    internal class DomainCollectionView
    {
        public static List<string> ItemsSource { get; internal set; }
    }

    internal class AdminSwitch
    {
        public static string? IsToggled { get; internal set; }
    }

    internal class GroupPicker
    {
        public static string? SelectedItem { get; internal set; }
    }

    internal class DateTimeLabel
    {
        public static string Text { get; internal set; }
    }
}
