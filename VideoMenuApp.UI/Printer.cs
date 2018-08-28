using System;
using System.Collections.Generic;
using System.Text;
using VideoMenuApp.Core.DomainService;
using VideoMenuApp.Core.Entity;
using VideoMenuApp.Infrastructure.Data.Repositories;

namespace VideoMenuApp.UI
{
    class Printer
    {
        private IVideoRepository _videoRepository;
        private int sel;

        public Printer()
        {
            _videoRepository = new VideoRepository();
            while (sel != 6)
            {
                DoMenu();
                DoSelection(sel);
            }
        }

        private void DoMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Video Menu!");
            Console.WriteLine();
            Console.WriteLine("Here you can:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1: Create a new Video");
            Console.WriteLine("2: List all Videos");
            Console.WriteLine("3: Update an existing Video");
            Console.WriteLine("4: Delete a Video");
            Console.WriteLine("5: Search for a Video");
            Console.WriteLine("6: Exit the program");
            Console.WriteLine("-----------------------");
            Console.WriteLine("What do you want to do?");
            int.TryParse(Console.ReadLine(), out sel);
            Console.Clear();
        }

        private void DoSelection(int sel)
        {
            switch (sel)
            {
                case 1:
                    CreateVideo();
                    break;
                case 2:
                    ListAllVideos();
                    break;
                case 3:
                    UpdateVideo();
                    break;
                case 4:
                    DeleteVideo();
                    break;
                case 5:
                    SearchVideos();
                    break;
                case 6:
                    Exit();
                    break;

                default:
                    Console.WriteLine("Please make a valid selection!");
                    Console.ReadLine();
                    break;
            }
        }

        private void CreateVideo()
        {
            Console.WriteLine("What is the name of your video?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the genre of your video?");
            var genre = Console.ReadLine();
            _videoService.NewVideo(name, genre);
            Console.WriteLine("The video has been added");
            Console.ReadLine();
        }

        private  void ListVideos(List<Video> videos)
        {
            if (videos.Count == 0)
            {
                Console.WriteLine("There ar no videos!");
            }
            else
            {
                foreach (var video in videos)
                {
                    Console.WriteLine("Id: {0} Name: {1} Genre: {2}", video.Id, video.Name, video.Genre);
                    Console.WriteLine("-----------------------------------------");
                }
            }
            Console.ReadLine();
        }

        private void ListAllVideos()
        {
            ListVideos(_videoService.GetAllVideos());
        }

        private void UpdateVideo()
        {
            Console.WriteLine("Which video do you want to update?");
            var id = Convert.ToInt32(Console.ReadLine());
            if (_videoService.FindById(id) != null)
            {
                Console.WriteLine("New name:");
                var name = Console.ReadLine();
                Console.WriteLine("New genre:");
                var genre = Console.ReadLine();
                Console.WriteLine("The video has been updated");
                _videoService.UpdateVideo(id, name, genre);
            }
            Console.ReadLine();
        }

        private void DeleteVideo()
        {
            Console.WriteLine("Which video do you want to delete?");
            var id = Convert.ToInt32(Console.ReadLine());
            var deleteVideo = _videoService.FindById(id);
            if (deleteVideo != null)
            {
                _videoService.DeleteVideo(deleteVideo);
                Console.WriteLine("The video was removed");
            }
            Console.ReadLine();
        }

        private void SearchVideos()
        {
            var sel = 0;
            while (sel != 1 && sel != 2)
            {
                Console.WriteLine("1: Search by Video name");
                Console.WriteLine("2: Search by Video genre");
                int.TryParse(Console.ReadLine(), out sel);
                if (sel == 1)
                {
                    SearchVideosByName();
                }
                else if (sel == 2)
                {
                    SearchVideosByGenre();
                }
                else
                {
                    Console.WriteLine("Make a valid selection");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private void SearchVideosByName()
        {
            Console.WriteLine("Enter your searchterm:");
            var searchTerm = Console.ReadLine().ToLower();
            var searchList = new _videoService.SearchByName(searchTerm);
            if (searchList.Count == 0)
            {
                Console.WriteLine("There were no matching videos found");
            }
            else
            {
                ListVideos(searchList);
            }
            Console.ReadLine();
        }

        private void SearchVideosByGenre()
        {
            Console.WriteLine("Enter your searchterm:");
            var searchTerm = Console.ReadLine().ToLower();
            var searchList = _videoService.SearchByGenre(searchTerm);

            if (searchList.Count == 0)
            {
                Console.WriteLine("There were no matching videos found");
            }
            else
            {
                ListVideos(searchList);
            }
            Console.ReadLine();
        }

        private void Exit()
        {
            Console.WriteLine("See you next time!");
            Console.ReadLine();
        }
    }
}
