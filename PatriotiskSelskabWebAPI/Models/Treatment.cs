using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class Treatment
    {
        public int TreatmentID { get; set; }
        public TreatmentType TreatmentTreatmentType { get; set; }
        public DateTime? TreatmentDate { get; set; }
        public string TreatmentStage { get; set; }
        public string Comment { get; set; }
        public List<TreatmentProduct> Products { get; set; }

        public Treatment(int treatmentID, TreatmentType treatmentTreatmentType, DateTime? treatmentDate, string treatmentStage, string comment, List<TreatmentProduct> products)
        {
            TreatmentID = treatmentID;
            TreatmentTreatmentType = treatmentTreatmentType;
            TreatmentDate = treatmentDate;
            TreatmentStage = treatmentStage;
            Comment = comment;
            Products = products;
        }

    }
}
