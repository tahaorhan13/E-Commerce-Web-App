using Beu.Eticaret.Dal.Product;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Tesbih;
using System;

namespace Beu.Eticaret.Bll.Product
{
    public class bTesbih
    {
        public rTesbih Add(pTesbih args)
        {
            using (DbEntities db = new DbEntities())
            {
                dTesbih product = new dTesbih(db);
                try
                {
                    return product.Add(args);
                }
                catch (Exception)
                {
                    return new rTesbih { Message = "hata", Error = true };
                }
            }
        }
        public rListTesbih List(pListTesbih args)
        {
            using (DbEntities db = new DbEntities())
            {
                dTesbih product = new dTesbih(db);
                try
                {
                    return product.List(args);
                }
                catch (Exception)
                {
                    return new rListTesbih { Message = "hata", Error = true };
                }
            }
        }
    }
}
