using System;
using VideoMenuApp.Core.DomainService;
using VideoMenuApp.Infrastructure.Data.Repositories;

namespace VideoMenuApp.UI
{
    class Program
    {
        static IVideoRepository videoRepository;
        static void Main(string[] args)
        {
            videoRepository = new VideoRepository();
        }
    }
}
