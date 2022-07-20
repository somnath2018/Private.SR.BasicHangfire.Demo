using BasicHangfire.Demo.Service;
using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseDefaultTypeSerializer()
    .UseMemoryStorage());
    builder.Services.AddHangfireServer();
    builder.Services.AddSingleton<IDemoPrintService, DemoPrintService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseHangfireDashboard();

    var myService = app.Services.GetRequiredService<IDemoPrintService>();
    RecurringJob.AddOrUpdate(
     "Run every minute sam-job",
     () =>  app.Services.GetRequiredService<IDemoPrintService>().Print(),
     Cron.Minutely);


app.Run();
