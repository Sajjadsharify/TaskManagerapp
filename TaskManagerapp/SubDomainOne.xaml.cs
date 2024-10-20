using System.Collections.ObjectModel;

namespace TaskManagerapp;

public partial class SubDomainOne : ContentPage
{
    ObservableCollection<string> groups = new ObservableCollection<string> { "Develop", "Marketing" };
    ObservableCollection<string> members = new ObservableCollection<string> { "Member 1", "Member 2", "Member 3", "Member 4", "Member 5" };
    ObservableCollection<string> tasks = new ObservableCollection<string> { "Task 1", "Task 2" };

    public SubDomainOne()
    {
        InitializeComponent();
        GroupsList.ItemsSource = groups;
        MembersList.ItemsSource = members;
        TasksList.ItemsSource = tasks;
    }

    // Search handler
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue?.ToLower() ?? string.Empty;

        GroupsList.ItemsSource = groups.Where(g => g.ToLower().Contains(searchTerm)).ToList();
        MembersList.ItemsSource = members.Where(m => m.ToLower().Contains(searchTerm)).ToList();
        TasksList.ItemsSource = tasks.Where(t => t.ToLower().Contains(searchTerm)).ToList();
    }

    // Save button
    private void OnSaveClicked(object sender, EventArgs e)
    {
        DisplayAlert("Save", "Data saved successfully", "OK");
    }

    // Cancel button
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
