using Beu.Eticaret.Db.Cart;
using Beu.Eticaret.Db.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Beu.Eticaret.Db.Cart
{
    public partial class DbEntities : PostgreSQLContextCore
    {
        public DbEntities() : base() { }
        public DbEntities(string connectionName) : base(connectionName) { }
        public virtual DbSet<cr_Cart> cr_Cart { get; set; }

    }
}
