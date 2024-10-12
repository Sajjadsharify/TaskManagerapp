using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;
using TaskManagerapp;

namespace TaskManagerapp;

public partial class PeoplePage : ContentPage
{
    private string selectedMember;

    public ObservableCollection<Member> Members { get; set; }
    public ObservableCollection<Group> Groups { get; set; }
    public ObservableCollection<Member> FilteredMembers { get; set; }
    public ObservableCollection<Group> FilteredGroups { get; set; }
    public Member SelectedMember { get; }
    public Group SelectedGroup { get; }
    public Subdomain SelectedSubdomain { get; }

    public PeoplePage()
    {
        InitializeComponent();

        Members = new ObservableCollection<Member>
        {
            new Member { Username = "Member1", GroupName="group A", PhoneNumber = "09150000000", JobTitle = "Developer", Group = "A" },
            new Member { Username = "Member2", GroupName="group B", PhoneNumber = "09150000000", JobTitle = "UI Designer", Group = "B" },
            new Member { Username = "Member3", GroupName="group C", PhoneNumber = "09390000000", JobTitle = "Lead Of Development Team", Group = "C" },
            new Member { Username = "Member4", GroupName="group D", PhoneNumber = "09370000000", JobTitle = "Lead Of UI Team", Group = "D" },
            new Member { Username = "Member5", GroupName="group E", PhoneNumber = "09030000000", JobTitle = "Data Scientist", Group = "E" }
        };

        Groups = new ObservableCollection<Group>
        {
            new Group { GroupName = "Group One", Description = "Development Team" },
            new Group { GroupName = "Group Two", Description = "Design Team" },
            new Group { GroupName = "Group Three", Description = "Analysis Team" },
            new Group { GroupName = "Group Four", Description = "Supporting Team" },
            new Group { GroupName = "Group Five", Description = "Marketing Team" }
        };

        FilteredMembers = new ObservableCollection<Member>(Members);
        FilteredGroups = new ObservableCollection<Group>(Groups);
        BindingContext = this;
    }

    public PeoplePage(string selectedMember)
    {
        this.selectedMember = selectedMember;
    }

    public PeoplePage(Member selectedMember1)
    {
        SelectedMember = selectedMember1;
    }

    public PeoplePage(Group selectedGroup)
    {
        SelectedGroup = selectedGroup;
    }

    public PeoplePage(Subdomain selectedSubdomain)
    {
        SelectedSubdomain = selectedSubdomain;
    }

    // Navigate to a unique page based on the member tapped
    //private async void OnMemberTapped(object sender, EventArgs e)
    //{
    //    var tappedItem = (sender as Microsoft.Maui.Controls.Grid)?.BindingContext as Member;

    //    if (tappedItem != null)
    //    {
    //        switch (tappedItem.Username)
    //        {
    //            case "Member1":
    //                await Navigation.PushAsync(new MemberOneDeatilPage());
    //                break;
    //            case "Member2":
    //                await Navigation.PushAsync(new MemberTwoDetailPage());
    //                break;
    //            case "Member3":
    //                await Navigation.PushAsync(new MemberThreeDetailPage());
    //                break;
    //            case "Member4":
    //                await Navigation.PushAsync(new MemberFourDetailPage());
    //                break;
    //            case "Member5":
    //                await Navigation.PushAsync(new MemberFiveDetailPage());
    //                break;
    //        }
    //    }
    //}
    //  private async void groupButton(object sender, EventArgs e)
    //  {
    //      Navigation.PushAsync(new GroupPage());
    //  }
    private async void OnMemberTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FirstMember());
    }

    // Navigate to a unique page based on the group tapped
    private async void OnGroupTapped(object sender, EventArgs e)
    {
        var tappedItem = (sender as Microsoft.Maui.Controls.Grid)?.BindingContext as Group;

        if (tappedItem != null)
        {
            switch (tappedItem.GroupName)
            {
                case "Group One":
                    await Navigation.PushAsync(new GroupOneDetailPage());
                    break;
                case "Group Two":
                    await Navigation.PushAsync(new GroupTwoDetailPage());
                    break;
                case "Group Three":
                    await Navigation.PushAsync(new GroupThreeDetailPage());
                    break;
                case "Group Four":
                    await Navigation.PushAsync(new GroupFourDetailPage());
                    break;
                case "Group Five":
                    await Navigation.PushAsync(new GroupFiveDetailPage());
                    break;
            }
        }
    }

    // Swipe to Delete Member
    private async void OnDeleteUser(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var member = (swipeItem.BindingContext as Member);

        if (member != null)
        {
            var result = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {member.Username}?", "Yes", "No");
            if (result)
            {
                Members.Remove(member);
            }
        }
    }

    // Swipe to Delete Group
    private async void OnDeleteGroup(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var group = (swipeItem.BindingContext as Group);

        if (group != null)
        {
            var result = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {group.GroupName}?", "Yes", "No");
            if (result)
            {
                Groups.Remove(group);
            }
        }
    }

    // Add New Member Button Clicked
    private async void OnAddUserButtonClicked(object sender, EventArgs e)
    {
        // Logic to add a new member (not implemented here)
    }

    // Add New Group Button Clicked
    private async void OnAddGroupButtonClicked(object sender, EventArgs e)
    {
        // Logic to add a new group (not implemented here)
    }

    // Search logic to filter Members and Groups
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = SearchEntry.Text?.ToLower();
        FilteredMembers.Clear();
        FilteredGroups.Clear();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            foreach (var member in Members)
            {
                FilteredMembers.Add(member);
            }
            foreach (var group in Groups)
            {
                FilteredGroups.Add(group);
            }
        }
        else
        {
            var filteredMembers = Members.Where(m => m.Username.ToLower().Contains(searchText));
            foreach (var member in filteredMembers)
            {
                FilteredMembers.Add(member);
            }

            var filteredGroups = Groups.Where(g => g.GroupName.ToLower().Contains(searchText));
            foreach (var group in filteredGroups)
            {
                FilteredGroups.Add(group);
            }
        }
    }
}

public class Group
{
    public string GroupName { get; internal set; }
    public string Description { get; internal set; }
}

