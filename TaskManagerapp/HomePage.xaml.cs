using CommunityToolkit.Maui.Views;
using System;
using System.Text.RegularExpressions;
using TaskManagerapp;
namespace TaskManagerapp;

public partial class HomePage : ContentPage
{
    private bool _isFlyoutVisible = false;

    public Member? SelectedMember { get; }
    public Group? SelectedGroup { get; }

    public HomePage()
    {
        InitializeComponent();

    }
    private void OnImageTapped(object sender, EventArgs e)
    {
        // Action when the image is tapped
        this.ShowPopup(new AdminMessage());
    }

    public HomePage(Member? selectedMember)
    {
        SelectedMember = selectedMember;
    }

    public HomePage(Group? selectedGroup)
    {
        SelectedGroup = selectedGroup;
    }

    private async void OnMenuClicked(object sender, EventArgs e)
    {
        if (_isFlyoutVisible)
        {
            await FlyoutMenu.TranslateTo(-250, 0, 250, Easing.SinIn);
            FlyoutMenu.IsVisible = false;
        }
        else
        {
            FlyoutMenu.IsVisible = true;
            await FlyoutMenu.TranslateTo(0, 0, 250, Easing.SinIn);
        }

        _isFlyoutVisible = !_isFlyoutVisible;
    }
    private void MemberClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }

    private void ProfileImageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }
    private void TasksImageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Tasks());
    }

    private void TasksClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new Tasks());
    }
    private void GroupsImageClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new GroupPage());
    }

    private void GroupsClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new File());
    }
    private void peopleButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PeoplePage()); ;

    }
    private void ProfileClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new ProfilePage());
    }

    private void domainButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DomainPage()); ;
    }

    private void taskButton(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Tasks());

    }
    private async void OnMainContentTapped(object sender, EventArgs e)
    {

        await FlyoutMenu.TranslateTo(-250, 0, 250, Easing.SinIn);
        FlyoutMenu.IsVisible = false;
        _isFlyoutVisible = false;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}

public class Member
{
    internal string Username;
    internal string GroupName;
    internal string PhoneNumber;
    internal string JobTitle;
    internal string Group;

    public string Name { get; internal set; }
    public string Role { get; internal set; }
}

internal class FlyoutMenu
{
    public static bool IsVisible { get; internal set; }

    internal static async Task TranslateTo(int v1, int v2, int v3, Easing sinIn)
    {
    }
}

