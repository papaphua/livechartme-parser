namespace LiveChartMeParser.Models.Helpers;

public static class DateProvider
{
    public static Seasons GetCurrentSeason()
    {
        var dateTime = DateTime.Now;
        var currentMonth = dateTime.Month;

        return currentMonth switch
        {
            < 3 or 12 => Seasons.Winter,
            < 6 => Seasons.Spring,
            < 9 => Seasons.Summer,
            _ => Seasons.Fall
        };
    }
    
    public static int GetCurrentYear()
    {
        var dateTime = DateTime.Now;

        return dateTime.Year;
    }
}