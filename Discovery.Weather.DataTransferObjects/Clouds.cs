using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discovery.Weather.DataTransferObjects
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
