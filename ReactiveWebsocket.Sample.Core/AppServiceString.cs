using System;
using System.Threading.Tasks;
using ReactiveWebsocket.Public;

namespace ReactiveWebsocket.Sample.Core
{
    /// <summary>
    /// This class demonstartes the use of string websocket API
    /// </summary>
    public class AppServiceString
    {
        private StringWebsocketClient _socket;
        private const string Uri = "ws://reactivewebsocket.azurewebsites.net/ReactiveWebSocketServer/stringdemo";
        private bool _isInitialized = false;

        public async Task<bool> Initialize()
        {
            if (_isInitialized)
            {
                return await Task.FromResult(true);
            }
            _socket = new StringWebsocketClient(new Uri(Uri));
            var result = await _socket.ConnectAsync();
            _isInitialized = result;
            return result;
        }

        // This method demonstartes string websocket API
        public IObservable<string> GetResponseObservable(string response)
        {
            // The second argument of the parameter specifies that we do not want to 
            // filter messages. We will get all responses from server here
            return _socket.GetObservable(response, s => true);
        }
    }
}