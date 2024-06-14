using API.Middlewares;
using Common;
using Common.Application.ChatHub;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommon(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>()
    .UseMiddleware<UnitOfWorkMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .SetIsOriginAllowed(_ => true)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());

app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    await DependencyInjection.InitializeDatabase(scope.ServiceProvider, builder.Configuration);
}

app.MapHub<ChatHub>("/Chat");

app.Run();