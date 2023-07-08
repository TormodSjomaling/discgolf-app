using discgolf_app_dataaccess.Mappers;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICsvMapper, CsvMapper>();
builder.Services.AddSingleton<Client>(sp =>
{
    var supabaseUrl = configuration["Supabase:Url"];
    var supabaseKey = configuration["Supabase:ApiKey"];
    var options = new SupabaseOptions
    {
        AutoRefreshToken = true,
        AutoConnectRealtime = true,
        // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
    };
    return new Client(supabaseUrl, supabaseKey);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
