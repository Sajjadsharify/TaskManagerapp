using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.Controls;

namespace TaskManagerapp;

public partial class DomainsAndSubdomains : ContentPage
{
    public ObservableCollection<Domain> Domains { get; set; }
    public ObservableCollection<Subdomain> Subdomains { get; set; }
    public ObservableCollection<Domain> FilteredDomains { get; set; }
    public ObservableCollection<Subdomain> FilteredSubdomains { get; set; }

    public DomainsAndSubdomains()
    {
        InitializeComponent();

        Domains = new ObservableCollection<Domain>
        {
            new Domain { DomainName = "Domain1", SubdomainName="Subdomain A", Description = "Main Domain A", Code = "D1" },
            new Domain { DomainName = "Domain2", SubdomainName="Subdomain B", Description = "Main Domain B", Code = "D2" },
            new Domain { DomainName = "Domain3", SubdomainName="Subdomain C", Description = "Main Domain C", Code = "D3" },
            new Domain { DomainName = "Domain4", SubdomainName="Subdomain D", Description = "Main Domain D", Code = "D4" },
            new Domain { DomainName = "Domain5", SubdomainName="Subdomain E", Description = "Main Domain E", Code = "D5" }
        };

        Subdomains = new ObservableCollection<Subdomain>
        {
            new Subdomain { SubdomainName = "Subdomain One", Description = "Subdomain for Domain 1" },
            new Subdomain { SubdomainName = "Subdomain Two", Description = "Subdomain for Domain 2" },
            new Subdomain { SubdomainName = "Subdomain Three", Description = "Subdomain for Domain 3" },
            new Subdomain { SubdomainName = "Subdomain Four", Description = "Subdomain for Domain 4" },
            new Subdomain { SubdomainName = "Subdomain Five", Description = "Subdomain for Domain 5" }
        };

        FilteredDomains = new ObservableCollection<Domain>(Domains);
        FilteredSubdomains = new ObservableCollection<Subdomain>(Subdomains);
        BindingContext = this;
    }

    private async void OnDomainTapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DomainOne());
    }

    // Navigate to a unique page based on the subdomain tapped
    private async void OnSubdomainTapped(object sender, EventArgs e)
    {
        var tappedItem = (sender as Microsoft.Maui.Controls.Grid)?.BindingContext as Subdomain;

        if (tappedItem != null)
        {
            switch (tappedItem.SubdomainName)
            {
                case "Subdomain One":
                    await Navigation.PushAsync(new SubDomainOne());
                    break;
                case "Subdomain Two":
                    await Navigation.PushAsync(new SubDomainTwo());
                    break;
                case "Subdomain Three":
                    await Navigation.PushAsync(new SubDomainThree());
                    break;
                case "Subdomain Four":
                    await Navigation.PushAsync(new SubDomainFour());
                    break;
                case "Subdomain Five":
                    await Navigation.PushAsync(new SubDomainFive());
                    break;
            }
        }
    }

    // Swipe to Delete Domain
    private async void OnDeleteDomain(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var domain = (swipeItem.BindingContext as Domain);

        if (domain != null)
        {
            var result = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {domain.DomainName}?", "Yes", "No");
            if (result)
            {
                Domains.Remove(domain);
            }
        }
    }

    // Swipe to Delete Subdomain
    private async void OnDeleteSubdomain(object sender, EventArgs e)
    {
        var swipeItem = sender as SwipeItem;
        var subdomain = (swipeItem.BindingContext as Subdomain);

        if (subdomain != null)
        {
            var result = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {subdomain.SubdomainName}?", "Yes", "No");
            if (result)
            {
                Subdomains.Remove(subdomain);
            }
        }
    }

    // Add New Domain Button Clicked
    private async void OnAddDomainButtonClicked(object sender, EventArgs e)
    {
        // Logic to add a new domain (not implemented here)
    }

    // Add New Subdomain Button Clicked
    private async void OnAddSubdomainButtonClicked(object sender, EventArgs e)
    {
        // Logic to add a new subdomain (not implemented here)
    }

    // Search logic to filter Domains and Subdomains
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = SearchEntry.Text?.ToLower();
        FilteredDomains.Clear();
        FilteredSubdomains.Clear();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            foreach (var domain in Domains)
            {
                FilteredDomains.Add(domain);
            }
            foreach (var subdomain in Subdomains)
            {
                FilteredSubdomains.Add(subdomain);
            }
        }
        else
        {
            var filteredDomains = Domains.Where(d => d.DomainName.ToLower().Contains(searchText));
            foreach (var domain in filteredDomains)
            {
                FilteredDomains.Add(domain);
            }

            var filteredSubdomains = Subdomains.Where(s => s.SubdomainName.ToLower().Contains(searchText));
            foreach (var subdomain in filteredSubdomains)
            {
                FilteredSubdomains.Add(subdomain);
            }
        }
    }
}

internal class SearchEntry
{
    public static string Text { get; internal set; }
}

public class Subdomain
{
    public string SubdomainName { get; internal set; }
    public string Description { get; internal set; }
}

public class Domain
{
    public string DomainName { get; internal set; }
    public string SubdomainName { get; internal set; }
    public string Description { get; internal set; }
    public string Code { get; internal set; }
}
