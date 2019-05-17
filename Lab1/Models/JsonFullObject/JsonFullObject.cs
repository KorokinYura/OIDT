using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models.JsonFullObject
{
    public class JsonFullObject
    {
        public string UdId { get; set; }        // UserId
        public DateTime Date { get; set; }
        [JsonProperty("event_id")]
        public int EventId { get; set; }

        public Parameters Parameters { get; set; }
    }
}
