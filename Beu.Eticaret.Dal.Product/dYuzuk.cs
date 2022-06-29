using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Yuzuk;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Product
{
    public class dYuzuk : dCore
    {
        public dYuzuk(DbEntities db) : base(db)
        {
            //
        }
        public rYuzuk Add(pYuzuk args)
        {
            //if (Has(args))
            //    throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");

            var ent = new pr_Yuzuk();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pYuzuk() { Id = ent.Id });
            return r;
        }
        public rListYuzuk List(pListYuzuk args)
        {
            var ent = GenerateQuery();
            try
            {
                ent = ent.Where(x => x.Id >= args.Id);
                return new rListYuzuk() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }
        private IQueryable<eYuzuk> GenerateQuery()
        {
            return (from product in db.pr_Yuzuk
                    select new eYuzuk()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductImage = product.ProductImage
                    });
        }
        public rYuzuk Get(pYuzuk args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rYuzuk() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }


    }
}
