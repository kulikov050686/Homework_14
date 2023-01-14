using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Homework_14
{
    public static class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        [STAThread]
        public static void Main()
        {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        /// <summary>
        /// Создание хоста
        /// </summary>
        /// <param name="args"> Аргументы командной строки </param>      
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .UseContentRoot(Environment.CurrentDirectory)
            .ConfigureAppConfiguration((host, cfg) => 
            {
                cfg.SetBasePath(Environment.CurrentDirectory);
                cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices(App.ConfigureServices)
        ;
    }
}
