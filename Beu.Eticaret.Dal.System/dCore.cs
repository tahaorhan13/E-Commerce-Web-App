using Beu.Eticaret.Db.System;

namespace Beu.Eticaret.Dal.System
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
