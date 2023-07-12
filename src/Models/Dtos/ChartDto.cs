namespace LiveChartMeParser.Models.Dtos;

public sealed class ChartDto
{
    public int Year { get; init; }
    public HashSet<string> Seasons { get; init; } = new();
}