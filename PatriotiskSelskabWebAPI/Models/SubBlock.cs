using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class SubBlock
    {
        public int SubBlockID { get; set; }
        public string SubBlockChar { get; set; }
        public int AmountOfTrialGroups { get; set; }
        public int LastNrOfTrialGroup { get; set; }
        public int SubBlockLength { get; set; }
        public int SubBlockWidth { get; set; }
        public int PosL { get; set; }
        public int PosW { get; set; }
        public string Comment { get; set; }
        public TrialType SubBlockTrialType { get; set; }
        public List<TrialGroup> TrialGroups { get; set; }

        public SubBlock(int subBlockID, string subBlockChar, int amountOfTrialGroups, int lastNrOfTrialGroup, int subBlockLength, int subBlockWidth, int posL, int posW, string comment, TrialType subBlockTrialType, List<TrialGroup> trialGroups)
        {
            SubBlockID = subBlockID;
            SubBlockChar = subBlockChar;
            AmountOfTrialGroups = amountOfTrialGroups;
            LastNrOfTrialGroup = lastNrOfTrialGroup;
            SubBlockLength = subBlockLength;
            SubBlockWidth = subBlockWidth;
            PosL = posL;
            PosW = posW;
            Comment = comment;
            SubBlockTrialType = subBlockTrialType;
            TrialGroups = trialGroups;
        }

    }
}
