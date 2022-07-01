using Microsoft.JSInterop;

namespace BlazorLeafletMap
{
    public partial class BlazorLeafletMapModule
    {

        private IJSObjectReference mapObject;
        private Dictionary<string, IJSObjectReference> mapPoints;

        public async Task InitializeMap(Action<MapOptions> options)
        {
            var initializeOptions = new MapOptions();
            options(initializeOptions);

            var module = await moduleTask.Value;
            mapObject = await module.InvokeAsync<IJSObjectReference>(Methods.InitializeMap, initializeOptions);            
        }

        public async Task DrawPoint(MapPoint point)
        {
            var module = await moduleTask.Value;
            await module.InvokeAsync<IJSObjectReference>(Methods.DrawPoint, mapObject, point);
        }

        public async Task FlyTo(decimal latitude, decimal longitude)
        {
            await mapObject.InvokeVoidAsync("flyTo", new[] {latitude, longitude});
        }

        partial void DisposeCustom()
        {
            Task.WaitAll(mapObject.DisposeAsync().AsTask());
        }
    }
}
