using HtmlAgilityPack;
using LiveChartMeParser.Models.Dtos;
using LiveChartMeParser.Models.Primitives;

namespace LiveChartMeParser.Models.Parser;

public sealed class ChartParser : Singleton<ChartParser>
{
    private const string ChartUrl = "https://www.livechart.me/charts";

    public readonly List<ChartDto> AvailableSeasons = new();

    private ChartParser()
    {
    }

    public void Parse()
    {
        var web = new HtmlWeb();
        var html = web.Load(ChartUrl);

        var chartNodes = html.DocumentNode.SelectNodes("//li[@class='grouped-list-item chart-item grid-x']");

        // i = 0 is TBA, so can`t be parsed to int
        for (var i = 1; i < chartNodes.Count; i++)
        {
            var yearNode = chartNodes[i].SelectSingleNode(".//div/h5");
            var seasonNodes = chartNodes[i].SelectNodes(".//div//a");

            var year = int.Parse(yearNode.InnerText);
            var seasons = seasonNodes.Select(n => n.InnerText).ToHashSet();

            AvailableSeasons.Add(new ChartDto
            {
                Year = year,
                Seasons = seasons
            });
        }
    }
}