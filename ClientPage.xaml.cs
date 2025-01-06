using MelisaIuliaProiect.Models;
using Microsoft.Maui.Devices.Sensors;
using Plugin.LocalNotification;
using System.Net;

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
        var client = (Client)BindingContext;
        var address = client.Adresa;
        //var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Adresa clientului"
        };
        //var clientlocation = locations?.FirstOrDefault();
        var clientlocation = new Location(46.77562320574969, 23.621155970165358);//pentru Windows Machine

        //var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.771251, 23.625991);
        var distance = myLocation.CalculateDistance(clientlocation, DistanceUnits.Kilometers);

        if (distance < 5)
        {
            var request = new NotificationRequest
            {
                Title = "Esti in apropierea clientului!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }

        await Map.OpenAsync(clientlocation, options);
    }
}