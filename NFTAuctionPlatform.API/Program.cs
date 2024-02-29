using NFTAuctionPlatform.Repository.Connection;
using NFTAuctionPlatform.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDIServices(builder.Configuration);

//Account
builder.Services.AddScoped<AccountService>();

//Enable CORS
//builder.Services.AddCors(p =>
//    p.AddPolicy("HUG_LOCAL", build =>
//    {
//        //build.WithOrigins("https://localhost:7034",
//        //                  "http://localhost:5034",
//        //                  "https://localhost:7289",
//        //                  "http://localhost:5289",
//        //                  "http://localhost:3000")
//        //     .AllowAnyMethod()
//        //     .AllowAnyHeader()
//        //    .AllowCredentials()
//        //    .SetIsOriginAllowed((hosts) => true);
//        build.WithOrigins("*")
//             .AllowAnyMethod()
//             .AllowAnyHeader();
//    })
//);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("HUG_LOCAL");

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseStaticFiles();// Add middleware for specify the static files in wwwroot


app.UseAuthorization();

app.MapControllers();

app.Run();
