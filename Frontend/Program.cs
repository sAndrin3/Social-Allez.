using Blazored.LocalStorage;
using Frontend.Services.Auth;
// using Frontend.Services.Users;
using Frontend.Services.Posts;
using Frontend.Services.comments;
using Frontend.Services.AuthProvider;
using Frontend.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Frontend;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

 // localstorage registration
            builder.Services.AddBlazoredLocalStorage();


            builder.Services.AddScoped<IAuthInterface, AuthService>();
            builder.Services.AddScoped<IPostInterface, PostService>();
            builder.Services.AddScoped<ICommentInterface, CommentsService>();
            // builder.Services.AddScoped<IUserInterface, UserService>();

            // Authprovider configuration
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvideService>();

await builder.Build().RunAsync();
