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
            //app.Map("Index", Index);//����������� �������� � ������
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Uploaded to Github!");
            //    });
            //});

            //�������� middleWare
            int x = 5, y = 10, z= 0;
            //app.Use() ���������� �������
            //������ �������� ����������� �������� ����� ������� ��������,
            //������ ��������
            //�� ��������� context
            app.Use(async(context, next) =>//����� ������ ������� HTTP ������ �� ������������ � ������ USe
            {
                z =x + y;
                //����� ��������� ����� Invoke() ������� �������� ����������
                //���������� ������ middleWare app.Run � ����� ������
                //��� ����� ������������ ��������� ��������:
                //, next ������ �������� ��� �� ��������� ��������� ����� middleWare ������ ������ "����"
                await next.Invoke();
                //�� ������������� ������ Use ��������� context.Response.WriteAsync. 
                //��� ��� ��������� ����� Use, context.Response.WriteAsync
                //����������� �� ��������� ����� next.Invoke();

                //���� ���� � Content.Length �� ����� ��������
               // ������ ������ ������ ���� ������ � ����� �����
            });
            app.Run(async (context)=> //��������� ��������� ����������� ����������� � ���� ��������� �������� �����������
            {
                //� ���� ��������� ������� ���� ������ � ��������� �������

                //await context.Response.WriteAsync($"<p>Hello world from {_enw.ApplicationName}.</p><p>Now app in {env.EnvironmentName}</p>");
                x *= 2;
                await context.Response.WriteAsync($"x = {x}");
            });
        }


        //private static async Task Index(IApplicationBuilder app)
        //{
        //    await app.
        //}
    }
}
