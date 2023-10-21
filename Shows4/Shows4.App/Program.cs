using Microsoft.AspNetCore.Identity;
using Shows4.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddRoles<IdentityRole>() 
        .AddEntityFrameworkStores<ApplicationDbContext>();
       
builder.Services.AddRazorPages();
// Adicionar applicationUser Manager para adicionar cartao credito

builder.Services.AddScoped<ApplicationUserManager, ApplicationUserManager>();
builder.Services.AddControllersWithViews();
// .AddRoles<IdentityRole>()


// Configura��o de servi�os criados 
builder.Services.AddScoped<CountryRepository>();
builder.Services.AddScoped<WriterRepository>();
builder.Services.AddScoped<GenresRepository>();
builder.Services.AddScoped<CastRepository>();
builder.Services.AddScoped<SerieRepository>();
builder.Services.AddScoped<SeasonRepository>();
builder.Services.AddScoped<EpisodeRepository>();
builder.Services.AddScoped<UserApplicationRepository>();


//Inicializar a criaçao de Role administrador como o user administrador
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//Chamar a criaçao do user admin
await CreatePerfilUserAsync(app);

app.UseAuthorization();

app.MapRazorPages();

app.Run();
//Invocar os metodos 

async Task CreatePerfilUserAsync(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope()) 
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        await service.SeedRolesAsync();
        await service.SeedUserAsync();
    }
}