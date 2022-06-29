using Beu.Eticaret.Db.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Beu.Eticaret.Db.Account.DataAccess
{
    public partial class DbEntities : PostgreSQLContextCore
    {
        public DbEntities() : base() { }
        public DbEntities(string connectionName) : base(connectionName) { }
        public virtual DbSet<acc_User> acc_User { get; set; }
        public virtual DbSet<acc_UserToken> acc_UserToken { get; set; }

    }
}
