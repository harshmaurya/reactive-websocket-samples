using System;
using System.ComponentModel;
using System.Windows.Input;
using ReactiveWebsocket.Sample.Core;
using Xamarin.Forms;

namespace ReactiveWebsocket.Samples.SharedViews
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _stringOutput;
        private readonly AppServiceString _appServiceServiceString = new AppServiceString();

        public string StringInput { get; set; }

        public string StringOutput
        {
            get => _stringOutput;
            set
            {
                _stringOutput = value;
                OnPropertyChanged(nameof(StringOutput));
            }
        }

        public ICommand StringCommand => new Command(ObserveStringResponses);

        private async void ObserveStringResponses()
        {
            var isInitialized = await _appServiceServiceString.Initialize();
            if (isInitialized)
            {
                _appServiceServiceString.GetResponseObservable(StringInput)
                    .Subscribe(result =>
                    {
                        StringOutput = result;
                    });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
