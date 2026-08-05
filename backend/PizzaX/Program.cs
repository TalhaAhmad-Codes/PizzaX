using PizzaX.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

/* <----- Services Registration -----> */
builder.Services.AddControllers();
//builder.Services.AddApplicationServices();
builder.Services.AddOpenApi();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddHangfireServices(builder.Configuration);
builder.Services.AddProviders();
builder.Services.AddMediatRPipeline();

var app = builder.Build();

app.UseApplicationServices();

app.Run();
