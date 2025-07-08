using AutoMapperDemo;
using AutoMapperDemo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


try
{
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Configuration.AddCommandLine(args);
    builder.Configuration.AddEnvironmentVariables(prefix: "PREFIX_");
    builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();
    builder.Configuration.AddJsonFile("appsetting.json", optional: true);
    //var str = builder.Configuration.GetSection("ConnectionStrings")["SchoolDB"];
    builder.Services.AddDbContext<SchoolContext>();
    builder.Services.AddTransient<BulkExecute>();
 

    var app = builder.Build();
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var bulkExecute = services.GetRequiredService<BulkExecute>();
        bulkExecute.InitDB();         
    }  
    Console.WriteLine("Done.");
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}





