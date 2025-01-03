using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MelisaIuliaProiect;

public partial class ClientEntryPage : ContentPage
{
	public ClientEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        clientListView.ItemsSource = await App.Database.GetClientAsync();
    }

    async void OnClientAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientPage
        {
            BindingContext = new Models.Client()
        });
    }
    async void OnClientItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ClientPage
            {
                BindingContext = e.SelectedItem as Models.Client
            });
        }
    }
}