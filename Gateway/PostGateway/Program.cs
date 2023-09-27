using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using ThePostGateway.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Use the authentication extension for checking the token
builder.AddAppAuthentication();

// ocelot configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false,reloadOnChange:true);
builder.Services.AddOcelot(builder.Configuration);

// cors
builder.Services.AddCors(options => options.AddPolicy("policy1", build =>{
    // build.WithOrigins("http://localhost:5120");
    build.AllowAnyOrigin();
    build.AllowAnyHeader();
    build.AllowAnyMethod();
}
));

var app = builder.Build();

app.UseCors("policy1");
app.MapGet("/", () => "Hello World!");
app.UseOcelot().GetAwaiter().GetResult();
app.Run();
