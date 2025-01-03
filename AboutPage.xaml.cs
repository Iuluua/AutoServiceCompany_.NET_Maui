using Microsoft.Maui.Controls;
using MelisaIuliaProiect.Models;

namespace MelisaIuliaProiect;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadDynamicData();
    }

    private async Task LoadDynamicData()
    {
        var clients = await App.Database.GetClientAsync();
        ClientDetails.Text = $"Number of Clients: {clients.Count}";

        var cities = await App.Database.GetCityAsync();
        CityCoverage.Text = $"Number of Cities: {cities.Count}";
        CityCoverage.Text += $"\nMain City: {cities.FirstOrDefault()?.Name ?? "N/A"}";

        var departments = await App.Database.GetDepartmentAsync();
        DepartmentsOverview.Text = $"Departments: {string.Join(", ", departments.Select(d => d.Name))}";
        DepartmentsOverview.Text += $"\nPrimary Department: {departments.FirstOrDefault()?.Name ?? "N/A"}";
    }
}
