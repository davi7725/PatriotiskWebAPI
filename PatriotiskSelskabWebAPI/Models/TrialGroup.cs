using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class TrialGroup
    {
        public int TrialGroupID { get; set; }
        public Crop TrialGroupCrop { get; set; }
        public int TrialGroupNr { get; set; }
        public string Comment { get; set; }
        public List<Treatment> Treatments { get; set; }

        public TrialGroup(int trialGroupID, Crop trialGroupCrop, int trialGroupNr, string comment, List<Treatment> treatments)
        {
            TrialGroupID = trialGroupID;
            TrialGroupCrop = trialGroupCrop;
            TrialGroupNr = trialGroupNr;
            Comment = comment;
            Treatments = treatments;
        }

    }
}
