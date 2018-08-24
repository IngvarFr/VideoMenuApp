using System;
using System.Collections.Generic;

namespace VideoMenuApp
{
    class Program
    {
        static int sel = 0;
        static int id = 1;
        private static List<Video> Videos = new List<Video>();

        static void Main(string[] args)
        {
            while(sel != 6)
            {
                DoMenu();
                DoSelection(sel);
            }

        }

        private static void DoSelection(int sel)
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

        private static void Exit()
        {
            Console.WriteLine("See you next time!");
            Console.ReadLine();
        }

        private static void SearchVideos()
        {
            var sel = 0;
            while (sel != 1 && sel !=2)
            {
                Console.WriteLine("1: Search by Video name");
                Console.WriteLine("2: Search by Video genre");
                int.TryParse(Console.ReadLine(), out sel);
                if(sel == 1)
                {
                    SearchVideosByName();
                }
                else if(sel == 2)
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

            void SearchVideosByName()
            {
                Console.WriteLine("Enter your searchterm:");
                var searchTerm = Console.ReadLine().ToLower();
                var searchList = new List<Video>();
                foreach (var video in Videos)
                {
                    if(video.Name.ToLower().Contains(searchTerm))
                    {
                        searchList.Add(video);
                    }
                }
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

            void SearchVideosByGenre()
            {
                Console.WriteLine("Enter your searchterm:");
                var searchTerm = Console.ReadLine().ToLower();
                var searchList = new List<Video>();
                foreach (var video in Videos)
                {
                    if (video.Genre.ToLower().Contains(searchTerm))
                    {
                        searchList.Add(video);
                    }
                }
                if (searchList.Count == 0)
                {
                    Console.WriteLine("There were no matching videos found");
                }
                else
                {
                    Console.WriteLine("These videos were found");
                    Console.WriteLine();
                    ListVideos(searchList);
                }
                Console.ReadLine();
            }
        }

        private static void DeleteVideo()
        {
            Console.WriteLine("Which video do you want to delete?");
            var foundVideo = FindVideoById();
            if(foundVideo != null)
            {
                Videos.Remove(foundVideo);
                Console.WriteLine("The video was removed");
            }
            Console.ReadLine();
        }

        private static void UpdateVideo()
        {
            Console.WriteLine("Which video do you want to update?");
            var foundVideo = FindVideoById();

            if(foundVideo != null)
            {
                Console.WriteLine("New name:");
                foundVideo.Name = Console.ReadLine();
                Console.WriteLine("New genre:");
                foundVideo.Genre = Console.ReadLine();
                Console.WriteLine("The video has been updated");
            }
            Console.ReadLine();
        }

        private static Video FindVideoById()
        {
            Console.WriteLine("Enter the video id");
            int id;
            Video foundVideo = null;
            int.TryParse(Console.ReadLine(), out id);
            foreach (var video in Videos)
            {
                if (video.Id.Equals(id))
                {
                    foundVideo = video;
                }
            }
            if (foundVideo == null)
            {
                Console.WriteLine("There is no video with that id");
                return null;
            }
            else
            {
                return foundVideo;
            }
        }

        private static void ListAllVideos()
        {
            ListVideos(Videos);
        }

        private static void ListVideos(List<Video> videos)
        {
            if (videos.Count == 0)
            {
                Console.WriteLine("There ar no videos!");
            }
            else
            {
                foreach (var video in videos)
                {
                    Console.WriteLine("Id: {0}, Name: {1}, Genre: {2}", video.Id, video.Name, video.Genre);
                    Console.WriteLine("-----------------------------------------");
                }
            }
            Console.ReadLine();
        }

        private static void CreateVideo()
        {
            Console.WriteLine("What is the name of your video?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the genre of your video?");
            var genre = Console.ReadLine();
            var video = new Video() {Id = id++, Name = name, Genre = genre};
            Videos.Add(video);
            Console.WriteLine("The video has been added");
            Console.ReadLine();
        }

        private static void DoMenu()
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
    }
}
