using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect;

public partial class CityPage : ContentPage
{
	public CityPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var city = (City)BindingContext;

        if (city != null)
        {
            await App.Database.SaveCityAsync(city);
            await Navigation.PopAsync();
        }
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var city = (City)BindingContext;

        if (city != null)
        {
            await App.Database.DeleteCityAsync(city);
            await Navigation.PopAsync();
        }
    }
}