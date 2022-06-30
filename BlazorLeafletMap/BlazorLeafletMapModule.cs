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
        }

        public async Task FlyTo(decimal latitude, decimal longitude)
        {
            await mapObjectReference.InvokeVoidAsync("flyTo", new[] {latitude, longitude});
        }
    }
}
