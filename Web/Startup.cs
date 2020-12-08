using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.Library;
using Web;
using Web.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region CORS
            //����ڶ��ַ������������ԣ��ǵ��±�app������
            services.AddCors(c =>
            {

                //һ��������ַ���
                c.AddPolicy("LimitRequests", policy =>
                {
                    // ֧�ֶ�������˿ڣ�ע��˿ںź�Ҫ��/б�ˣ�����localhost:8000/���Ǵ��
                    // ע�⣬http://127.0.0.1:1818 �� http://localhost:1818 �ǲ�һ���ģ�����д����
                    policy
                    .WithOrigins("http://localhost:54793", "http://localhost:5001")
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            });
            #endregion
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = false;
                //options.Cookie.IsEssential = true;
                //options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
                //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });
            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalActionFilter>();
                options.Filters.Add<GlobalExceptionFilter>();
            });

            //����ע�루Services��Repository��
            foreach (var item in Bootstrapper.GetClassName())
            {
                foreach (var typeArray in item.Value)
                {
                    services.AddScoped(typeArray, item.Key);
                }
            }
            //�������԰��ļ�������
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            //��ʱ����
            services.AddTimedJob();

            #region Quartz����
            //���Quartz����
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            // "0 42 10 * * ?"  ÿ��ʮ��42ִ��
            // "0 0 0 * * ?"ÿ���賿0��ִ��
            // "0 0/1 * * * ?"ÿһ����ִ��һ��
            //��ʱ��Ϣ
            services.AddSingleton<SendMessageTimeJob>();
            services.AddSingleton(new JobSchedule(jobType: typeof(SendMessageTimeJob), cronExpression: "0 0/1 * * * ?"));
            services.AddHostedService<QuartzHostedService>();
            //ִ��ʱ�����ò����ĵ�
            //https://www.quartz-scheduler.net/documentation/quartz-3.x/tutorial/crontriggers.html#example-cron-expressions
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
                await next();
            });

            #region CORS
            //����ڶ��ַ�����ʹ�ò��ԣ���ϸ������Ϣ��ConfigureService��
            app.UseCors("LimitRequests");//�� CORS �м����ӵ� web Ӧ�ó��������, �������������
            #endregion

            //����CSS���ļ�
            app.UseStaticFiles();
            //ʹ������+�ļ��� ֱ�ӷ���wwwroot��Ŀ¼�ļ�
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = ""
            });

            //ʹ��session
            app.UseSession();

            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("zh-CN"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("zh-CN"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            Handler.GetDIService.Instance = app.ApplicationServices.CreateScope();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Backend",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "Frontend",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });
            app.UseRequestLocalization();
            app.UseAuthentication();
            app.UseTimedJob();

        }
    }
}
