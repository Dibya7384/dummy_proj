using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Pharmacy_DOM
{
    public class PMS_CLS_Admin
    {
        //medicine class controller
        public static string AddMedicine(Med_details med)
        {
            using (var ctx = new PharmacyEntities())
            {
                ctx.Med_details.Add(med);
                ctx.SaveChanges();
                return med.MedCode;
            }
        }
        public static List<Med_details> ViewMedicine()
        {
            using (var ctx = new PharmacyEntities())
            {
                var med = ctx.Med_details.Include(e => e.Category_details).ToList();
                return med;
            }
        }

        public static bool UpdateMedicine(string MedCode, string MedName, int MedPrice, int MedStock, DateTime MedExpDate, int MedCategory)
        {

            using (var ctx = new PharmacyEntities())
            {
                var med = ctx.Med_details.Where(a => a.MedCode == MedCode).SingleOrDefault();
                med.MedName = MedName;
                med.MedPrice = MedPrice;
                med.MedStock = MedStock;
                med.MedExpDate = MedExpDate;
                med.MedCategory = MedCategory;
                ctx.Entry(med).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool DeleteMedicine(string MedCode)
        {

            using (var ctx = new PharmacyEntities())
            {
                var med = ctx.Med_details.Where(a => a.MedCode.Equals(MedCode)).SingleOrDefault();
                ctx.Med_details.Remove(med);
                ctx.SaveChanges();
                return true;
            }

        }

        public static Med_details FetchMedicine(string MedCode)
        {
            using (var ctx = new PharmacyEntities())
            {
                var med = ctx.Med_details.Include(e => e.Category_details).Where(a => a.MedCode == MedCode).SingleOrDefault();
                return med;
            }
        }

        //Category class controller
        public static int AddCategory(Category_details cat)
        {
            using (var ctx = new PharmacyEntities())
            {
                ctx.Category_details.Add(cat);
                ctx.SaveChanges();
                return cat.CatId;
            }
        }
        public static List<Category_details> ViewCategory()
        {
            using (var ctx = new PharmacyEntities())
            {
                var cat = ctx.Category_details.ToList();
                return cat;
            }
        }

        public static bool UpdateCategory(int CatId, string CatName)
        {

            using (var ctx = new PharmacyEntities())
            {
                var cat = ctx.Category_details.Where(a => a.CatId == CatId).SingleOrDefault();
                cat.CatId = CatId;
                cat.CatName = CatName;
                ctx.Entry(cat).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool DeleteCategory(int CatId)
        {

            using (var ctx = new PharmacyEntities())
            {
                var cat = ctx.Category_details.Where(a => a.CatId.Equals(CatId)).SingleOrDefault();
                ctx.Category_details.Remove(cat);
                ctx.SaveChanges();
                return true;
            }

        }

        public static Category_details FetchCategory(int? CatId)
        {
            using (var ctx = new PharmacyEntities())
            {
                var cat = ctx.Category_details.Where(a => a.CatId == CatId).SingleOrDefault();
                return cat;
            }
        }

        //Seller class controller
        public static int AddSeller(Seller_details sel)
        {
            using (var ctx = new PharmacyEntities())
            {
                ctx.Seller_details.Add(sel);
                ctx.SaveChanges();
                return sel.SelId;
            }
        }
        public static List<Seller_details> ViewSeller()
        {
            using (var ctx = new PharmacyEntities())
            {
                var sel = ctx.Seller_details.ToList();
                return sel;
            }
        }

        public static bool UpdateSeller(int SelId, string SelName, string SelEmail, String SelPwd, DateTime SelDob, string SelGen, string SelAdd)
        {

            using (var ctx = new PharmacyEntities())
            {
                var sel = ctx.Seller_details.Where(a => a.SelId == SelId).SingleOrDefault();
                sel.SelName = SelName;
                sel.SelEmail = SelEmail;
                sel.SelPwd = SelPwd;
                sel.SelDOB = SelDob;
                sel.SelGen = SelGen;
                sel.SelAdd = SelAdd;
                ctx.Entry(sel).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
        }

        public static bool DeleteSeller(int SelId)
        {

            using (var ctx = new PharmacyEntities())
            {
                var sel = ctx.Seller_details.Where(a => a.SelId.Equals(SelId)).SingleOrDefault();
                ctx.Seller_details.Remove(sel);
                ctx.SaveChanges();
                return true;
            }

        }

        public static Seller_details FetchSeller(int id)
        {
            using (var ctx = new PharmacyEntities())
            {
                //var sel = ctx.Seller_details.Where(a => a.SelId==SelId).SingleOrDefault();
                var sel = ctx.Seller_details.Where(a => a.SelId == id).SingleOrDefault();
                return sel;
            }
        }
        public static int Authenticate(string UserName, string Password)
        {
            using (var ctx = new PharmacyEntities())
            {
                var usr = ctx.Seller_details.Where(a => a.SelEmail.Equals(UserName)).SingleOrDefault();
                if (usr != null && usr.SelPwd.Equals(Password))
                {
                    return usr.SelId;
                }
                return 0;
            }
        }

    }
        //medicine configuration
        public class MedicineConfiguration : EntityTypeConfiguration<Med_details>
        {
            public MedicineConfiguration()
            {
                // Primary Key
                this.HasKey(e => e.MedCode);

                // Properties
                this.Property(e => e.MedName)
                    .IsRequired()
                    .HasMaxLength(50);

                this.Property(e => e.MedPrice)
                    .IsRequired();
                    

                this.Property(e => e.MedStock)
                    .IsRequired();

                this.Property(e => e.MedExpDate)
                    .IsRequired();

                this.Property(e => e.MedCategory)
                    .IsRequired();

                // Table & Column Mappings
                this.ToTable("Med_details"); // Name of your table in the database
                this.Property(e => e.MedCode).HasColumnName("MedCode");
                this.Property(e => e.MedName).HasColumnName("MedName");
                this.Property(e => e.MedPrice).HasColumnName("MedPrice");
                this.Property(e => e.MedStock).HasColumnName("MedStock");
                this.Property(e => e.MedExpDate).HasColumnName("MedExpDate");
                this.Property(e => e.MedCategory).HasColumnName("MedCategory");
            }
        }


        //category configuration
        public class CategoryConfiguration : EntityTypeConfiguration<Category_details>
        {
            public CategoryConfiguration()
            {
                // Primary Key
                this.HasKey(e => e.CatId);

                // Properties
                this.Property(e => e.CatName)
                    .IsRequired()
                    .HasMaxLength(50);

                // Table & Column Mappings
                this.ToTable("Category_details"); // Name of your table in the database
                this.Property(e => e.CatId).HasColumnName("CatId");
                this.Property(e => e.CatName).HasColumnName("CatName");
               
            }
        }

        //seller configuration
        public class SellerConfiguration : EntityTypeConfiguration<Seller_details>
        {
            public SellerConfiguration()
            {
                // Primary Key
                this.HasKey(e => e.SelId);

                // Properties
                this.Property(e => e.SelName)
                    .IsRequired()
                    .HasMaxLength(50);

                this.Property(e => e.SelEmail)
                    .IsRequired()
                    .HasMaxLength(50);


                this.Property(e => e.SelPwd)
                    .IsRequired()
                    .HasMaxLength(50);

                this.Property(e => e.SelDOB)
                    .IsRequired();

                this.Property(e => e.SelGen)
                    .IsRequired()
                    .HasMaxLength(50);

                this.Property(e => e.SelAdd)
                    .IsRequired()
                    .HasMaxLength(50);

                // Table & Column Mappings
                this.ToTable("Seller_details"); // Name of your table in the database
                this.Property(e => e.SelId).HasColumnName("SelId");
                this.Property(e => e.SelName).HasColumnName("SelName");
                this.Property(e => e.SelEmail).HasColumnName("SelEmail");
                this.Property(e => e.SelPwd).HasColumnName("SelPwd");
                this.Property(e => e.SelDOB).HasColumnName("SelDOB");
                this.Property(e => e.SelGen).HasColumnName("SelGen");
                this.Property(e => e.SelAdd).HasColumnName("SelAdd");
            }
        }

        //billing configuration
        public class BillingConfiguration : EntityTypeConfiguration<Billing_details>
        {
            public BillingConfiguration()
            {
                // Primary Key
                this.HasKey(e => e.BillId);

                // Properties
                this.Property(e => e.BillDate)
                    .IsRequired();

                this.Property(e => e.Seller)
                    .IsRequired();


                this.Property(e => e.Amount)
                    .IsRequired();

                // Table & Column Mappings
                this.ToTable("Billing_details"); // Name of your table in the database
                this.Property(e => e.BillId).HasColumnName("BillId");
                this.Property(e => e.BillDate).HasColumnName("BillDate");
                this.Property(e => e.Seller).HasColumnName("Seller");
                this.Property(e => e.Amount).HasColumnName("Amount");
            }
        }

    
}
