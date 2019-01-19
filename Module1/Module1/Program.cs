using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Module1
{
    public class Program
    {
        //This is main application entry
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        //entry main will invoke this function to create a webhost and run it
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
