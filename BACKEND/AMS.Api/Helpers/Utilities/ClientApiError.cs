using AMS.Api.Helpers.AttributeCores;
using Newtonsoft.Json;

namespace AMS.Api.Helpers.Utilities
{
    public class ClientApiError
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("innerMessage")]
        public string InnerMessage { get; set; }

        [JsonProperty("errors")]
        public List<ErrorItem> Errors { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("errorTime")]
        public DateTime? ErrorTime { get; set; }

        [SwashbuckleIgnore()]
        [JsonProperty("stackTrace", NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { get; set; }
    }

    public class ErrorItem
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}