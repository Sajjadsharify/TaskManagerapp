using System;
namespace TaskManagerapp;

public partial class SmsPage : ContentPage
{
    public SmsPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        timerFunc();
    }
    private async Task timerFunc()
    {
        for (int i = 3; i >= 0; i--)
        {
            for (int j = 59; j >= 0; j--)
            {
                timerLabel.Text = $"{i}:{j}";
                await Task.Delay(1000);
            }
        }
    }
    private async void DoneButton(object sender, EventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new HomePage());

    }
}

internal class timerLabel
{
    internal static string Text;
}