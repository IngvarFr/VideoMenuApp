using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuApp.Core.DomainService;
using VideoMenuApp.Core.Entity;

namespace VideoMenuApp.Core.ApplicationService
{
    class VideoService : IVideoService
    {
        private IVideoRepository _videoRepository;

        public VideoService()
        {
            _videoRepository = new VideoRepository;
        }

        public Video DeleteVideo(Video video)
        {
            throw new NotImplementedException();
        }

        public Video FindVideoById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAllVideos()
        {
            throw new NotImplementedException();
        }

        public Video NewVideo(string name, string genre)
        {
            throw new NotImplementedException();
        }

        public List<Video> SearchByGenre(string term)
        {
            throw new NotImplementedException();
        }

        public List<Video> SearchByName(string term)
        {
            throw new NotImplementedException();
        }

        public Video UpdateVideo(Video video)
        {
            throw new NotImplementedException();
        }
    }
}
