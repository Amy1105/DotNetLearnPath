using AutoMapper;
using AutoMapperDemo;
using AutoMapperDemo.Models;
using AutoMapperDemo.Profiles;
using AutoMapperDemo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;


try
{
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder.Configuration.AddCommandLine(args);
    builder.Configuration.AddEnvironmentVariables(prefix: "PREFIX_");
    builder.Environment.ContentRootPath = Directory.GetCurrentDirectory();
    builder.Configuration.AddJsonFile("appsetting.json", optional: true);
    //var str = builder.Configuration.GetSection("ConnectionStrings")["SchoolDB"];
    builder.Services.AddDbContext<SchoolContext>();

    #region 注册automapper
    // // 方式一：
    // builder.Services.AddAutoMapper(cfg =>
    // {
    //     // 手动配置映射规则
    //     cfg.CreateMap<User, UserDto>();
    //});

    // //方式二：
    // builder.Services.AddAutoMapper(cfg =>
    // {
    //     cfg.AddMaps(typeof(Program).Assembly);
    //     // 或者显式添加特定Profile
    //     cfg.AddProfile<MyEntityProfile>();
    // });


    //方式三：
    //    var assemblies = new[] {
    //    typeof(AutoMapperDemo).Assembly    
    //};

    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
   builder.Services.AddAutoMapper(cfg => {

        cfg.AddMaps(assemblies);
       cfg.DestinationMemberNamingConvention = new LambdaNamingConvention(
         match => {
             var value = match.Value;
             if (value.StartsWith("fld_"))
             {
                 return value.Substring(4);
             }
             return value;
         },
         new PascalCaseNamingConvention().SplittingExpression
     );
   });

    #endregion

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





