using CloudGame.Extendions;
using CloudGame.Storage.Database;
using Microsoft.EntityFrameworkCore;
using CloudGame.Logic.Extensions;
using CloudGame.Storage.MS_SQL.InitDatabase;
using CloudGame.Storage.MS_SQL.Extensions;
using CloudGame.Components.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o =>
    {
        // todo: ќзнакомтесь с пон€тием декартова взрыва, AsSplitQuery
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
    }));

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddDataAnnotationsLocalization()
    .AddTagComponents()
    .AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMappers();
builder.Services.AddLogicServices();
builder.Services.AddStorageServices();
builder.Services.AddFeaturesServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var databaseInit = app.Services.GetRequiredService<DatabaseInit>();
databaseInit.InternalSeed();

app.Run();



/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();*/