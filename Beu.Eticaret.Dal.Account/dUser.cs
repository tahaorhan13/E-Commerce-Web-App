using Beu.Eticaret.Dal.PostgreSQL;
using Beu.Eticaret.Db.Account;
using Beu.Eticaret.Db.Account.DataAccess;
using Beu.Eticaret.Entity;
using Beu.Eticaret.Entity.Account;
using Beu.Eticaret.Entity.Account.User;
using System;
using System.Linq;

namespace Beu.Eticaret.Dal.Account
{
    public class dUser : dCore
    {
        public dUser(DbEntities db) : base(db)
        {
            //
        }
        public rUser Add(pUser args)
        {
            if (Has(args))
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");

            var ent = new acc_User();

            try
            {
                ent.addEntity(db, args);
            }
            catch (Exception)
            {
                throw;
            }
            var r = Get(new pUser() { Id = ent.Id });
            return r;
        }
        private bool Has(pUser args)
        {
            args.validateValues(false);

            try
            {
                return db.acc_User.Where(w => w.Email == args.Email).Any();
            }
            catch (Exception ex)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex",ex);
            }
        }
        public rUser Get(pUser args)
        {
            //if (args.Id.isEqualOrLessThanZero())
            //    throw new SystemException(Messages.Codes._101, Messages.SystemCodes.INCORRECT_OR_MISSING_PARAMETER_VALUE);

            var q = GenerateQuery();

            if (args.Id > 0)
                q = q.Where(w => w.Id == args.Id);

            if (args.Email != null)
                q = q.Where(w => w.Email == args.Email);

            if (args.Password != null)
            {
                var r = db.acc_User.Where(w => w.Email == args.Email && w.Password == args.Password).Any();

                if (!r)
                    return new rUser();
            }


            try
            {
                return new rUser() { Value = q.SingleOrDefault() };
            }
            catch (Exception)
            {
                throw new SystemException("Messages.Codes._101, Messages.SystemCodes.DEFAULT_ERROR, ex");
            }
        }
        private IQueryable<eUser> GenerateQuery()
        {
            return (from user in db.acc_User
                    select new eUser()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        Password = user.Password,
                        AccessLevel=user.AccessLevel
                    });
        }
        public acc_User GetEntity(pId args)
        {
            if (args.Id <= 0)
                throw new SystemException("ıd 0");

            try
            {
                return db.acc_User.Where(x => x.Id == args.Id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw new SystemException("ıd hatalı");
            }
        }
        public rUser Update(puUser args)
        {
            var ent = GetEntity(new pId() { Id = args.Id });

            if (args == null)
                throw new SystemException("null geldi");
            try
            {
                ent.updateEntity(db, args);
            }
            catch (Exception)
            {

                throw;
            }
            var r = Get(new pUser() { Id = ent.Id });
            return r;

        }
        public rListUser List(pListUser args)
        {
            var ent = GenerateQuery();

            try
            {
                ent = ent.Where(x => x.Id == args.Id);

                return new rListUser() { Value = ent.ToList() };
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
