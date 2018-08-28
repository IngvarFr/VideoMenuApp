using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuApp.Core.Entity;

namespace VideoMenuApp.Core.ApplicationService
{
    interface IVideoService
    {
        Video NewVideo(string name, string genre);
        List<Video> GetAllVideos();
        Video FindVideoById(int id);
        Video UpdateVideo(Video video);
        Video DeleteVideo(Video video);
        List<Video> SearchByName(string term);
        List<Video> SearchByGenre(string term);
    }
}
