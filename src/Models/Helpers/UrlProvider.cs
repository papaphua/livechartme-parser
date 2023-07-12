namespace LiveChartMeParser.Models.Helpers;

public static class UrlProvider
{
    private const string DefaultUrl = "https://www.livechart.me";

    public static string GetTypeRoute(AnimeTypes animeType)
    {
        var season = DateProvider.GetCurrentSeason();

        var animeTypeString = animeType.ToString().ToLower();
        var seasonString = season.ToString().ToLower();
        var year = DateProvider.GetCurrentYear();

        return $"{DefaultUrl}/{seasonString}-{year}/{animeTypeString}";
    }
    
    public static string GetSeasonRoute(Seasons season, int year, AnimeTypes animeType)
    {
        var seasonString = season.ToString().ToLower();
        var animeTypeString = animeType.ToString().ToLower();
        
        return $"{DefaultUrl}/{seasonString}-{year}/{animeTypeString}";
    }
    
    public static string GetTbaRoute(AnimeTypes animeType)
    {
        var animeTypeString = animeType.ToString().ToLower();
        
        return $"{DefaultUrl}/tba/{animeTypeString}";
    }
}