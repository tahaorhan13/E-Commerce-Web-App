using Beu.Eticaret.Dal.Product;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Yuzuk;
using System;

namespace Beu.Eticaret.Bll.Product
{
    public class bYuzuk
    {
        public rYuzuk Add(pYuzuk args)
        {
            using (DbEntities db = new DbEntities())
            {
                dYuzuk product = new dYuzuk(db);
                try
                {
                    return product.Add(args);
                }
                catch (Exception)
                {
                    return new rYuzuk { Message = "hata", Error = true };
                }
            }
        }
        public rListYuzuk List(pListYuzuk args)
        {
            using (DbEntities db = new DbEntities())
            {
                dYuzuk product = new dYuzuk(db);
                try
                {
                    return product.List(args);
                }
                catch (Exception)
                {
                    return new rListYuzuk { Message = "hata", Error = true };
                }
            }
        }
    }
}
