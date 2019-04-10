using System;

namespace Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Diary instance
            Diary diary = new Diary();
            char choice = '0';
            //main loop
            while (choice != '4')
            {
                diary.PrintHomeScreen();
                Console.WriteLine();
                Console.WriteLine("Choose an action");
                Console.WriteLine("1 - Add an entry");
                Console.WriteLine("2 - Search for entries");
                Console.WriteLine("3 - Delete entries");
                Console.WriteLine("4 - Exit");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                //
                switch (choice)
                {
                    case '1':
                        diary.AddEntry();
                        break;
                    case '2':
                        diary.SearchEntry();
                        break;
                    case '3':
                        diary.DeleteEntries();
                        break;
                    case '4':
                        Console.WriteLine("Press any key to end the program...");
                        break;
                    default:
                        Console.WriteLine("Error! Press an appropriate key to proceed.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
