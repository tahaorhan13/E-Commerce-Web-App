using Beu.Eticaret.Dal.Account;
using Beu.Eticaret.Db.Account.DataAccess;
using Beu.Eticaret.Entity.Account;
using Beu.Eticaret.Entity.Account.User;
using System;

namespace Beu.Eticaret.Bll.Account
{
    public class bUser
    {
        public rUser Add(pUser args)
        {
            using (DbEntities db = new DbEntities())
            {
                dUser user = new dUser(db);
                try
                {
                    return user.Add(args);
                }
                catch (Exception ex)
                {
                    return new rUser { Message = ex.Message, Error = true };
                }
            }
        }
        public rUser Update(puUser args)
        {
            using (DbEntities db = new DbEntities())
            {
                var userD = new dUser(db);
                try
                {
                    return userD.Update(args);
                }
                catch (SystemException ex)
                {
                    return new rUser() { Error = true, Message = ex.Message };
                }

            }
        }
        public rListUser List(pListUser args)
        {
            using (DbEntities db = new DbEntities())
            {
                var userD = new dUser(db);

                try
                {
                    return userD.List(args);
                }
                catch (SystemException ex)
                {
                    return new rListUser() { Error = true, Message = ex.Message };
                }
            }
        }

    }
}
