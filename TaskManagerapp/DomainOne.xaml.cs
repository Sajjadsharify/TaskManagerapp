using System;
using Microsoft.Maui.Controls;

namespace TaskManagerapp
{
    public partial class DomainOne : ContentPage
    {
        public DomainOne()
        {
            InitializeComponent();
        }

        private void OnSearch(object sender, EventArgs e)
        {
            // Implement search functionality
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

        private void OnAddNewMemberClicked(object sender, EventArgs e)
        {
            // Handle adding a new member
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
    }
}
