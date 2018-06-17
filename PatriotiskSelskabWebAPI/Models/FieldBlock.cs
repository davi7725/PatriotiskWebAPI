using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class FieldBlock
    {
        public int FieldBlockID { get; set; }
        public string BlockChar { get; set; }
        public int FieldBlockYear { get; set; }
        public int FieldBlockLength { get; set; }
        public int FieldBlockWidth { get; set; }
        public string Comment { get; set; }
        public List<SubBlock> SubBlocks { get; set; }

        public FieldBlock(int fieldBlockID, string blockChar, int fieldBlockYear, int fieldBlockLength, int fieldBlockWidth, string comment, List<SubBlock> subBlocks)
        {
            FieldBlockID = fieldBlockID;
            BlockChar = blockChar;
            FieldBlockYear = fieldBlockYear;
            FieldBlockLength = fieldBlockLength;
            FieldBlockWidth = fieldBlockWidth;
            Comment = comment;
            SubBlocks = subBlocks;
        }

    }
}
