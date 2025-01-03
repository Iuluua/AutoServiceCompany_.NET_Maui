using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace MelisaIuliaProiect;

public partial class DepartmentEntryPage : ContentPage
{
	public DepartmentEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        departmentListView.ItemsSource = await App.Database.GetDepartmentAsync();
    }

    async void OnDepartmentAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DepartmentPage
        {
            BindingContext = new Models.Department()
        });
    }
    async void OnDepartmentItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new DepartmentPage
            {
                BindingContext = e.SelectedItem as Models.Department
            });
        }
    }
}