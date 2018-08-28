using Microsoft.Extensions.DependencyInjection;
using System;
using VideoMenuApp.Core.ApplicationService;
using VideoMenuApp.Core.DomainService;
using VideoMenuApp.Infrastructure.Data.Repositories;

namespace VideoMenuApp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IVideoRepository, VideoRepository>();
            serviceCollection.AddScoped<IVideoService, VideoService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetService<IPrinter>();
        }
    }
}
