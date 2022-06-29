using Beu.Eticaret.Dal.System;
using Beu.Eticaret.Db.System;
using Beu.Eticaret.Entity.System;
using System;

namespace Eltemtek.Etcs.Bll.System
{
    public class bRole
    {
        public rRole Get(pRole args)
        {
            using (DbEntities db = new DbEntities())
            {
                var roleD = new dRole(db);

                try
                {
                    return roleD.Get(args);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public rRole Add(pRole args)
        {
            using (DbEntities db = new DbEntities())
            {
                var roleD = new dRole(db);

                try
                {
                    return roleD.Add(args);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public rRole Update(pRole args)
        {
            using (DbEntities db = new DbEntities())
            {
                var roleD = new dRole(db);

                try
                {
                    return roleD.Update(args);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public rRole Save(pRole args)
        {
            using (DbEntities db = new DbEntities())
            {
                var roleD = new dRole(db);

                try
                {
                    return roleD.Save(args);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //public rCore Delete(pId args)
        //{
        //    using (DbEntities db = new DbEntities())
        //    {
        //        var roleD = new dRole(db);

        //        try
        //        {
        //            return roleD.Delete(args);
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}

        //public rRole List(pListRole args)
        //{
        //    using (DbEntities db = new DbEntities())
        //    {
        //        var roleD = new dRole(db, info);

        //        try
        //        {
        //            return roleD.List(args);
        //        }
        //        catch (SystemException ex)
        //        {
        //            var errorLogD = new dErrorLog(db, info);
        //            errorLogD.Add(new pErrorLog() { Code = ex.Code, Message = ex.Message, Class = "bRole", Method = "List" });
        //            return new rListRole() { Error = true, Message = this.GetErrorMessage(ex) };
        //        }
        //    }
        //}
    }
}
