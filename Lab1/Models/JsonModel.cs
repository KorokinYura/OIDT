using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class JsonModel
    {
        [Key]
        public string UdId { get; set; }

        public DateTime Date { get; set; }

        [JsonProperty("event_id")]
        public int EventId { get; set; }
    }
}
