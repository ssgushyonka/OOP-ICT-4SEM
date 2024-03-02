namespace HelpHub.Presentation.Http.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddPresentationHttp(this IMvcBuilder builder)
    {
        return builder.AddApplicationPart(typeof(IAssemblyMarker).Assembly);
    }
}