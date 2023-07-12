using HtmlAgilityPack;

namespace LiveChartMeParser._oldModels;

public sealed class Parser
{
    //
        // //     var web = new HtmlWeb();
        // // var html = web.Load(Url);
        // //
        // // var animeList = new List<Anime>();
        //
        // var animeNodes = html.DocumentNode.SelectNodes("//div[@class='anime-card']");
        //
        // foreach (var animeNode in animeNodes)
        // {
        //     // var titleNode = animeNode.SelectSingleNode(".//h3[@class='main-title']//a");
        //     // var tagNodes = animeNode.SelectNodes(".//ol[@class='anime-tags']//li//a");
        //     // var nextEpisodeNode = animeNode.SelectSingleNode(".//time[@class='episode-countdown']");
        //     // var ratingNode = animeNode.SelectSingleNode(".//div[@class='anime-avg-user-rating']");
        //     // var studioNodes = animeNode.SelectNodes(".//ul[@class='anime-studios']//li//a");
        //     // var sourceNode = animeNode.SelectSingleNode(".//div[@class='anime-source']");
        //     // var totalEpisodesNode = animeNode.SelectSingleNode(".//div[@class='anime-episodes']");
        //     // var synopsisNodes = animeNode.SelectNodes(".//div[@class='anime-synopsis']//p[not(@class)]");
        //     //
        //     // var title = HtmlEntity.DeEntitize(titleNode.InnerHtml);
        //     // var tags = tagNodes.Select(n => HtmlEntity.DeEntitize(n.InnerHtml)).ToHashSet();
        //     // var nextEpisode = nextEpisodeNode?.GetAttributeValue("data-label", string.Empty) ?? "Finished";
        //     // var nextEpisodeDate = nextEpisodeNode?.InnerHtml.Replace($"{nextEpisode}: ", string.Empty);
        //     // var ratingTemp = ratingNode?.InnerHtml ?? "-1";
        //     // var rating = float.Parse(
        //     //     Regex.Replace(ratingTemp, "<i[^>]*>.*?</i>", string.Empty).Trim());
        //     // var studios = studioNodes?.Select(n => HtmlEntity.DeEntitize(n.InnerHtml)).ToHashSet() ??
        //     //               new HashSet<string> { "Unknown" };
        //     // var source = HtmlEntity.DeEntitize(sourceNode.InnerHtml);
        //     // var totalEpisodes = HtmlEntity.DeEntitize(totalEpisodesNode.InnerHtml);
        //     // var synopsis = synopsisNodes?.Select(n => HtmlEntity.DeEntitize(n.InnerHtml)).ToHashSet() ??
        //     //                new HashSet<string> { "Unknown" };
        // }
        //
}