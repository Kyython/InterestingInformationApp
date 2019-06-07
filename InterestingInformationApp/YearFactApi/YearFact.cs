using Newtonsoft.Json;

namespace InterestingInformationApp.YearFactApi
{
    public class YearFact
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
