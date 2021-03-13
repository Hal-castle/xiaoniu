using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using System.Threading.Tasks;
using SqlSugar;
namespace UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new DbContext<object>().CreateTable(false, 50, typeof(ULog), typeof(Student), typeof(Units), typeof(InsertApply), typeof(AppArrange), typeof(Developers), typeof(Staff), typeof(Staff_Role), typeof(Role), typeof(Role_Power), typeof(Power));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureLogging(LoggingBuilder => {
                object p = LoggingBuilder.AddLog4Net();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
