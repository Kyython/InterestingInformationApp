using Newtonsoft.Json;

namespace InterestingInformationApp.MusicInformationApp
{
    public class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
