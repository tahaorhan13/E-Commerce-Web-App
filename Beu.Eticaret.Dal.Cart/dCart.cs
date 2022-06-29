using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Cart;
using Beu.Eticaret.Entity.Cart;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Cart
{
    public class dCart:dCore
    {
        public dCart(DbEntities db) : base(db)
        {
            //
        }
        public rCart Add(pCart args)
        {
            var ent = new cr_Cart();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pCart() { Id = ent.Id });
            return r;
        }
        public rCart Delete(pCart args)
        {
            var ent = new cr_Cart();

            try
            {
                ent.removeEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pCart() { Id = ent.Id });
            return r;
        }
        private bool Has(pCart args)
        {
            args.validateValues(false);

            try
            {
                return db.cr_Cart.Where(w => w.Name == args.Name).Any();
            }
            catch (Exception ex)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex", ex);
            }
        }
        public rCart Get(pCart args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            try
            {
                return new rCart() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }
        private IQueryable<eCart> GenerateQuery()
        {
            return (from cart in db.cr_Cart
                    select new eCart()
                    {
                        Id = cart.Id,
                        Name = cart.Name,
                        Price = cart.Price,
                        Piece = cart.Piece,
                        UserId = cart.UserId,
                        ProductImage=cart.ProductImage
                    });
        }
        public rListCart List(pListCart args)
        {
            var ent = GenerateQuery();
            try
            {
                ent = ent.Where(x => x.UserId >= args.UserId);
                return new rListCart() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
