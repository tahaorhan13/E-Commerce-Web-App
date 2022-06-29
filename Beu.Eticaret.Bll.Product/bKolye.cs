using Beu.Eticaret.Dal.Product;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Kolye;
using System;

namespace Beu.Eticaret.Bll.Product
{
    public class bKolye
    {
        public rKolye Add(pKolye args)
        {
            using (DbEntities db = new DbEntities())
            {
                dKolye product = new dKolye(db);
                try
                {
                    return product.Add(args);
                }
                catch (Exception)
                {
                    return new rKolye { Message = "hata", Error = true };
                }
            }
        }
        public rListKolye List(pListKolye args)
        {
            using (DbEntities db = new DbEntities())
            {
                dKolye product = new dKolye(db);
                try
                {
                    return product.List(args);
                }
                catch (Exception)
                {
                    return new rListKolye { Message = "hata", Error = true };
                }
            }
        }
    }
}
