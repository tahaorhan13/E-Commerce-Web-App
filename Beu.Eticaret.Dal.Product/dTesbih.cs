using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Tesbih;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Product
{
    public class dTesbih : dCore
    {
        public dTesbih(DbEntities db) : base(db)
        {
            //
        }
        public rTesbih Add(pTesbih args)
        {
            //if (Has(args))
            //    throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");

            var ent = new pr_Tesbih();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pTesbih() { Id = ent.Id });
            return r;
        }
        public rListTesbih List(pListTesbih args)
        {
            var ent = GenerateQuery();
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
        private IQueryable<eTesbih> GenerateQuery()
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
        public rTesbih Get(pTesbih args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rTesbih() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }


    }
}
