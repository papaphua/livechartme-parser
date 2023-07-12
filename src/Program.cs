using LiveChartMeParser.Models;
using LiveChartMeParser.Models.Parser;

var chartParser = ChartParser.Instance;
var animeParser = AnimeParser.Instance;

chartParser.Parse();

animeParser.ParseBySeason(Seasons.Winter, 1917);