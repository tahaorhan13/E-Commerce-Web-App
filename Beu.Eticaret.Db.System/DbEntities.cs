using Beu.Eticaret.Db.PostgreSQL;
using Microsoft.EntityFrameworkCore;


namespace Beu.Eticaret.Db.System
{
    public class DbEntities : PostgreSQLContextCore
    {
        public DbEntities() : base() { }
        public DbEntities(string connectionName) : base(connectionName) { }
        public virtual DbSet<sys_Menu> sys_Menu { get; set; }
        public virtual DbSet<sys_Role> sys_Role { get; set; }
    }
}
