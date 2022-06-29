using Eltemtek.Etcs.Db.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Beu.Eticaret.Db.PostgreSQL
{
    public abstract class PostgreSQLContextCore : DbContext
    {
        public string ConnectionName { get; set; }

        public PostgreSQLContextCore()
        {
            this.ConnectionName = "PostgreSQLConnection";
        }

        public PostgreSQLContextCore(string connectionName)
        {
            this.ConnectionName = connectionName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(ConfigurationManager.GetConfig().GetConnectionString(ConnectionName),
                x => x.UseNetTopologySuite());
        }
    }
}
