using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class TreatmentProduct
    {
        public Product TrtProduct { get; set; }
        public double ProductDose { get; set; }
        public UnitType ProductUnit { get; set; }
        public bool DoseLog { get; set; }
        public List<Result> Results { get; set; }

        public TreatmentProduct(Product trtProduct, double productDose, UnitType productUnit, bool doseLog, List<Result> results)
        {
            TrtProduct = trtProduct;
            ProductDose = productDose;
            ProductUnit = productUnit;
            DoseLog = doseLog;
            Results = results;
        }
    }
}
