using LiveChartMeParser.Models.Helpers;

namespace LiveChartMeParser.Models.Parser;

public sealed class AnimeParser
{
    private readonly ChartParser _chartParser;

    public AnimeParser()
    {
        _chartParser = new ChartParser();
    }

    public void Parse(AnimeTypes animeType = AnimeTypes.All)
    {
        var url = UrlProvider.GetTypeRoute(animeType);

        Console.WriteLine(url);
    }

    public void ParseBySeason(Seasons season, int year, AnimeTypes animeType = AnimeTypes.All)
    {
        if (!_chartParser.AvailableSeasons.Any(c => c.Year == year && c.Seasons.Contains(season.ToString())))
        {
            Console.WriteLine("Doesn't exist\n");
        }
        
        var url = UrlProvider.GetSeasonRoute(season, year, animeType);

        Console.WriteLine(url);
    }

    public void ParseTba(AnimeTypes animeType = AnimeTypes.All)
    {
        var url = UrlProvider.GetTbaRoute(animeType);

        Console.WriteLine(url);
    }
}