using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class FieldBlockRepo
    {
        private Dictionary<int, FieldBlock> fieldBlockDictionary = new Dictionary<int, FieldBlock>();

        private static FieldBlockRepo instance;

        public static FieldBlockRepo Instance {
            get
            {
                if (instance == null)
                    instance = new FieldBlockRepo();
                return instance;
            }
        }

        private FieldBlockRepo()
        {

        }
    }
}
