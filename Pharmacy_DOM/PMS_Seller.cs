using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Pharmacy_DOM
{
    public class PMS_Seller
    {
        public static bool UpdateStock(string MedCode, int FinalQty)
        {

            using (var ctx = new PharmacyEntities())
            {
                var med = ctx.Med_details.Where(a => a.MedCode == MedCode).SingleOrDefault();
                med.MedStock = FinalQty;
                ctx.Entry(med).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }
        public static int SaveBill(Billing_details bed)
        {
            using (var ctx = new PharmacyEntities())
            {
                ctx.Billing_details.Add(bed);
                ctx.SaveChanges();
                return bed.BillId;
            }
        }  
    }
}
