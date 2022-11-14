using Serilog;
using Serilog.Events;
using TelegramSink;

var builder = WebApplication.CreateBuilder(args);
//builder.Logging.AddProvider(new MyLoggerProvider());

var logger = new LoggerConfiguration()
    .WriteTo.File(
        path: "LogFile.json",
        rollingInterval: RollingInterval.Minute)
    .WriteTo.TeleSink("5607367985:AAGWM3oVTXSjFLFh_rN6uC30d5--phQXJaw", "893692412")
    .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
