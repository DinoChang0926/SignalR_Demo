using Microsoft.AspNetCore.Http.Connections;
using SignalR_Demo.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region �Ϻ����i�H�x�s�᭫�㤣�ݭ��}����(�ݦw�� Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation)
builder.Services.AddMvc().AddRazorRuntimeCompilation();
#endregion
builder.Services.AddSignalR();
builder.Services.AddScoped<ChatHub>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapHub<ChatHub>("/chatHub",options =>
{
    options.Transports =
        HttpTransportType.WebSockets ;
   
});
app.Run();
