using Kours.DAL;
using Kours.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCFlowersDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("MvcFlowersConnectionString")));

builder.Services.AddScoped<ClientDAL>();
builder.Services.AddScoped<EmployeeDAL>();
builder.Services.AddScoped<PostDAL>();
builder.Services.AddScoped<ProductDAL>();
builder.Services.AddScoped<ServiceDAL>();
builder.Services.AddScoped<SkladDAL>();
builder.Services.AddScoped<StoreAddressDAL>();
builder.Services.AddScoped<ZakazDAL>();

builder.Services.AddSwaggerGen(page =>
{
    page.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    page.SwaggerDoc("client", new OpenApiInfo { Title = "client", Version = "v1" });
    page.SwaggerDoc("employee", new OpenApiInfo { Title = "employee", Version = "v1" });
    page.SwaggerDoc("post", new OpenApiInfo { Title = "post", Version = "v1" });
    page.SwaggerDoc("product", new OpenApiInfo { Title = "product", Version = "v1" });

    page.SwaggerDoc("service", new OpenApiInfo { Title = "service", Version = "v1" });
    page.SwaggerDoc("sklad", new OpenApiInfo { Title = "sklad", Version = "v1" });
    page.SwaggerDoc("storeAddress", new OpenApiInfo { Title = "storeAddress", Version = "v1" });

    page.SwaggerDoc("zakaz", new OpenApiInfo { Title = "zakaz", Version = "v1" });

});

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(page =>
    {
        page.SwaggerEndpoint("/swagger/client/swagger.json", "client");
        page.SwaggerEndpoint("/swagger/employee/swagger.json", "employee");
        page.SwaggerEndpoint("/swagger/post/swagger.json", "post");
        page.SwaggerEndpoint("/swagger/product/swagger.json", "product");
        page.SwaggerEndpoint("/swagger/service/swagger.json", "service");
        page.SwaggerEndpoint("/swagger/sklad/swagger.json", "sklad");
        page.SwaggerEndpoint("/swagger/storeAddress/swagger.json", "storeAddress");
        page.SwaggerEndpoint("/swagger/zakaz/swagger.json", "zakaz");
        page.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
