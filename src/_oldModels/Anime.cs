namespace LiveChartMeParser._oldModels;

public sealed class Anime
{
    public string Title { get; set; }
    public HashSet<string> Tags { get; set; }
    public string NextEpisode { get; set; }
    public string NextEpisodeDate { get; set; }
    public float Rating { get; set; }
    public HashSet<string> Studios { get; set; }
    public string Source { get; set; }
    public string TotalEpisodes { get; set; }
    public List<string> Synopsis { get; set; }
}