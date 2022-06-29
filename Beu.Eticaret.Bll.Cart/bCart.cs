using Beu.Eticaret.Dal.Cart;
using Beu.Eticaret.Db.Cart;
using Beu.Eticaret.Entity.Cart;
using System;

namespace Beu.Eticaret.Bll.Cart
{
    public class bCart
    {
        public rCart Add(pCart args)
        {
            using (DbEntities db = new DbEntities())
            {
                dCart cart = new dCart(db);
                try
                {
                    return cart.Add(args);
                }
                catch (Exception ex)
                {
                    return new rCart { Message = ex.Message, Error = true };
                }
            }
        }
        public rCart Delete(pCart args)
        {
            using (DbEntities db = new DbEntities())
            {
                dCart cart = new dCart(db);
                try
                {
                    return cart.Delete(args);
                }
                catch (Exception ex)
                {
                    return new rCart { Message = ex.Message, Error = true };
                }
            }
        }
        public rListCart List(pListCart args)
        {
            using (DbEntities db = new DbEntities())
            {
                var menuD = new dCart(db);

                try
                {
                    return menuD.List(args);
                }
                catch (SystemException ex)
                {
                    return new rListCart() { Error = true, Message = ex.Message };
                }
            }
        }
    }
}
