using ForgroundService.Services;

namespace ForgroundService
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IServiceTest _serviceTest;
        public MainPage(IServiceTest serviceTest)
        {
            InitializeComponent();
            _serviceTest = serviceTest;
        }

        protected override void OnAppearing()
        {
            //_serviceTest.StartService();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void StartServiceBtn_Clicked(object sender, EventArgs e)
        {
            _serviceTest.StartService();
        }

        private void StopServiceBtn_Clicked(object sender, EventArgs e)
        {
            _serviceTest.StopService();
        }
    }

}
