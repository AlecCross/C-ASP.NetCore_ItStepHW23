using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASP_23_LabDz_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //��� ����� ���������������� �� ��� ������ ����������
            //Initializer : DropCreateDatabaseIfModelChanges
            CreateHostBuilder(args).Build().Run();
        }
        //��������� ��������� ��������� ������. 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {                        //��������� ��������� ���������� � ����� UseStartup � ��� �������� ��� �� ��������� Startup
                    webBuilder.UseStartup<Startup>();
                });
    }
}
