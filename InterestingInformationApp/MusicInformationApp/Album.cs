using Newtonsoft.Json;

namespace InterestingInformationApp.MusicInformationApp
{
    public class Album
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
