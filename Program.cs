var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserValidator>();
// Register middlewares
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddScoped<Middleware.LoggingMiddleware>();
builder.Services.AddScoped<Middleware.AuthenticationMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<Middleware.LoggingMiddleware>();
app.UseMiddleware<Middleware.AuthenticationMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();