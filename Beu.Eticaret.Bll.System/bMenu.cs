using Beu.Eticaret.Dal.System;
using Beu.Eticaret.Db.System;
using Beu.Eticaret.Entity.System.Menu;
using System;

namespace Beu.Eticaret.Bll.System
{
    public class bMenu
    {
        public rListMenu List(pListMenu args)
        {
            using (DbEntities db = new DbEntities())
            {
                var menuD = new dMenu(db);

                try
                {
                    return menuD.List(args);
                }
                catch (SystemException ex)
                {
                    return new rListMenu() { Error = true, Message = ex.Message };
                }
            }
        }
    }
}
