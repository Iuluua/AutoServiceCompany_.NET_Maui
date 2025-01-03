namespace MelisaIuliaProiect
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                int clientsCount = await App.Database.GetClientsCountAsync();
                int citiesCount = await App.Database.GetCitiesCountAsync();
                int departmentsCount = await App.Database.GetDepartmentsCountAsync();

                ClientsCountLabel.Text = clientsCount.ToString();
                CitiesCountLabel.Text = citiesCount.ToString();
                DepartmentsCountLabel.Text = departmentsCount.ToString();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load data: {ex.Message}", "OK");
            }
        }


        private async void OnNavigateToClients(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ClientEntryPage");
        }

        private async void OnNavigateToCities(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CityEntryPage");
        }


        private async void OnNavigateToAbout(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AboutPage");
        }

        private async void OnNavigateToDepartments(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//DepartmentEntryPage");
        }
    }

}
