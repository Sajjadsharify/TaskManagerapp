using CommunityToolkit.Maui.Views;

namespace TaskManagerapp;

public partial class GroupPage : ContentPage
{
    public GroupPage()
    {
        InitializeComponent();
    }
    //private async void Groupone_Clicked(object sender, EventArgs e)
    //{
    //    Navigation.PushAsync(new GroupOne());
    //}
    private async void Grouptwo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GroupTwo());
    }
    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        this.ShowPopup(new NewGroup());

    }
    //private async void Groupone_Clicked(object sender, EventArgs e)
    //{
    //    Navigation.PushAsync(new NewGroup());
    //}

}
