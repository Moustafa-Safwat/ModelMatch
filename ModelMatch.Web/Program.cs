using System.Reflection;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ModelMatch.User;
using ModelMatch.Project;
using ModelMatch.Matching;
using ModelMatch.Clustering;
using FastEndpoints.Security;

var builder = WebApplication.CreateBuilder(args);


IList<Assembly> assemblies = [typeof(Program).Assembly];
// Register Books Services
builder.Services.AddUserModule(builder.Configuration, assemblies)
                .AddProjectModule(builder.Configuration, assemblies)
                .AddMatchingModule(builder.Configuration, assemblies)
                .AddMClusteringModule(builder.Configuration, assemblies)
                .AddAuthenticationJwtBearer(options =>
{
options.SigningKey = builder.Configuration["Auth:JwtSecret"];
})
                .AddAuthorization()
                .AddFastEndpoints()
                .AddSwaggerGen();

// Have to define the Auth schema of the FastEndpoints in the Authentication
builder.Services.AddAuthentication(options =>
{
options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(assemblies.ToArray()));

//builder.Host.UseSerilog((context, configuration) =>
//  configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

//app.UseSerilogRequestLogging(); // Automatic HTTP requests logging

if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}

if (app.Environment.EnvironmentName == "Testing")
{ // Ensure User secrets is seen in Testing Environment
  // To can access the user secrets in the test environment, you need to add the following line to the Program.cs file.
builder.Configuration.AddUserSecrets<Program>();
}
//app.UseHttpsRedirection();
app.UseAuthentication()
  .UseAuthorization();

app.UseFastEndpoints();

app.Run();

public partial class Program { } // For tesing only
