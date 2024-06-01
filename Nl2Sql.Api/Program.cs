using Nl2Sql.Api;
using Nl2Sql.Api.Gpt;
using Nl2Sql.Api.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGptServices();
builder.Services.AddGrpc()
    .AddServiceOptions<TranslatorService>(options => { options.Interceptors.Add<TranslatorServiceValidators>(); });
builder.Services.AddGrpcReflection();

var app = builder.Build();
if (app.Environment.IsDevelopment()) app.MapGrpcReflectionService();

app.MapGrpcService<TranslatorService>();
// Configure the HTTP request pipeline.
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();