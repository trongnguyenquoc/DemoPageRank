using DemoPageRank.API.Apis;
using DemoPageRank.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<SearchSettings>(builder.Configuration.GetSection("SearchProvider"));
builder.Services.AddProblemDetails();

builder.AddApplicationServices();

var withApiVersioning = builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

var api = app.MapGroup("api");
api.MapPageRankApi();

app.Run();
