using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect;

public partial class DepartmentPage : ContentPage
{
	public DepartmentPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var department = (Department)BindingContext;

        if (department != null)
        {
            await App.Database.SaveDepartmentAsync(department);
            await Navigation.PopAsync();
        }
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var department = (Department)BindingContext;

            if (department != null)
            {
                await App.Database.DeleteDepartmentAsync(department);
                await Navigation.PopAsync();
            }
        }
}