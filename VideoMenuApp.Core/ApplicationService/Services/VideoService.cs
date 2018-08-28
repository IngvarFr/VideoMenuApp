using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoMenuApp.Core.DomainService;
using VideoMenuApp.Core.Entity;

namespace VideoMenuApp.Core.ApplicationService
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public Video DeleteVideo(int id)
        {
            return _videoRepository.Delete(id);
        }

        public Video FindVideoById(int id)
        {
            return _videoRepository.FindById(id);
        }

        public List<Video> GetAllVideos()
        {
            return _videoRepository.GetAll().ToList();
        }

        public Video NewVideo(string name, string genre)
        {
            var newVideo = new Video()
            {
                Name = name,
                Genre = genre
            };
            return _videoRepository.Create(newVideo);
        }

        public List<Video> SearchByGenre(string term)
        {
            var searchVideos = _videoRepository.GetAll();
            searchVideos.Where(video => video.Genre.ToLower().Contains(term.ToLower()));
            return searchVideos.ToList();
        }

        public List<Video> SearchByName(string term)
        {
            var searchVideos = _videoRepository.GetAll();
            searchVideos.Where(video => video.Name.ToLower().Contains(term.ToLower()));
            return searchVideos.ToList();
        }

        public Video UpdateVideo(Video updatevideo)
        {
            var video = FindVideoById(updatevideo.Id);
            video.Name = updatevideo.Name;
            video.Genre = updatevideo.Genre;
            return video;
        }
    }
}
