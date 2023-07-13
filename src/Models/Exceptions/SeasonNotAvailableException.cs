namespace LiveChartMeParser.Models.Exceptions;

public sealed class SeasonNotAvailableException : CustomException
{
    public SeasonNotAvailableException(string message)
        : base(message)
    {
    }

    public static string Details(Seasons season, int year)
    {
        return $"{year} {season.ToString()} is not found";
    }
}