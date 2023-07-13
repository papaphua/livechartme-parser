using LiveChartMeParser.Models;
using LiveChartMeParser.Models.Dtos;
using LiveChartMeParser.Models.Exceptions;
using LiveChartMeParser.Models.Parser;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            try
            {
                StartParser();
            }
            catch (CustomException e)
            {
                PrintException(e.Message);
            }
        }
    }

    private static void StartParser()
    {
        Console.WriteLine("\nTo parse anime enter the number of one of the desired option" +
                          "\n\t1) Current season;" +
                          "\n\t2) Select season and year;" +
                          "\n\t3) Select TBA;");

        var animeParser = AnimeParser.Instance;
        
        AnimeTypes type;
        Seasons season;
        int year;
        
        int option = 1;
        var isValidInput = false;
        
        while (!isValidInput)
        {
            Console.Write("\nOption: ");
            var input = Console.ReadLine();
            int.TryParse(input, out option);

            if (option is not (1 or 2 or 3))
            {
                Console.WriteLine("\nSelect valid number of option.");
            }
            else
            {
                isValidInput = true;
            }
        }

        type = SelectAnimeType();
        
        switch (option)
        {
            case 1:
                PrintAnimeList(animeParser.Parse(type));
                break;
            case 2:
                season = SelectAnimeSeason();
                year = SelectAnimeYear();
                PrintAnimeList(animeParser.ParseBySeason(season, year, type));
                break;
            case 3:
                PrintAnimeList(animeParser.ParseTba(type));
                break;
        }
    }

    private static AnimeTypes SelectAnimeType()
    {
        Console.WriteLine("\nSelect anime type" +
                          "\n\t1) Television;" +
                          "\n\t2) Movies;" +
                          "\n\t3) OVAs;" +
                          "\n\t4) All;");
        
        int option = 1;
        var isValidInput = false;
        
        while (!isValidInput)
        {
            Console.Write("\nType: ");
            var input = Console.ReadLine();
            int.TryParse(input, out option);

            if (option is not (1 or 2 or 3 or 4))
            {
                Console.WriteLine("\nSelect valid number of type.");
            }
            else
            {
                isValidInput = true;
            }
        }

        return (AnimeTypes)option;
    }

    private static Seasons SelectAnimeSeason()
    {
        Console.WriteLine("\nSelect anime type" +
                          "\n\t1) Winter;" +
                          "\n\t2) Spring;" +
                          "\n\t3) Summer;" +
                          "\n\t4) Fall;");
        
        int option = 1;
        var isValidInput = false;
        
        while (!isValidInput)
        {
            Console.Write("\nSeason: ");
            var input = Console.ReadLine();
            int.TryParse(input, out option);

            if (option is not (1 or 2 or 3 or 4))
            {
                Console.WriteLine("\nSelect valid number of season.");
            }
            else
            {
                isValidInput = true;
            }
        }

        return (Seasons)option;
    }
    
    private static int SelectAnimeYear()
    {
        int year = 1;
        var isValidInput = false;
        
        while (!isValidInput)
        {
            Console.Write("\nEnter year: ");
            var input = Console.ReadLine();
            var isNum = int.TryParse(input, out year);

            if (!isNum)
            {
                Console.WriteLine("\nEnter valid number.");
            }
            else
            {
                isValidInput = true;
            }
        }

        return year;
    }

    private static void PrintException(string message)
    {
        Console.WriteLine($"\nError: {message}");
    }

    private static void PrintAnimeList(List<AnimeDto> animeList)
    {
        foreach (var anime in animeList)
        {
            Console.WriteLine(anime.ToString());
        }
    }
}