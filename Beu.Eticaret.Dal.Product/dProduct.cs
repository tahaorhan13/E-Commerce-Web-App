using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product;
using Beu.Eticaret.Entity.Product.Tesbih;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Product
{
    public class dProduct : dCore
    {
        public dProduct(DbEntities db) : base(db)
        {
            //
        }
        public rProduct Add(pProduct args)
        {
            //if (Has(args))
            //    throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");

            var ent = new pr_Product();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pProduct() { Id = ent.Id });
            return r;
        }
        public rListProduct List(pListProduct args)
        {
            var ent = MainProduct();
            try
            {
                ent = ent.Where(x => x.Id >= args.Id);
                return new rListProduct() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }
        public rListTesbih ListTesbih(pListProduct args)
        {
            var ent = Tesbih();
            try
            {
                ent = ent.Where(x => x.Id >= args.Id);
                return new rListTesbih() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public rProduct Get(pProduct args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = MainProduct();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rProduct() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }
        private IQueryable<eProduct> MainProduct()
        {
            return (from product in db.pr_Product
                    select new eProduct()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductImage = product.ProductImage
                    });
        }

        private IQueryable<eTesbih> Tesbih()
        {
            return (from product in db.pr_Tesbih
                    select new eTesbih()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductImage = product.ProductImage
                    });
        }


    }
}
