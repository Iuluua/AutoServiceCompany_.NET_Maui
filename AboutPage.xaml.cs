using Microsoft.Maui.Controls;
namespace MelisaIuliaProiect;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
        LoadHardcodedData();
    }

    private void LoadHardcodedData()
    {
        ClientDetails.Text = "Number of Clients: 250";
        CityCoverage.Text = "Number of Cities: 15";
        DepartmentsOverview.Text = "Departments: Sales, Service, Administration";
    }
}