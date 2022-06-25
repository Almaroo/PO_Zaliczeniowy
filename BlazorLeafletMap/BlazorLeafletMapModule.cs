namespace BlazorLeafletMap
{
    public partial class BlazorLeafletMapModule
    {
        public async ValueTask<string> InitializeMap()
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>(BlazorLeafletMapModule.Methods.InitializeMap, Array.Empty<object>());
        }
    }
}
