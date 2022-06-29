using Beu.Eticaret.Db.Account.DataAccess;

namespace Beu.Eticaret.Dal.Account
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
