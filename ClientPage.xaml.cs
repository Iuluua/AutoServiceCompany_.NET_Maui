using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect;

public partial class ClientPage : ContentPage
{
	public ClientPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var client = (Client)BindingContext;

        if (client != null)
        {
            await App.Database.SaveClientAsync(client);
            await Navigation.PopAsync();
        }
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var client = (Client)BindingContext;

        if (client != null)
        {
            await App.Database.DeleteClientAsync(client);
            await Navigation.PopAsync();
        }
    }


    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        //var client = (Client)BindingContext;
        //var address = client.Adresa;
        //var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Adresa clientului"
        };
        //var clientlocation = locations?.FirstOrDefault();
        var clientlocation = new Location(46.77562320574969, 23.621155970165358);//pentru Windows Machine

        await Map.OpenAsync(clientlocation, options);
    }
}