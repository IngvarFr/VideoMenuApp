using System.Collections.Generic;
using VideoMenuApp.Core.Entity;

namespace VideoMenuApp.Core.DomainService
{
    public interface IVideoRepository
    {
        Video Create(Video video);
        Video FindById(int id);
        IEnumerable<Video> GetAll();
        Video Update(Video video);
        Video Delete(int id);
    }
}
