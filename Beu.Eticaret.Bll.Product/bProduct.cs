using Beu.Eticaret.Dal.Product;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product;
using System;

namespace Beu.Eticaret.Bll.Product
{
    public class bProduct
    {
        public rProduct Add(pProduct args)
        {
            using (DbEntities db = new DbEntities())
            {
                dProduct product = new dProduct(db);
                try
                {
                    return product.Add(args);
                }
                catch (Exception)
                {
                    return new rProduct { Message = "hata", Error = true };
                }
            }
        }
        public rListProduct List(pListProduct args)
        {
            using (DbEntities db = new DbEntities())
            {
                dProduct product = new dProduct(db);
                try
                {
                    return product.List(args);
                }
                catch (Exception)
                {
                    return new rListProduct { Message = "hata", Error = true };
                }
            }
        }
    }
}
