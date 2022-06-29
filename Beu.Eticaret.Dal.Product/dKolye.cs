using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Kolye;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Product
{
    public class dKolye : dCore
    {
        public dKolye(DbEntities db) : base(db)
        {
            //
        }
        public rKolye Add(pKolye args)
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
            var r = Get(new pKolye() { Id = ent.Id });
            return r;
        }
        public rListKolye List(pListKolye args)
        {
            var ent = GenerateQuery();
            try
            {
                ent = ent.Where(x => x.Id >= args.Id);
                return new rListKolye() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }
        private IQueryable<eKolye> GenerateQuery()
        {
            return (from product in db.pr_Kolye
                    select new eKolye()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductImage = product.ProductImage
                    });
        }
        public rKolye Get(pKolye args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rKolye() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }


    }
}
