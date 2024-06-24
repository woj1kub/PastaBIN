using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using System.Text;
using System.Threading.Tasks;
using WebAPI;
using static Quartz.Logging.OperationName;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7023", // Adres serwera API
        ValidAudience = "https://localhost:4200", // Adres frontendowego klienta
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bardzoseketrynykodktorymusibycwtajemnicy")),

    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            // Logowanie b³êdów autoryzacji
            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
            return Task.CompletedTask;
        }
    };
});

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

// Add Quartz.NET
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    q.AddJob<DeleteExpiredSharingJob>(group => group
        .WithIdentity("deleteExpiredSharingJob"));

    q.AddJob<DeleteExpiredPastaTxt>(group => group
        .WithIdentity("deleteExpiredPastaTxtJob"));

    q.AddJob<DeleteExpiredPastaGroups>(group => group
        .WithIdentity("deleteExpiredPastaGroupsJob"));

    q.AddJob<DeleteExpiredPastaImg>(group => group
       .WithIdentity("deleteExpiredPastaImgJob"));

    q.AddTrigger(trigger => trigger
        .WithIdentity("deleteExpiredPastaGroupsJobTrigger")
        .ForJob("deleteExpiredPastaGroupsJob")
        .StartNow()
        .WithSimpleSchedule(schedule => schedule
            .WithIntervalInMinutes(15)
            .RepeatForever())); 

    q.AddTrigger(trigger => trigger
        .WithIdentity("deleteExpiredPastaImgJobTrigger")
        .ForJob("deleteExpiredPastaImgJob")
        .StartNow()
        .WithSimpleSchedule(schedule => schedule
            .WithIntervalInMinutes(15)
            .RepeatForever())); 

    q.AddTrigger(trigger => trigger
        .WithIdentity("deleteExpiredSharingJobTrigger")
        .ForJob("deleteExpiredSharingJob")
        .StartNow()
        .WithSimpleSchedule(schedule => schedule
            .WithIntervalInMinutes(15)
            .RepeatForever()));

    q.AddTrigger(trigger => trigger
        .WithIdentity("deleteExpiredPastaTxtJobTrigger")
        .ForJob("deleteExpiredPastaTxtJob")
        .StartNow()
        .WithSimpleSchedule(schedule => schedule
            .WithIntervalInMinutes(15)
            .RepeatForever()));
    
});


builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(opt => opt.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .Build());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
