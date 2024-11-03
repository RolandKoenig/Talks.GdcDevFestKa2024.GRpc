using HappyCoding.GrpcCommunicationFeatures.AspNetClient;
using HappyCoding.GrpcCommunicationFeatures.AspNetClient.Components;
using HappyCoding.GrpcCommunicationFeatures.Shared;

var builder = WebApplication.CreateBuilder(args);

// Shared services from this sample application
builder.Services.AddSharedServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add gRPC
GrpcSetup.SetupGrpc(builder.Services, builder.Configuration);
// GrpcSetup.SetupGrpcWithSocketHttpHandlerConfig(builder.Services, builder.Configuration);
// GrpcSetup.SetupGrpcWithLoadBalancing(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();