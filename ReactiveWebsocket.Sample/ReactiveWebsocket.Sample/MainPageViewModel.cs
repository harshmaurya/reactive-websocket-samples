using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ReactiveWebsocket.Sample.Annotations;
using ReactiveWebsocket.Sample.Core;
using Xamarin.Forms;

namespace ReactiveWebsocket.Sample
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
                OnPropertyChanged();
            }
        }

        public ICommand StringCommand => new Command(ObserveStringResponses);

        private async void ObserveStringResponses()
        {
            var isInitialized = await _appServiceServiceString.Initialize();
            if (isInitialized)
            {
                _appServiceServiceString.GetResponseObservable(StringInput)
                    .Subscribe()
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
