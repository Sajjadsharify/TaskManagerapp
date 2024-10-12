
using System.Collections.ObjectModel;

namespace TaskManagerapp
{
    public partial class FirstMember : ContentPage
    {
        public ObservableCollection<string> Groups { get; set; }
        public ObservableCollection<string> Domains { get; set; }
        public ObservableCollection<string> SubDomains { get; set; }
        public string SelectedDomain { get; set; }
        public string UserProfile { get; set; }


        public FirstMember()
        {
            InitializeComponent();
            BindingContext = this;

            // Initialize groups and domains
            Groups = new ObservableCollection<string>
            {
                "Group 1", "Group 2", "Group 3", "Group 4", "Group 5"
            };

            Domains = new ObservableCollection<string>
            {
                "Domain 1", "Domain 2", "Domain 3", "Domain 4", "Domain 5"
            };

            // Bind Groups and Domains to the UI
            groupPicker.ItemsSource = Groups;
            domainPicker.ItemsSource = Domains;
        }


        private async void OnFileButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Select a profile image"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    profileImage.Source = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Could not pick a file: " + ex.Message, "OK");
            }
        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(UserProfile))
            {

                await DisplayAlert("Save", "Profile picture has been saved.", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please select a profile picture before saving.", "OK");
            }
        }
        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Cancel", "Are you sure you want to cancel? Any unsaved changes will be lost.", "Yes", "No");
            if (confirm)
            {
                await Navigation.PopAsync();
            }
        }
        private void OnGroupSelected(object sender, EventArgs e)
        {
            var selectedGroups = groupPicker.SelectedItem;


        }

        private void OnDomainSelected(object sender, EventArgs e)
        {
            var domain = (sender as Picker)?.SelectedItem as string;
            if (!string.IsNullOrEmpty(domain))
            {
                SelectedDomain = domain;
                UpdateSubDomains(domain);
                subDomainPicker.IsVisible = true;
            }
        }

        private void UpdateSubDomains(string domain)
        {
            SubDomains = new ObservableCollection<string>();

            switch (domain)
            {
                case "Domain 1":
                    SubDomains.Add("Subdomain 1.1");
                    SubDomains.Add("Subdomain 1.2");
                    break;
                case "Domain 2":
                    SubDomains.Add("Subdomain 2.1");
                    SubDomains.Add("Subdomain 2.2");
                    break;
                default:
                    SubDomains.Add("No subdomains available");
                    break;
            }

            subDomainPicker.ItemsSource = SubDomains;
        }
    }

    internal class profileImage
    {
        public static ImageSource Source { get; internal set; }
    }

    internal class domainPicker
    {
        public static ObservableCollection<string> ItemsSource { get; internal set; }
    }

    internal class groupPicker
    {
        internal static object SelectedItem;

        public static ObservableCollection<string> ItemsSource { get; internal set; }
        public static object SelectedItems { get; internal set; }
    }

    internal class subDomainPicker
    {
        public static ObservableCollection<string> ItemsSource { get; internal set; }
        public static bool IsVisible { get; internal set; }
    }
}