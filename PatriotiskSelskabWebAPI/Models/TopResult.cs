using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class TopResult
    {
        public string Type { get; set; }
        public int TopTrial { get; set; }

        public TopResult(string type, int topTrial)
        {
            Type = type;
            TopTrial = topTrial;
        }

    }
}
