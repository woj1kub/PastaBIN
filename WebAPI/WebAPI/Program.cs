using BLL_EF;
using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PastaBINContext>();

builder.Services.AddScoped<PastaGroupSharingService>();
builder.Services.AddScoped<PastaImgService>();
builder.Services.AddScoped<PastaTxtService>();
builder.Services.AddScoped<PastaService>();
builder.Services.AddScoped<CookService>();
builder.Services.AddScoped<PastaSharingSettingsService>();

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
