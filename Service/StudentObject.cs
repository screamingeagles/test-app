using Newtonsoft.Json;

namespace test_app.Service
{
    public class StudentObject
    {        
        public int? ID { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateTime dateOfBirth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? nationalityId { get; set; }
    }
}
