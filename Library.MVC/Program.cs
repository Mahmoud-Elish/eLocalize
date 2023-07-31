using Microsoft.EntityFrameworkCore;
using Library.DAL;
using Library.BL;

var builder = WebApplication.CreateBuilder(args);

#region Default
// Add services to the container.
builder.Services.AddControllersWithViews();
#endregion

#region ConnectionString

builder.Services.AddDbContext<LibraryContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

#endregion

#region InjectionForRepositories
builder.Services.AddScoped<IBooksRepo, BooksRepo>();
builder.Services.AddScoped<IMembersRepo, MembersRepo>();
builder.Services.AddScoped<IBookMembersRepo, BookMembersRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion


#region InjectionForServices
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IMembersService, MembersService>();
builder.Services.AddScoped<IBookMembersService, BookMembersService>();
#endregion

#region .Net Core possible object cycle 

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");

app.Run();
