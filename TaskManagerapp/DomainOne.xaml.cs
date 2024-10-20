using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using System.Timers;

namespace TaskManagerapp
{
    public partial class DomainOne : ContentPage
    {
        // ObservableCollection to hold members
        private ObservableCollection<Member> Members { get; set; }
        public ObservableCollection<Member> FilteredMembers { get; set; }
        private string CurrentSearchText = "";
        private string CurrentSortFilter = "A-Z";

        public DomainOne()
        {
            InitializeComponent();

            // Initialize members list
            Members = new ObservableCollection<Member>
            {
                new Member { Name = "Member 1", Role = "Developer" },
                new Member { Name = "Member 2", Role = "Ui Designer" },
                new Member { Name = "Member 3", Role = "Mentor" }
            };

            FilteredMembers = new ObservableCollection<Member>(Members);

            // Set the binding context for search and swipe functionality
            MembersListView.ItemsSource = FilteredMembers;

            // Start live date update
            StartLiveDate();
        }

        // Combined filtering based on search and sorting/filter
        private void ApplySearchAndSort()
        {
            // Step 1: Apply search filter
            var filteredList = Members.Where(m =>
                m.Name.ToLower().Contains(CurrentSearchText) ||
                m.Role.ToLower().Contains(CurrentSearchText));

            // Step 2: Apply sort/filter
            switch (CurrentSortFilter)
            {
                case "A-Z":
                    filteredList = filteredList.OrderBy(m => m.Name);
                    break;
                case "Z-A":
                    filteredList = filteredList.OrderByDescending(m => m.Name);
                    break;
                case "Developer":
                case "UI Developer":
                case "Mentor":
                    filteredList = filteredList.Where(m => m.Role == CurrentSortFilter);
                    break;
            }

            // Step 3: Update the FilteredMembers list
            FilteredMembers.Clear();
            foreach (var member in filteredList)
            {
                FilteredMembers.Add(member);
            }
        }

        // Search functionality
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            CurrentSearchText = e.NewTextValue.ToLower();
            ApplySearchAndSort();
        }

        // Sort/Filter functionality
        private void OnSortFilterSelected(object sender, EventArgs e)
        {
            CurrentSortFilter = SortFilterPicker.SelectedItem.ToString();
            ApplySearchAndSort();
        }

        // Edit Member action
        private void OnEditMember(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var member = (Member)((SwipeView)swipeItem.BindingContext).BindingContext;

            // Navigate to edit member page or handle editing
            DisplayAlert("Edit", $"Editing {member.Name}", "OK");
        }

        // Delete Member action
        private void OnDeleteMember(object sender, EventArgs e)
        {
            var swipeItem = (SwipeItem)sender;
            var member = (Member)((SwipeView)swipeItem.BindingContext).BindingContext;

            // Remove member from list
            Members.Remove(member);
            FilteredMembers.Remove(member);

            DisplayAlert("Delete", $"{member.Name} deleted", "OK");
        }

        private void OnMemberSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                // Navigate to MemberPage
                Navigation.PushAsync(new PeoplePage());
            }
        }

        private void OnGroupSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                // Navigate to GroupPage
                Navigation.PushAsync(new GroupPage());
            }
        }

        private void OnSubdomainSelected(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                // Navigate to SubdomainPage
                Navigation.PushAsync(new PeoplePage());
            }
        }

        private void OnAddNewJobClicked(object sender, EventArgs e)
        {
            // Handle adding a new job
        }

        private void OnApplyNewSubdomainClicked(object sender, EventArgs e)
        {
            // Handle applying a new subdomain
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            // Close the page
            Navigation.PopAsync();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            // Implement save functionality
        }

        private void EditdomainClicked(object sender, EventArgs e)
        {
            // Close the page
        }

        // Function to update the live date
        private void StartLiveDate()
        {
            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    LiveDateLabel.Text = DateTime.Now.ToString("F");
                });
            };
            timer.Start();
        }
    }
}

    // Member model


            // Handle adding a new
