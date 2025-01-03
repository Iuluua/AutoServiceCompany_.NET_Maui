using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MelisaIuliaProiect;

public partial class CityEntryPage : ContentPage
{
	public CityEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        cityListView.ItemsSource = await App.Database.GetCityAsync();
    }

    async void OnCityAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CityPage
        {
            BindingContext = new Models.City()
        });
    }
    async void OnCityItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new CityPage
            {
                BindingContext = e.SelectedItem as Models.City
            });
        }
    }
}