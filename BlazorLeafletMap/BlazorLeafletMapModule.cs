using Microsoft.JSInterop;

namespace BlazorLeafletMap
{
    public partial class BlazorLeafletMapModule
    {

        private IJSObjectReference mapObjectReference;

        public async Task InitializeMap(Action<MapOptions> options)
        {
            var initializeOptions = new MapOptions();
            options(initializeOptions);

            var module = await moduleTask.Value;
            mapObjectReference = await module.InvokeAsync<IJSObjectReference>(BlazorLeafletMapModule.Methods.InitializeMap, initializeOptions);

            await FlyTo(44.050251m, 15.300985m);
        }

        public async Task FlyTo(decimal latitude, decimal longitude)
        {
            await mapObjectReference.InvokeVoidAsync("flyTo", new[] {latitude, longitude});
        }
    }
}
