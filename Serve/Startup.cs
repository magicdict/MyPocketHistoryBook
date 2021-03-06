﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InfraStructure.DataBase;
using InfraStructure.Storage;
using HelloChinaApi.BussinessLogic;
using Newtonsoft.Json.Serialization;

namespace HelloChinaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            //MongoDB初始化
            var DBStatus = MongoDbRepository.Init(new string[] { Config.MainDBName, Config.FSDBName }, Config.MainDBName, Config.AliyunConnectionString);
            if (!DBStatus)
            {
                System.Console.WriteLine("DB Error!!");
                return;
            }
            //MongoGFS初始化
            DBStatus = MongoStorage.Init(Config.AliyunConnectionString);
            if (!DBStatus)
            {
                System.Console.WriteLine("FileSystem Error!!");
                return;
            }
            //初始化图片
            if (Config.IsInitData) InitFile.InitImage();
            if (Config.IsInitData)
            {
                //启动数据
                InitTreasure.Init();        //文物
                InitPoetry.Init();          //诗词
                InitPoetryContent.Init();   //诗词内容
                InitEvent.Init();           //事件
                InitPersonage.Init();       //人物
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => { options.EnableEndpointRouting = false; })  //Core3.0.0 - Preview4
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //DefaultContractResolver 不进行大小写转换
            services.AddMvc().AddNewtonsoftJson(op => op.SerializerSettings.ContractResolver = new DefaultContractResolver());  //Core3.0.0 - Preview7：不指定则 是驼峰
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
