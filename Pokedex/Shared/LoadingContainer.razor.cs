using Microsoft.AspNetCore.Components;

namespace Pokedex.Shared
{
    public enum LoadingContainerState { Loading, Loaded, Error }

    public partial class LoadingContainer
    {
        [Parameter]
        public LoadingContainerState state { get; set; }

        [Parameter]
        public RenderFragment Loading { get; set; }

        [Parameter]
        public RenderFragment Loaded { get; set; }

        [Parameter]
        public RenderFragment ErrorContent { get; set; }

    }
}
