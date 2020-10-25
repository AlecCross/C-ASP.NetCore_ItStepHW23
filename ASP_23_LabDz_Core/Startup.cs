using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASP_23_LabDz_Core
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public readonly IWebHostEnvironment _enw;
        public Startup(IWebHostEnvironment enw)
        {//�� ��������� ����� ������ ������ ������ �� ����� ��� ���������� ���� ������
            this._enw = enw;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //���������������� ������� �� ��������� ��� �������� ��� ���������� ��
            //�� ����� ������� �������� ��� �������
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //env.EnvironmentName = Environments.Production;//������ ��� ����� ���������� ��������� �������
            //��������� ��������� ������� Project/'NameAppProperties/Debug/Enviroment variables'
            //if (env.IsDevelopment())
            //{

            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //������������� ������ ������� � ���������
            //app.Map("/index", Index);//����������� �������� � ������
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Uploaded to Github!");
            //    });
            //});

            //�������� middleWare
            //int x = 5, y = 10, z= 0;
            //app.Use() ���������� �������
            //������ �������� ����������� �������� ����� ������� ��������,
            //������ ��������
            //�� ��������� context
            int n = -1;
            app.Use(async (context, next) =>//����� ������ ������� HTTP ������ �� ������������ � ������ USe
            {
                n++;
                //    //z =x + y;
                //    //����� ��������� ����� Invoke() ������� �������� ����������
                //    //���������� ������ middleWare app.Run � ����� ������
                //    //��� ����� ������������ ��������� ��������:
                //    //, next ������ �������� ��� �� ��������� ��������� ����� middleWare ������ ������ "����"
                await next.Invoke();
                //    //�� ������������� ������ Use ��������� context.Response.WriteAsync. 
                //    //��� ��� ��������� ����� Use, context.Response.WriteAsync
                //    //����������� �� ��������� ����� next.Invoke();

                //    //���� ���� � Content.Length �� ����� ��������
                //   // ������ ������ ������ ���� ������ � ����� �����
                
            });
            
            
            app.Run(async (context)=> //��������� ��������� ����������� ����������� � ���� ��������� �������� �����������
            {
                //� ���� ��������� ������� ���� ������ � ��������� �������

                //await context.Response.WriteAsync($"<p>Hello world from {_enw.ApplicationName}.</p><p>Now app in {env.EnvironmentName}</p>");
                //x *= 2;
                //await context.Response.WriteAsync($"x = {x}");
               
                int a = 0;
                int b = 1;

                for (int i = 0; i < n - 1; i++)
                {
                    int temp = b;
                    b = a + b;
                    a = temp;
                    
                }
                

                await context.Response.WriteAsync($"<p>Press F5</p><p>Fibonacci number {n} = {b}</p>");
                
            });
            
        }


        //private static async Task Index(IApplicationBuilder app)
        //{
        //    await app.
        //}
        
        //public ContentResult GetFibanacci(int n)
        //{
        //    int a = 0;
        //    int b = 1;

        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        int temp = b;
        //        b = a + b;
        //        a = temp;
        //    }

        //    return Content($"<p>�������� ����� {n} = {b}</p>");
        //}

        //public int fib(int n)
        //{
        //    if (n == 0)
        //    {
        //        return 0;
        //    }
        //    else if (n == 1)
        //    {
        //        return 1;
        //    }

        //    return fib(n - 1) + fib(n - 2);
        //}
        //public ContentResult GetFibanacciR(int n)
        //{
        //    return Content($"<p>�������� ����� {n} = {fib(n)}</p>");
        //}

    }
}
