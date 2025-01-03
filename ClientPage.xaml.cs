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
}