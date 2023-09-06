
using Newtonsoft.Json;

namespace Discovery.Weather.DataTransferObjects {

    public class WeatherForecastData
    {
        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("list")]
        public List<WeatherList> List { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("root")]
        public Root Root { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
    

}


