using System;

namespace VideoMenuApp
{
    class Program
    {
        static int sel = 0;

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
                Console.WriteLine("You search Videos by name");
                Console.ReadLine();
            }

            void SearchVideosByGenre()
            {
                Console.WriteLine("You search Videos by genre");
                Console.ReadLine();
            }
        }

        private static void DeleteVideo()
        {
            Console.WriteLine("You delete a video");
            Console.ReadLine();
        }

        private static void UpdateVideo()
        {
            Console.WriteLine("You update a video");
            Console.ReadLine();
        }

        private static void ListAllVideos()
        {
            Console.WriteLine("You list all videos");
            Console.ReadLine();
        }

        private static void CreateVideo()
        {
            Console.WriteLine("You create a new video");
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
