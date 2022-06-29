using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Product;
using Beu.Eticaret.Entity.Product.Bileklik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beu.Eticaret.Dal.Product
{
    public class dBileklik : dCore
    {
        public dBileklik(DbEntities db) : base(db)
        {
            //
        }
        public rBileklik Add(pBileklik args)
        {
            //if (Has(args))
            //    throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");

            var ent = new pr_Bileklik();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pBileklik() { Id = ent.Id });
            return r;
        }
        public rListBileklik List(pListBileklik args)
        {
            var ent = GenerateQuery();
            try
            {
                ent = ent.Where(x => x.Id >= args.Id);
                return new rListBileklik() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }
        private IQueryable<eBileklik> GenerateQuery()
        {
            return (from product in db.pr_Bileklik
                    select new eBileklik()
                    {
                        Id = product.Id,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductImage = product.ProductImage
                    });
        }
        public rBileklik Get(pBileklik args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rBileklik() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }


    }
}
