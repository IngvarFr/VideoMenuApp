using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuApp.Core.DomainService;
using VideoMenuApp.Infrastructure.Data.Repositories;

namespace VideoMenuApp.UI
{
    class Printer
    {
        static IVideoRepository videoRepository;

        public Printer()
        {
            videoRepository = new VideoRepository();
        }

    }
}
