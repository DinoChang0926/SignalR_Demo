using Microsoft.JSInterop;
namespace SignalR_Demo.SignalR
{  

    public class Connetion
    {
        private readonly IJSRuntime js;
        public Connetion(IJSRuntime js)
        {
            this.js = js;
        }
        public async ValueTask TickerChanged(string symbol, decimal price)
        {
            await js.InvokeVoidAsync("displayTickerAlert1", symbol, price);
        }
    }
}
