using Artsofte.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var typeOfContent = typeof(Program);
builder.Services.AddDbContext<MssqlSqlContext>(options =>
    options.UseNpgsql
    (
        builder.Configuration.GetConnectionString("Connection"),
        b => b.MigrationsAssembly(typeOfContent.Assembly.GetName().Name)
    )
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("*", corsPolicyBuilder =>
    {
        corsPolicyBuilder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddResponseCompression();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.UseHsts();

app.UseResponseCompression();

app.UseRouting();
app.UseCors("*");
app.MapControllers();

app.Run();