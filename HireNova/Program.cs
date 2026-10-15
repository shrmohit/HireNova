using HireNova.Data_Connection;
using HireNova.Data_Services;
using HireNova.Data_Services.Repositories;
using HireNova.Data_Services.Repositories.Interfaces;
using HireNova.Data_Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// 1. Database Connection Factory
builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<DbConnectionFactory>();

// 2. Repositories (Dapper / SQL Server Data Access Layer)
builder.Services.AddScoped<IAdminLoginRepository, AdminLoginRepository>();
builder.Services.AddScoped<AdminLoginRepository>();

builder.Services.AddScoped<IAdminDashboardRepository, AdminDashboardRepository>();
builder.Services.AddScoped<AdminDashboardRepository>();

builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();
builder.Services.AddScoped<AdminUserRepository>();

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<CandidateRepository>();

builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();
builder.Services.AddScoped<RecruiterRepository>();

// 3. Business Services (Service Layer)
builder.Services.AddScoped<IAdminLoginService, AdminLoginService>();
builder.Services.AddScoped<AdminLoginService>();

builder.Services.AddScoped<IAdminDashboardService, AdminDashboardService>();
builder.Services.AddScoped<AdminDashboardService>();

builder.Services.AddScoped<IAdminUserService, AdminUserService>();
builder.Services.AddScoped<AdminUserService>();

builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<CandidateService>();

builder.Services.AddScoped<IRecruiterService, RecruiterService>();
builder.Services.AddScoped<RecruiterService>();

builder.Services.AddScoped<IDatabaseTestService, DatabaseTestService>();
builder.Services.AddScoped<DatabaseTestService>();

// Session configuration
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// Session must be enabled before controller actions execute
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();