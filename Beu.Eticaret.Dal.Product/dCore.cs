using Beu.Eticaret.Db.Product;

namespace Beu.Eticaret.Dal.Product
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
