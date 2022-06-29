using Beu.Eticaret.Db.PostgreSQL;
using Microsoft.EntityFrameworkCore;


namespace Beu.Eticaret.Db.Product
{
    public class DbEntities : PostgreSQLContextCore
    {
        public DbEntities() : base() { }
        public DbEntities(string connectionName) : base(connectionName) { }
        public virtual DbSet<pr_Product> pr_Product { get; set; }
        public virtual DbSet<pr_Tesbih> pr_Tesbih { get; set; }
        public virtual DbSet<pr_Bileklik> pr_Bileklik { get; set; }
        public virtual DbSet<pr_Yuzuk> pr_Yuzuk { get; set; }
        public virtual DbSet<pr_Kolye> pr_Kolye { get; set; }
        public virtual DbSet<pr_Kupe> pr_Kupe { get; set; }
    }
}
