namespace LiveChartMeParser.Models.Dtos;

public sealed class AnimeDto
{
    public string Title { get; set; }
    public HashSet<string> Tags { get; set; }
    public string NextEpisode { get; set; }
    public string NextEpisodeDate { get; set; }
    public float? Rating { get; set; }
    public HashSet<string> Studios { get; set; }
    public string Source { get; set; }
    public string TotalEpisodes { get; set; }
    public List<string> Synopsis { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}\n" +
               $"Tags: {string.Join(',', Tags)}\n" +
               $"Studios: {string.Join(',', Studios)}\n" +
               $"Rating: {Rating}\n" +
               $"Source: {Source}\n" +
               $"Total episodes: {TotalEpisodes}\n" +
               $"Next episode: {NextEpisode} available at {NextEpisodeDate}\n" +
               $"Description: {string.Join('\n', Synopsis)}\n";
    }
}