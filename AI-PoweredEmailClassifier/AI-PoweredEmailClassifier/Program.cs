using AI_PoweredEmailClassifier.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Load configuration from appsettings + user secrets
builder.Configuration.AddUserSecrets<Program>();

// ✅ Register services
builder.Services.AddScoped<GeminiEmailClassifier>();
builder.Services.AddControllers();

// ✅ Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AI Email Classifier API",
        Version = "v1",
        Description = "Automatically classify emails into categories like Support, Sales, Urgent, Spam, etc.",
        Contact = new OpenApiContact
        {
            Name = "Shivraj Randive",
            Email = "shivraj@example.com", // use your real or professional email
            Url = new Uri("https://your-portfolio.com") // optional
        }

    });
});

var app = builder.Build();

// ✅ Swagger UI in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "AI Email Classifier API v1");
        options.RoutePrefix = "swagger"; // optional: set to "" for root access
    });
}

// ✅ Middleware order matters
app.UseHttpsRedirection();
app.UseStaticFiles(); // To serve index.html

// ✅ Serve index.html at root
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/index.html");
});

app.UseAuthorization();
app.MapControllers();

app.Run();
