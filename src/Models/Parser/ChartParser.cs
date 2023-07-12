using HtmlAgilityPack;
using LiveChartMeParser.Models.Dtos;

namespace LiveChartMeParser.Models.Parser;

public sealed class ChartParser
{
    private const string ChartUrl = "https://www.livechart.me/charts";

    public readonly List<ChartDto> AvailableSeasons = new();

    public ChartParser()
    {
        Parse();
    }
    
    private void Parse()
    {
        var web = new HtmlWeb();
        var html = web.Load(ChartUrl);

        var chartNodes = html.DocumentNode.SelectNodes("//li[@class='grouped-list-item chart-item grid-x']");

        // i = 1 skips TBA
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