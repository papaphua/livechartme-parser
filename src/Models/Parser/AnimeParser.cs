using HtmlAgilityPack;
using LiveChartMeParser.Models.Dtos;
using LiveChartMeParser.Models.Exceptions;
using LiveChartMeParser.Models.Helpers;
using LiveChartMeParser.Models.Primitives;

namespace LiveChartMeParser.Models.Parser;

public sealed class AnimeParser : Singleton<AnimeParser>
{
    private const string Finished = "Finished";
    private const string Unknown = "Unknown";

    private readonly ChartParser _chartParser;

    private AnimeParser()
    {
        _chartParser = ChartParser.Instance;
        _chartParser.Parse();
    }

    public IEnumerable<AnimeDto> Parse(AnimeTypes animeType = AnimeTypes.All)
    {
        var url = UrlProvider.GetTypeRoute(animeType);

        return Parse(url);
    }

    public IEnumerable<AnimeDto> ParseBySeason(Seasons season, int year, AnimeTypes animeType = AnimeTypes.All)
    {
        if (!_chartParser.IsAvailable(season, year)) throw new SeasonNotAvailableException(
            SeasonNotAvailableException.Details(season, year));

        var url = UrlProvider.GetSeasonRoute(season, year, animeType);

        return Parse(url);
    }

    public IEnumerable<AnimeDto> ParseTba(AnimeTypes animeType = AnimeTypes.All)
    {
        var url = UrlProvider.GetTbaRoute(animeType);

        return Parse(url);
    }

    private IEnumerable<AnimeDto> Parse(string url)
    {
        var web = new HtmlWeb();
        var html = web.Load(url);
        var animeList = new List<AnimeDto>();
        var animeNodes = html.DocumentNode.SelectNodes("//div[@class='anime-card']");

        foreach (var node in animeNodes)
        {
            var titleNode = node.SelectSingleNode(".//h3[@class='main-title']//a");
            var title = HtmlEntity.DeEntitize(titleNode.InnerText);

            var tagNodes = node.SelectNodes(".//ol[@class='anime-tags']//li//a");
            var tags = tagNodes.Select(n => HtmlEntity.DeEntitize(n.InnerText)).ToHashSet();

            var nextEpisodeNode = node.SelectSingleNode(".//time[@class='episode-countdown']");
            var nextEpisode = nextEpisodeNode?.GetAttributeValue("data-label", string.Empty) ?? Finished;
            var nextEpisodeDate = nextEpisodeNode?.InnerText.Replace($"{nextEpisode}: ", string.Empty) ?? Finished;

            var ratingNode = node.SelectSingleNode(".//div[@class='anime-avg-user-rating']");
            float? rating = float.TryParse(ratingNode?.InnerText, out var ratingValue) ? ratingValue : null;

            var studioNodes = node.SelectNodes(".//ul[@class='anime-studios']//li//a");
            var studios = studioNodes?.Select(n => HtmlEntity.DeEntitize(n.InnerText)).ToHashSet() ??
                          new HashSet<string> { Unknown };

            var sourceNode = node.SelectSingleNode(".//div[@class='anime-source']");
            var source = HtmlEntity.DeEntitize(sourceNode.InnerText);

            var totalEpisodesNode = node.SelectSingleNode(".//div[@class='anime-episodes']");
            var totalEpisodes = HtmlEntity.DeEntitize(totalEpisodesNode.InnerText);

            var synopsisNodes = node.SelectNodes(".//div[@class='anime-synopsis']//p[not(@class)]");
            var synopsis = synopsisNodes?.Select(n => HtmlEntity.DeEntitize(n.InnerText)).ToList() ??
                           new List<string> { Unknown };

            animeList.Add(new AnimeDto
            {
                Title = title,
                Tags = tags,
                NextEpisode = nextEpisode,
                NextEpisodeDate = nextEpisodeDate,
                Rating = rating,
                Studios = studios,
                Source = source,
                TotalEpisodes = totalEpisodes,
                Synopsis = synopsis
            });
        }

        return new List<AnimeDto>();
    }
}