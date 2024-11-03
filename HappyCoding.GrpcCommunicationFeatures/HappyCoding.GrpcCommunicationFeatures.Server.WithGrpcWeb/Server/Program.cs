using HappyCoding.GrpcCommunicationFeatures.Server.WithGrpcWeb.Server.GrpcServices;

namespace HappyCoding.GrpcCommunicationFeatures.Server.WithGrpcWeb.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ###### Configure services
        
        builder.Services.AddGrpc();
        
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();

        builder.Services.AddRazorComponents()
            .AddInteractiveWebAssemblyComponents();


        // ###### Configure request pipeline

        var app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseHsts();
        }

        app.UseStaticFiles();
        
        app.UseRouting();
        app.UseAntiforgery();
        
        // gRPC-Web
        app.UseGrpcWeb();
        app.MapGrpcService<GreeterService>().EnableGrpcWeb();

        app.MapRazorPages();
        app.MapControllers();
        app.MapRazorComponents<App>()
            .AddInteractiveWebAssemblyRenderMode()
            .AddAdditionalAssemblies(typeof(HappyCoding.GrpcCommunicationFeatures.Server.WithGrpcWeb.Client._Imports).Assembly);

        app.Run();
    }
}