using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuApp.Core.DomainService;
using VideoMenuApp.Core.Entity;

namespace VideoMenuApp.Infrastructure.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private int id = 1;
        private List<Video> _videos = new List<Video>();

        public Video Create(Video video)
        {
            video.Id = id++;
            _videos.Add(video);
            return video;
        }

        public Video FindById(int id)
        {
            foreach (var video in _videos)
            {
                if (video.Id.Equals(id))
                    return video;
            }
            return null;
        }

        public List<Video> GetAll()
        {
            return _videos;
        }

        public Video Update(Video video)
        {
            var videoToUpdate = FindById(video.Id);
            if (videoToUpdate != null)
            {
                videoToUpdate.Name = video.Name;
                videoToUpdate.Genre = video.Genre;
                return videoToUpdate;
            }
            return null;
        }

        public Video Delete(int id)
        {
            var videoToDelete = FindById(id);
            if(videoToDelete != null)
            {
                _videos.Remove(videoToDelete);
                return videoToDelete;
            }
            return null;
        }
    }
}
