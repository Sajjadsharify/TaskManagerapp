using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using System.ComponentModel;
using System.Formats.Tar;
namespace TaskManagerapp;

public partial class NewGroup : CommunityToolkit.Maui.Views.Popup
{
    public NewGroup()
    {
        InitializeComponent();
    }
    private async void PopUpButto_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new GroupPage();
    }

}