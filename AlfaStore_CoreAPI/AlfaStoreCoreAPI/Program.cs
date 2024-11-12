using AlfaStoreCoreAPI.Files.DB;
using AlfaStoreCoreAPI.Files.GraphQlScema.Mutations;
using AlfaStoreCoreAPI.Files.GraphQlScema.Mutations.ModelsMutation;
using AlfaStoreCoreAPI.Files.GraphQlScema.Queries.ModelsQuery;
using AlfaStoreCoreAPI.Files.GraphQlScema.Subscriptions;
using DataAccessLayer;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<MyAppContext>(opt => opt.UseSqlServer());
builder.Services.AddScoped<MyAppContext>(sp => sp.GetRequiredService<IDbContextFactory<MyAppContext>>().CreateDbContext());
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()   
    .AddProjections().AddFiltering().AddSorting()
    .AddInMemorySubscriptions()
    .AddSubscriptionType<Subscribtion>().AddAuthorization();

builder.Services.AddSingleton(FirebaseApp.Create());
builder.Services.AddFirebaseAuthentication();

//builder.Services.AddInMemorySubscribtion();
var app = builder.Build();

//await MyAppContext.checkAndSeedDatabaseAsync();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseWebSockets();
app.UseAuthorization();
app.MapGraphQL();

app.MapRazorPages();
app.MapControllers();

app.Run();
