using System.Reflection;
using Backend.Repositories.BikeRepo;
using Backend.Repositories.TodoRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IBikeRepository, BikeRepositorySQLite>();
builder.Services.AddSingleton<ITodoRepository, TodoRepositoryInMemory>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    // Fetch the XML file name based on your application's assembly name
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    
    // Combine it with the application's base directory path
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    
    // Tell Swagger to use the XML comments file
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Serves the Swagger JSON
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();