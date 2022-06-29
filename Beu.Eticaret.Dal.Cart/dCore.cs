using Beu.Eticaret.Db.Cart;

namespace Beu.Eticaret.Dal.Cart
{
    public abstract class dCore
    {
        protected DbEntities db;
        public dCore(DbEntities db)
        {
            this.db = db;
        }
    }
}
