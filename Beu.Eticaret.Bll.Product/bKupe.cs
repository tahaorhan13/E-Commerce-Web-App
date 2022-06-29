using Beu.Eticaret.Dal.Product;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Kupe;
using System;

namespace Beu.Eticaret.Bll.Product
{
    public class bKupe
    {
        public rKupe Add(pKupe args)
        {
            using (DbEntities db = new DbEntities())
            {
                dKupe product = new dKupe(db);
                try
                {
                    return product.Add(args);
                }
                catch (Exception)
                {
                    return new rKupe { Message = "hata", Error = true };
                }
            }
        }
        public rListKupe List(pListKupe args)
        {
            using (DbEntities db = new DbEntities())
            {
                dKupe product = new dKupe(db);
                try
                {
                    return product.List(args);
                }
                catch (Exception)
                {
                    return new rListKupe { Message = "hata", Error = true };
                }
            }
        }
    }
}
