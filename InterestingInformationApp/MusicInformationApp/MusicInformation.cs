using Newtonsoft.Json;
using System.Collections.Generic;

namespace InterestingInformationApp.MusicInformationApp
{
    public class MusicInformation
    {
        [JsonProperty("data")]
        public IList<Datum> Data { get; set; }
    }
}
