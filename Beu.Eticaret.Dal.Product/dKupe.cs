using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Kupe;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Product
{
    public class dKupe : dCore
    {
        public dKupe(DbEntities db) : base(db)
        {
            //
        }
        public rKupe Add(pKupe args)
        {
            //if (Has(args))
            //    throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");

            var ent = new pr_Kolye();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pKupe() { Id = ent.Id });
            return r;
        }
        public rListKupe List(pListKupe args)
        {
            var ent = GenerateQuery();
            try
            {
                ent = ent.Where(x => x.Id >= args.Id);
                return new rListKupe() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }
        private IQueryable<eKupe> GenerateQuery()
        {
            return (from product in db.pr_Kupe
                    select new eKupe()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductImage = product.ProductImage
                    });
        }
        public rKupe Get(pKupe args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rKupe() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }


    }
}
