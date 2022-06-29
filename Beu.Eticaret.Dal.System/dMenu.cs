using Beu.Eticaret.Db.System;
using Beu.Eticaret.Entity.System.Menu;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.System
{
    public class dMenu : dCore
    {
        public dMenu(DbEntities db) : base(db)
        {
            //
        }
        private IQueryable<eMenu> GenerateQuery()
        {
            return (from menu in db.sys_Menu
                    select new eMenu()
                    {
                        Id = menu.Id,
                        Name = menu.Name,
                        RoutingUrl = menu.RoutingUrl,
                        AccessLevel = menu.AccessLevel,
                        Icon = menu.Icon
                    });
        }
        public rListMenu List(pListMenu args)
        {
            var ent = GenerateQuery();
            try
            {
                ent = ent.Where(x => x.AccessLevel >= args.AccessLevel);
                return new rListMenu() { Value = ent.ToList() };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
