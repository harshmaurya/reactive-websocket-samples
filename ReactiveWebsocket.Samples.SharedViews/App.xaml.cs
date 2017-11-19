using ReactiveWebsocket.Sample;

namespace ReactiveWebsocket.Samples.SharedViews
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            var view = new MainPage();
            var viewModel = new MainPageViewModel();
            view.BindingContext = viewModel;
            MainPage = view;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
