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
        {//Мы обеспечим после вызова констр ссылку на среду где развернуто наше прилож
            this._enw = enw;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //Зарегестрировать сервисы по умолчанию для сервисов для управления БД
            //Не нужно ставить нинджект или автофак
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //env.EnvironmentName = Environments.Production;//Поидее так можно установить состояние проекта
            //Настройка состояния проекта Project/'NameAppProperties/Debug/Enviroment variables'
            //if (env.IsDevelopment())
            //{

            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //Сопоставления адреса запроса с делегатом
            //app.Map("/index", Index);//Вноситсятся элементы в проект
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Uploaded to Github!");
            //    });
            //});

            //Элементы middleWare
            //int x = 5, y = 10, z= 0;
            //app.Use() использует делегат
            //Первый параметр обобщенного делегата имеет входной параметр,
            //Второй выходной
            //Он принимает context
            int n = -1;
            app.Use(async (context, next) =>//Когда прийдёт входящи HTTP запрос он обработается в методе USe
            {
                n++;
                //    //z =x + y;
                //    //После вызовется метод Invoke() который передаст управление
                //    //следующему уровню middleWare app.Run в нашем случае
                //    //Что такое конвеерность обработки запросов:
                //    //, next второй параметр как бы запускает следующий метод middleWare внутри своего "тела"
                await next.Invoke();
                //    //Не рекомендуется внутри Use описывать context.Response.WriteAsync. 
                //    //Так как следующий после Use, context.Response.WriteAsync
                //    //объединится со следующим через next.Invoke();

                //    //Речь идет о Content.Length он будет неверным
                //   // Запись ответа должна быть только в одном месте
                
            });
            
            
            app.Run(async (context)=> //Добавляет конеченое программное обеспечение в цепь обработки запросов приложением
            {
                //В этом контексте запроса есть доступ к параметры запроса

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

        //    return Content($"<p>Фибаначи числа {n} = {b}</p>");
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
        //    return Content($"<p>Фибаначи числа {n} = {fib(n)}</p>");
        //}

    }
}
