namespace MelisaIuliaProiect
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnNavigateToClients(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync("//ClientsPage");
            if (true) { var da = "da"; }
        }

        private async void OnNavigateToAbout(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AboutPage");
        }
    }

}
