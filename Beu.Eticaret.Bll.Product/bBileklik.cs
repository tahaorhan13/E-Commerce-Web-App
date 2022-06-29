using Beu.Eticaret.Dal.Product;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Bileklik;
using System;

namespace Beu.Eticaret.Bll.Product
{
    public class bBileklik
    {
        public rBileklik Add(pBileklik args)
        {
            using (DbEntities db = new DbEntities())
            {
                dBileklik product = new dBileklik(db);
                try
                {
                    return product.Add(args);
                }
                catch (Exception)
                {
                    return new rBileklik { Message = "hata", Error = true };
                }
            }
        }
        public rListBileklik List(pListBileklik args)
        {
            using (DbEntities db = new DbEntities())
            {
                dBileklik product = new dBileklik(db);
                try
                {
                    return product.List(args);
                }
                catch (Exception)
                {
                    return new rListBileklik { Message = "hata", Error = true };
                }
            }
        }
    }
}
