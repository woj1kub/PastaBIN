using BLL;
using DAL;
using BLL_EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PastaBINContext>();
builder.Services.AddScoped<ICook, CookService>();
builder.Services.AddScoped<IPastaHistory, PastaHistoryService>();
builder.Services.AddScoped<IPastaImg, PastaImgService>();
builder.Services.AddScoped<IPastaInfo, PastaInfoService>();
builder.Services.AddScoped<IPastaText, PastaTestService>();
builder.Services.AddScoped<IPastaSharingSettings, PastaSharingSettingsService>();


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
